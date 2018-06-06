using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AppCore;
using AppCore.Models;
using AppCore.Settings;
using iTextSharp.text.pdf;
using Offers;

namespace Offers
{
    public class ReportTemplate
    {
        public string MainTemplatePath { get; set; }
        public string TableTemplatePath { get; set; }
    }



    public class ExportUtils
    {
        private ReportTemplate _template;

        public ExportUtils(ReportTemplate template)
        {
            _template = template;
        }


        public string Export(OfferInstance offer)
        {
            Dictionary<string,string> main = new Dictionary<string, string>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                var customer = db.Contragents.FirstOrDefault(a =>
                    a.ContrAgentID == db.Offers.FirstOrDefault(x => x.ID == offer.offer.ID).ContrAgentID);
                main.Add("#customer#", customer.Name);
                var from = db.Manufacters.FirstOrDefault(x => x.ID == offer.header.ManufacterID);
                main.Add("#from#", from.Name);
                main.Add("#from_rus#", from.NameRus);
                main.Add("#offer_num#", offer.header.OfferNumber);
                main.Add("#offerdate#", offer.offer.CreateDate.ToString());
               // main.Add("#headertext#", offer.header.);
                main.Add("#subject#",offer.header.Subject);
                main.Add("#subject_rus#", offer.header.SubjectRus);
                main.Add("#delivery#",offer.footer.Delivery);
                main.Add("#delivery_rus#", offer.footer.DeliveryRus);
                main.Add("#payment#", offer.footer.Payment);
                main.Add("#payment_rus#", offer.footer.PaymentRus);
                main.Add("#goodsdeliv#", offer.footer.GoodsDeliv);
                main.Add("#goodsdeliv_rus#", offer.footer.GoodsDelivRus);
                main.Add("#offertill#", offer.footer.OfferTill.ToString());
                main.Add("#techassist#", offer.footer.TechAssist);
                main.Add("#techassist_rus#", offer.footer.TechAssistRus);
                main.Add("#techdoc#",offer.footer.TechDoc);
                main.Add("#techdoc_rus#", offer.footer.TechDocRus);
                main.Add("#warranty#", offer.footer.Warranty);
                main.Add("#warranty_rus#", offer.footer.WarrantyRus);
                main.Add("#total#", offer.footer.TotalAmountGoods.ToString());
                main.Add("#pack#", offer.footer.PackPrice.ToString());
                main.Add("#general#", offer.footer.GeneralAmount.ToString());

            }

            var str = File.ReadAllText(_template.MainTemplatePath);
            var resultHtml = ReplacePlaceholders(main, str);

            File.WriteAllText(@"D:\qwe.html", resultHtml);

            Parse(resultHtml);
            return "";
        }

        public void Parse2(string html)
        {

        }
        
        public void Parse(string html)
        {
            Byte[] bytes;
            
            //Boilerplate iTextSharp setup here
            //Create a stream that we can write to, in this case a MemoryStream
            using (var ms = new MemoryStream())
            {

                //Create an iTextSharp Document which is an abstraction of a PDF but **NOT** a PDF
                using (var doc = new iTextSharp.text.Document())
                {
                    //Create a writer that's bound to our PDF abstraction and our stream
                    using (var writer = PdfWriter.GetInstance(doc, ms))
                    {

                        //Open the document for writing
                        doc.Open();

                        //Our sample HTML and CSS
                        //html = @"<p>This <em>is </em><span class=""headline"" style=""text-decoration: underline;"">some</span> <strong>sample <em> text</em></strong><span style=""color: red;"">!!!</span></p>";
                        var example_css = File.ReadAllText(@"D:\template\style.css");//@".headline{font-size:200%}";

            
                        using (var msCss = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(example_css)))
                        {
                            using (var msHtml = new MemoryStream(System.Text.Encoding.UTF8.GetBytes(html)))
                            {
                                
                                //Parse the HTML
                                iTextSharp.tool.xml.XMLWorkerHelper.GetInstance().ParseXHtml(writer, doc, msHtml, msCss);
                            }
                        }


                        doc.Close();
                    }
                }
                bytes = ms.ToArray();
            }
            var testFile = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.Desktop), "test.pdf");
            System.IO.File.WriteAllBytes(testFile, bytes);
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
