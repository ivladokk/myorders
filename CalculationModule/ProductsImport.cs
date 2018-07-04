using DevExpress.XtraEditors;
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
using AppCore.Models;

namespace CalculationModule
{
    public partial class ProductsImport : XtraForm
    {
        private ImportProductAttributes import;
        private DataTable dt;
        private ProductsDictionary _sender;
        public ProductsImport(ProductsDictionary sender)
        {
            InitializeComponent();
            _sender = sender;
            btn_import.Enabled = false;
            import = new ImportProductAttributes();
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            ReadClipboard();
        }

        private void ReadClipboard()
        {
            dt = import.clipboardExcelToDataTable();
            if (dt != null)
            {
                if (dt.Columns.Count != dataGridView1.ColumnCount)
                {
                    return;
                }
                for (int i=0; i < dataGridView1.Columns.Count; i++)
                {
                    dt.Columns[i].ColumnName = dataGridView1.Columns[i].Name;
                    dt.Columns[i].Caption = dataGridView1.Columns[i].HeaderText;
                }
                dataGridView1.DataSource = dt;
                foreach (DataColumn i in (dataGridView1.DataSource as DataTable).Columns)
                {
                    dataGridView1.Columns[i.ColumnName].HeaderText = i.Caption;
                }

                btn_import.Enabled = true;
            }
            else btn_import.Enabled = false;
        }

        private void ImportFromCSV(string filename)
        {

            dt = new DataTable();
            foreach (DataGridViewColumn col in dataGridView1.Columns)
            {
                dt.Columns.Add(new DataColumn
                {
                    ColumnName = col.Name,
                    Caption = col.HeaderText
                });
            }
           
            var lines = File.ReadLines(filename).ToList();
            for (int i = 1; i < lines.Count; i++)
            {
                var line = lines[i].Split(';');
                dt.Rows.Add();
                //dt.Rows[i - 1]["Code"] = line[0];
                dt.Rows[i - 1]["VendorCode"] = line[0];
                //dt.Rows[i - 1]["View"] = line[2];
                dt.Rows[i - 1]["ProductName"] = line[1];
                dt.Rows[i - 1]["Unit"] = line[2];
                //dt.Rows[i - 1]["GoodsGroup"] = line[5];
                dt.Rows[i - 1]["TNVEDCode"] = line[3];
                //dt.Rows[i - 1]["Duty"] = line[7];
                dt.Rows[i - 1]["TNVEDValue"] = line[4];
                //dt.Rows[i - 1]["Owner"] = line[9];
               // dt.Rows[i - 1]["Certificate"] = line[10];
               // dt.Rows[i - 1]["Declaration"] = line[11];
            }
            dataGridView1.Columns.Clear();
            dataGridView1.DataSource = dt;
            foreach (DataColumn i in (dataGridView1.DataSource as DataTable).Columns)
            {
                dataGridView1.Columns[i.ColumnName].HeaderText = i.Caption;
            }

        }


        private void btn_import_Click(object sender, EventArgs e)
        {
            var list = new List<ProductAttribute>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                try
                {
                    ProductAttribute attr = new ProductAttribute();

                    //attr.Code = String.IsNullOrEmpty(dt.Rows[i]["Code"].ToString())
                    // ? 0
                    // : Convert.ToInt32(dt.Rows[i]["Code"]);
                    attr.VendorCode = dt.Rows[i]["VendorCode"].ToString().ToUpper();
                    //attr.View = dt.Rows[i]["View"].ToString();
                    attr.ProductName = dt.Rows[i]["ProductName"].ToString();
                    attr.Unit = dt.Rows[i]["Unit"].ToString();
                    //attr.GoodsGroup = String.IsNullOrEmpty(dt.Rows[i]["GoodsGroup"].ToString())
                    //  ? 0
                    //  : Convert.ToInt32(dt.Rows[i]["GoodsGroup"]);
                    attr.TNVEDCode = String.IsNullOrEmpty(dt.Rows[i]["TNVEDCode"].ToString())
                        ? 0
                        : Convert.ToInt64(dt.Rows[i]["TNVEDCode"]);
                    //attr.Duty = Convert.ToInt32(dt.Rows[i]["Duty"]);
                    attr.TNVEDValue = String.IsNullOrEmpty(dt.Rows[i]["TNVEDCode"].ToString())
                        ? 0
                        : Convert.ToDecimal(dt.Rows[i]["TNVEDValue"].ToString().Replace(".", ",").Replace("%", ""));
                    //attr.Owner = dt.Rows[i]["Owner"].ToString();
                    //attr.Certificate = dt.Rows[i]["Certificate"].ToString();
                    //attr.Declaration = dt.Rows[i]["Declaration"].ToString();

                    list.Add(attr);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при импорте товара {dt.Rows[i]["VendorCode"]} {dt.Rows[i]["ProductName"]} {dt.Rows[i]["TNVEDCode"]}");
                }
                
            }

            MessageBox.Show(import.Import(list)
                ? $"Импортировано {list.Count} позиций"
                : "При импорте произошла ошибка");
            this.Close();
            _sender.Load();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.ShowDialog();
            if (!String.IsNullOrEmpty(dialog.FileName))
            {
                ImportFromCSV(dialog.FileName);
                btn_import.Enabled = true;
            }
        }
    }
}
