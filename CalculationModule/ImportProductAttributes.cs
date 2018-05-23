using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace CalculationModule
{
    public class ImportProductAttributes
    {
        
        public bool Import(List<ProductAttribute> attributes)
        {
            try
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    foreach (var i in attributes)
                    {
                        var item = db.ProductAttributes.FirstOrDefault(
                            x => x.VendorCode.ToUpper() == i.VendorCode.ToUpper());
                        if (item != null)
                        {
                            item.TNVEDCode = i.TNVEDCode;
                            item.TNVEDValue = i.TNVEDValue;
                            db.ProductAttributes.Attach(item);
                            var entry = db.Entry(item);
                            entry.Property(x => x.TNVEDCode).IsModified = true;
                            entry.Property(x => x.TNVEDValue).IsModified = true;

                        }
                        else
                        {
                            db.ProductAttributes.Add(i);
                        }
                        db.SaveChanges();
                    }
                }

                return true;
            }
            catch (Exception e)
            {
                MessageBox.Show(e.Message);
                return false;
            }
            
        }
        public DataTable clipboardExcelToDataTable(bool blnFirstRowHasHeader = false)
        {
            string strTime = "S " + DateTime.Now.ToString("mm:ss:fff");
            var clipboard = Clipboard.GetDataObject();
            if (!clipboard.GetDataPresent("XML Spreadsheet")) return null;

            strTime += "\r\nRead " + DateTime.Now.ToString("mm:ss:fff");
            StreamReader streamReader = new StreamReader((MemoryStream)clipboard.GetData("XML Spreadsheet"));
            strTime += "\r\nFinish read " + DateTime.Now.ToString("mm:ss:fff");
            streamReader.BaseStream.SetLength(streamReader.BaseStream.Length - 1);

            XmlDocument xmlDocument = new XmlDocument();
            xmlDocument.LoadXml(streamReader.ReadToEnd());
            strTime += "\r\nRead XML Document " + DateTime.Now.ToString("mm:ss:fff");

            XNamespace ssNs = "urn:schemas-microsoft-com:office:spreadsheet";
            DataTable dtData = new DataTable();

            var linqRows = xmlDocument.fwToXDocument().Descendants(ssNs + "Row").ToList<XElement>();

            for (int x = 0; x < linqRows.Max(a => a.Descendants(ssNs + "Cell").Count()); x++)
                dtData.Columns.Add("Column " + (x + 1).ToString());

            int intCol = 0;

            DataRow drCurrent;

            linqRows.ForEach(rowElement =>
            {
                intCol = 0;
                drCurrent = dtData.Rows.Add();
                rowElement.Descendants(ssNs + "Cell")
                    .ToList<XElement>()
                    .ForEach(cell => drCurrent[intCol++] = cell.Value);
            });

            if (blnFirstRowHasHeader)
            {
                int x = 0;
                foreach (DataColumn dcCurrent in dtData.Columns)
                    dcCurrent.ColumnName = dtData.Rows[0][x++].ToString();

                dtData.Rows.RemoveAt(0);
            }

            strTime += "\r\nF " + DateTime.Now.ToString("mm:ss:fff");

            return dtData;
        }

    }
    public static class Ext
    {
        public static XDocument fwToXDocument(this XmlDocument xmlDocument)
        {
            using (XmlNodeReader xmlNodeReader = new XmlNodeReader(xmlDocument))
            {
                xmlNodeReader.MoveToContent();
                return XDocument.Load(xmlNodeReader);
            }
        }
    }
}
