using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Offers;

namespace Offers
{
    public class ReportTemplate
    {
        public string MainTemplatePath { get; set; }
        public string TableTemplatePath { get; set; }
    }

    public class JsonData
    {
        public string type { get; set; }
        public string htmlCode { get; set; }
    }


    public class ExportUtils
    {
        private ReportTemplate _template;

        public ExportUtils(ReportTemplate template)
        {
            _template = template;
        }


        public void Export(OfferInstance offer, string folder)
        {
            Dictionary<string,string> main = new Dictionary<string, string>();
           
            ContrAgent customer = new ContrAgent();
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    customer = db.Contragents.FirstOrDefault(a =>
                        a.ContrAgentID == db.Offers.FirstOrDefault(x => x.ID == offer.offer.ID).ContrAgentID);
                    main.Add("#customer#", customer.NameEng);
                    main.Add("#customer_rus#", customer.Name);
                    var from = db.Manufacters.FirstOrDefault(x => x.ID == offer.header.ManufacterID);
                    main.Add("#from#", from.Name);
                    main.Add("#from_rus#", from.NameRus);
                    main.Add("#offernum#", offer.header.OfferNumber);
                    main.Add("#offerdate#", offer.offer.CreateDate.ToString("dd.MM.yyyy"));
                    main.Add("#headertext#", offer.header.HeaderText);
                    main.Add("#headertext_rus#", offer.header.HeaderTextRus);
                    main.Add("#subject#", offer.header.Subject);
                    main.Add("#subject_rus#", offer.header.SubjectRus);
                    main.Add("#delivery#", offer.footer.Delivery);
                    main.Add("#delivery_rus#", offer.footer.DeliveryRus);
                    main.Add("#payment#", offer.footer.Payment);
                    main.Add("#payment_rus#", offer.footer.PaymentRus);
                    main.Add("#goodsdeliv#", offer.footer.GoodsDeliv);
                    main.Add("#goodsdeliv_rus#", offer.footer.GoodsDelivRus);
                    main.Add("#offertill#", offer.footer.OfferTill.ToString("dd.MM.yyyy"));
                    main.Add("#techassist#", offer.footer.TechAssist);
                    main.Add("#techassist_rus#", offer.footer.TechAssistRus);
                    main.Add("#techdoc#", offer.footer.TechDoc);
                    main.Add("#techdoc_rus#", offer.footer.TechDocRus);
                    main.Add("#warranty#", offer.footer.Warranty);
                    main.Add("#warranty_rus#", offer.footer.WarrantyRus);
                    main.Add("#total#", offer.footer.TotalAmountGoods.ToString());
                    main.Add("#pack#", offer.footer.PackPrice.ToString());
                    main.Add("#general#", offer.footer.GeneralAmount.ToString());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

            var str = File.ReadAllText(_template.MainTemplatePath);
            var resultHtml = ReplacePlaceholders(main, str);
            resultHtml = resultHtml.Replace("#table#", GetItemsTable(offer.items));

            var data = new JsonData()
            {
                type = "htmlToPdf",
                htmlCode = resultHtml
            };

            if (GetPDF(data, folder))
            {
                MessageBox.Show("Файл успешно экспортирован!");
            }
            
            
            //CancellationTokenSource token = new CancellationTokenSource();
            
            //var pdfAsync = GetPDFAsync(data, @"d:\" + filename, token.Token);

            
        }

        private string GetItemsTable(List<OfferItem> items)
        {
            string result = "";
            foreach (var i in items)
            {
                Dictionary<string,string> table = new Dictionary<string, string>();
                try
                {
                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        var equip = db.Equipments.FirstOrDefault(x => x.ID == i.EquipmentID);
                        table.Add("#code#", equip.Code);
                        table.Add("#count#", i.Count.ToString());
                        table.Add("#description#", equip.Description);
                        table.Add("#description_rus#", equip.DescriptionRus);
                        table.Add("#price#", i.Price.ToString());
                        table.Add("#amount#", i.Amount.ToString());
                        table.Add("#equipname#", equip.EquipName);
                        table.Add("#equipname_rus#", equip.EquipNameRus);
                        table.Add("#image#", equip.Image);
                        var str = File.ReadAllText(_template.TableTemplatePath);
                        result += ReplacePlaceholders(table, str); 
                    }
                }
                catch (Exception e)
                {

                }
                
            }
            
             
            return result;
        }
        public async Task<bool> GetPDFAsync(JsonData data, string fileName, CancellationToken ct)
        {
            
            var json = JsonConvert.SerializeObject(data);
            HttpClient client = new HttpClient();
            var content = new StringContent(json, Encoding.UTF8, "application/json");

            try
            {
                var result = await client.PostAsync("https://api.sejda.com/v1/tasks", content, ct);
                var bytes = result.Content.ReadAsByteArrayAsync().Result;
                ct.ThrowIfCancellationRequested();
                File.WriteAllBytes(fileName, bytes);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
        }

        public bool GetPDF(JsonData data, string fileName)
        {
            try
            {
                var json = JsonConvert.SerializeObject(data);
                HttpClient client = new HttpClient();
                var content = new StringContent(json, Encoding.UTF8, "application/json");
                var result = client.PostAsync("https://api.sejda.com/v1/tasks", content).Result;
                var bytes = result.Content.ReadAsByteArrayAsync().Result;
                File.WriteAllBytes(fileName, bytes);
                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
           
        }

        
        


        private string ReplacePlaceholders(Dictionary<string, string> replace, string str)
        {
            var ret = str;
            foreach (var i in replace)
            {
                ret = ret.Replace(i.Key, i.Value);
            }
            return ret;
        }


    }
}
