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
using AppCore.Components;
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
        public string pageSize { get; set; }
        public string pageOrientation { get; set; }
        public int viewportWidth { get; set; }
    }


    public class ExportUtils
    {
        private ReportTemplate _template;
        private OfferInstance _offer;
        private string _folder;

        public ExportUtils(ReportTemplate template, OfferInstance offer, string folder)
        {
            _template = template;
            _offer = offer;
            _folder = folder;
        }

        public Action GetAction()
        {
            return Export;
        }

        public void Export()
        {
            Dictionary<string,string> main = new Dictionary<string, string>();
           
            ContrAgent customer = new ContrAgent();
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    customer = db.Contragents.FirstOrDefault(a =>
                        a.ContrAgentID == db.Offers.FirstOrDefault(x => x.ID == _offer.offer.ID).ContrAgentID);
                    main.Add("#customer#", customer.NameEng);
                    main.Add("#customer_rus#", customer.Name);
                    var from = db.Manufacters.FirstOrDefault(x => x.ID == _offer.header.ManufacterID);
                    main.Add("#from#", from.Name);
                    main.Add("#from_rus#", from.NameRus);
                    main.Add("#offernum#", _offer.header.OfferNumber);
                    main.Add("#offerdate#", _offer.offer.CreateDate.ToString("dd.MM.yyyy"));
                    main.Add("#headertext#", _offer.header.HeaderText);
                    main.Add("#headertext_rus#", _offer.header.HeaderTextRus);
                    main.Add("#subject#", _offer.header.Subject);
                    main.Add("#subject_rus#", _offer.header.SubjectRus);
                    main.Add("#delivery#", _offer.footer.Delivery);
                    main.Add("#delivery_rus#", _offer.footer.DeliveryRus);
                    main.Add("#payment#", _offer.footer.Payment);
                    main.Add("#payment_rus#", _offer.footer.PaymentRus);
                    main.Add("#goodsdeliv#", _offer.footer.GoodsDeliv);
                    main.Add("#goodsdeliv_rus#", _offer.footer.GoodsDelivRus);
                    main.Add("#offertill#", _offer.footer.OfferTill.ToString("dd.MM.yyyy"));
                    main.Add("#techassist#", _offer.footer.TechAssist);
                    main.Add("#techassist_rus#", _offer.footer.TechAssistRus);
                    main.Add("#techdoc#", _offer.footer.TechDoc);
                    main.Add("#techdoc_rus#", _offer.footer.TechDocRus);
                    main.Add("#warranty#", _offer.footer.Warranty);
                    main.Add("#warranty_rus#", _offer.footer.WarrantyRus);
                    main.Add("#total#", _offer.footer.TotalAmountGoods.ToString());
                    main.Add("#pack#", _offer.footer.PackPrice.ToString());
                    main.Add("#general#", _offer.footer.GeneralAmount.ToString());
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            

            var str = File.ReadAllText(_template.MainTemplatePath);
            var resultHtml = ReplacePlaceholders(main, str);
            resultHtml = resultHtml.Replace("#table#", GetItemsTable(_offer.items));

            var data = new JsonData()
            {
                type = "htmlToPdf",
                htmlCode = resultHtml,
                viewportWidth = 2000,
                pageOrientation = "landscape"
            };

            if (GetPDF(data, _folder))
            {
                MessageBox.Show("Файл успешно экспортирован!");
            }
            
            
            //CancellationTokenSource token = new CancellationTokenSource();
            
            //var pdfAsync = GetPDFAsync(data, @"d:\" + filename, token.Token);

            
        }

        private string GetBase64Img(string img)
        {

            return Convert.ToBase64String(File.ReadAllBytes(img));
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
                        table.Add("#image#", GetBase64Img(equip.Image));
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
