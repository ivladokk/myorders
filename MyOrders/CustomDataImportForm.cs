using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
using CalculationModule;

namespace MyOrders
{
    public partial class CustomDataImportForm : Form
    {
        private CustomsData _sender;
        public CustomDataImportForm(CustomsData sender)
        {
            InitializeComponent();
            _sender = sender;
            btn_import.Enabled = false;
        }

        private DataTable dt;
        private void btn_load_Click(object sender, EventArgs e)
        {
            btn_import.Enabled = false;
            dt = clipboardExcelToDataTable();
            if (dt != null)
            {
                dataGridView1.DataSource = dt;
                btn_import.Enabled = true;
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

        private void btn_import_Click(object sender, EventArgs e)
        {
            Type type = typeof(CustomsGood);
            var props = type.GetProperties();
            if (props.Length - 1  == dt.Columns.Count)
            {
                var list = new List<CustomsGood>();
                try
                {
                    foreach (DataRow i in dt.Rows)
                    {
                        CustomsGood data = new CustomsGood
                        {
                            ND = i[0].ToString().Replace("\r\n",""),
                            G022 = i[1].ToString().Replace("\r\n", ""),
                            G081 = i[2].ToString().Replace("\r\n", ""),
                            G082 = i[3].ToString().Replace("\r\n", ""),
                            G23 = i[4].ToString().Replace("\r\n", ""),
                            G31_1 = i[5].ToString().Replace("\r\n", ""),
                            TEXT1 = i[6].ToString().Replace("\r\n", ""),
                            G31_11 = i[7].ToString().Replace("\r\n", ""),
                            G31_7 = i[8].ToString().Replace("\r\n", ""),
                            G31_71 = i[9].ToString().Replace("\r\n", ""),
                            G33 = i[10].ToString().Replace("\r\n", ""),
                            EXW = i[11].ToString().Replace("\r\n", ""),
                            G42 = i[12].ToString().Replace("\r\n", ""),
                            G45 = i[13].ToString().Replace("\r\n", ""),
                            SelfValue = i[14].ToString().Replace("\r\n", ""),
                            G474RUB = i[15].ToString().Replace("\r\n", ""),
                            TOVG = i[16].ToString().Replace("\r\n", "")
                        };
                        list.Add(data);
                    }

                    using (UserContext db = new UserContext(Settings.constr))
                    {
                        db.CustomsGoods.AddRange(list);
                        db.SaveChanges();
                    }

                    MessageBox.Show("Импорт завершен!");
                    _sender.Init();
                    Close();
                }
                catch (Exception exception)
                {
                    MessageBox.Show(exception.Message);
                }
                
            }

            
        }
    }
}
