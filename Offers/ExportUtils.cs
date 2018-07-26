using System;
using System.Collections.Generic;
using System.Drawing;
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
using AutoMapper;
using GroupDocs.Assembly;
using iTextSharp.text.pdf;
using Newtonsoft.Json;
using Offers;
using Microsoft.Office.Interop.Word;
using Application = System.Windows.Forms.Application;

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

    public class OfferPrintModel: Offer
    {
        public ContrAgent Customer { get; set; }
        public string Date { get; set; }
    }

    public class OfferHeaderPrintModel : OfferHeader
    {
        public Manufacter Manufacter { get; set; }
    }

    public class OfferItemPrintModel: OfferItem
    {
        public Equipment Equipment { get; set; }
        public List<Image> Images { get; set; }
    }
    public class OfferReportModel
    {
        public OfferPrintModel Offer { get; set; }
        public OfferHeaderPrintModel Header { get; set; }
        public IEnumerable<OfferItemPrintModel> Items { get; set; }
        public OfferFooter Footer { get; set; }
        public string OfferTill { get; set; }
        public Image Logo { get; set; }

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

        private dynamic model;
        public void Ex2()
        {
            string tmpDocx = $"{Application.StartupPath}\\temp\\{Guid.NewGuid().ToString()}.docx";


            var headerConfig = new MapperConfiguration(cfg => cfg.CreateMap<OfferHeader, OfferHeaderPrintModel>());
            var headerMapper = headerConfig.CreateMapper();
            var headerForPrint = headerMapper.Map<OfferHeader, OfferHeaderPrintModel>(_offer.header);
            


            var offerConfig = new MapperConfiguration(cfg => cfg.CreateMap<Offer, OfferPrintModel>());
            var offerMapper = offerConfig.CreateMapper();
            var offerForPrint = offerMapper.Map<Offer, OfferPrintModel>(_offer.offer);
            offerForPrint.Date = offerForPrint.CreateDate.ToString("dd.MM.yyyy");


            var itemConfig = new MapperConfiguration(cfg => cfg.CreateMap<OfferItem, OfferItemPrintModel>());
            var itemMapper = itemConfig.CreateMapper();

            List<OfferItemPrintModel> items = new List<OfferItemPrintModel>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                var customer = db.Contragents.FirstOrDefault(a =>
                    a.ContrAgentID == db.Offers.FirstOrDefault(x => x.ID == _offer.offer.ID).ContrAgentID);
                offerForPrint.Customer = customer;
                var from = db.Manufacters.FirstOrDefault(x => x.ID == _offer.header.ManufacterID);
                headerForPrint.Manufacter = from;
                foreach (var i in _offer.items)
                {
                    var item = itemMapper.Map<OfferItem, OfferItemPrintModel>(i);
                    var equip = db.Equipments.FirstOrDefault(x => x.ID == i.EquipmentID);
                    item.Equipment = equip;
                    item.Images = new List<Image>();
                    if (equip.Image != "")
                    {
                        item.Images.Add(Image.FromFile(equip.Image));
                    }
                    items.Add(item);
                }

            }

            OfferReportModel fullOffer = new OfferReportModel
            {
                Offer = offerForPrint,
                Header = headerForPrint,
                Items = items,
                Footer = _offer.footer,
                OfferTill = _offer.footer.OfferTill.ToString("dd.MM.yyyy"),
                Logo = !string.IsNullOrEmpty(headerForPrint.Manufacter.Logo) ? Image.FromFile(headerForPrint.Manufacter.Logo) : null
            };

            string template = fullOffer.Logo != null
                ? Application.StartupPath + @"\template\offer_template.docx"
                : Application.StartupPath + @"\template\offer_template_nologo.docx";

            DocumentAssembler assembler = new DocumentAssembler();
            assembler.AssembleDocument(template, tmpDocx, fullOffer, "offer");


            Microsoft.Office.Interop.Word.Application appWord = new Microsoft.Office.Interop.Word.Application();
            wordDocument = appWord.Documents.Open(tmpDocx);
            FindAndReplace(appWord, "Evaluation Only. Created with GroupDocs.Assembly 18.6. © Aspose Pty Ltd 2001-2018. All Rights Reserved.", "");

            wordDocument.ExportAsFixedFormat(_folder, WdExportFormat.wdExportFormatPDF);
            wordDocument.Close();
        }
        private void FindAndReplace(Microsoft.Office.Interop.Word.Application doc, object findText, object replaceWithText)
        {
            //options
            object matchCase = false;
            object matchWholeWord = true;
            object matchWildCards = false;
            object matchSoundsLike = false;
            object matchAllWordForms = false;
            object forward = true;
            object format = false;
            object matchKashida = false;
            object matchDiacritics = false;
            object matchAlefHamza = false;
            object matchControl = false;
            object read_only = false;
            object visible = true;
            object replace = 2;
            object wrap = 1;
            //execute find and replace
            doc.Selection.Find.Execute(ref findText, ref matchCase, ref matchWholeWord,
                ref matchWildCards, ref matchSoundsLike, ref matchAllWordForms, ref forward, ref wrap, ref format, ref replaceWithText, ref replace,
                ref matchKashida, ref matchDiacritics, ref matchAlefHamza, ref matchControl);
        }
        public Microsoft.Office.Interop.Word.Document wordDocument { get; set; }
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
                    //offerForPrint.Customer = customer;

                    main.Add("#customer#", customer.NameEng);
                    main.Add("#customer_rus#", customer.Name);
                    var from = db.Manufacters.FirstOrDefault(x => x.ID == _offer.header.ManufacterID);
                    //headerForPrint = 
                    //headerForPrint.Manufacter = from;

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
