using DevExpress.XtraEditors;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
                dt.Columns[0].ColumnName = "Артикул";
                dt.Columns[1].ColumnName = "Код ТНВЭД";
                dt.Columns[2].ColumnName = "Ставка";
                dataGridView1.DataSource = dt;
                btn_import.Enabled = true;
            }
            else btn_import.Enabled = false;
        }

        private void btn_import_Click(object sender, EventArgs e)
        {
            var list = new List<ProductAttribute>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                ProductAttribute attr = new ProductAttribute
                {
                    VendorCode = dt.Rows[i]["Артикул"].ToString().ToUpper(),
                    TNVEDCode = Convert.ToInt32(dt.Rows[i]["Код ТНВЭД"]),
                    TNVEDValue = Convert.ToDecimal(dt.Rows[i]["Ставка"].ToString().Replace(".", ","))
                };
                list.Add(attr);
            }

            MessageBox.Show(import.Import(list)
                ? $"Импортировано {list.Count} позиций"
                : "При импорте произошла ошибка");
            this.Close();
            _sender.Load();
        }
    }
}
