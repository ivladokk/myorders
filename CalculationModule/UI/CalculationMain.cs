using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml;
using System.Xml.Linq;
using AppCore;
using AppCore.Components;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Settings;


namespace CalculationModule.UI
{
    public partial class CalculationMain : Form, IUpdForm
    {
        private MyGrid grid;
        public CalculationMain()
        {
            InitializeComponent();
            MyGridSettings settings = new MyGridSettings();
            settings.ContextMenuItems = GetMenuItems();
            grid = new MyGrid(settings);
            grid.Dock = DockStyle.Fill;
            Controls.Add(grid);
            //CreateStatusMenu();
            Init();
           

        }

        private List<ToolStripMenuItem> GetMenuItems()
        {
            var ret = new List<ToolStripMenuItem>();
            ToolStripMenuItem createItem = new ToolStripMenuItem
            {
                Name = "createItem",
                Text = "Создать",
            };
            createItem.Click += CreateItem_Click;

            ToolStripMenuItem openItem = new ToolStripMenuItem
            {
                Name = "openItem",
                Text = "Открыть",
            };
            openItem.Click += OpenItem_Click;

            ToolStripMenuItem deleteItem = new ToolStripMenuItem
            {
                Name = "deleteItem",
                Text = "Удалить"
            };
            deleteItem.Click += DeleteItem_Click;
            ToolStripMenuItem statusItem = new ToolStripMenuItem
            {
                Name = "statusItem",
                Text = "Изменить статус"
            };
            
            using (UserContext db = new UserContext(Settings.constr))
            {
                var statuses = db.CalculationStatus.ToList();
                foreach (var i in statuses)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = i.StatusValue;
                    item.Tag = i.ID;
                    item.Click += status_click;
                    statusItem.DropDownItems.Add(item);

                }
            }



            ToolStripMenuItem editItem = new ToolStripMenuItem
            {
                Name = "editItem",
                Text = "Изменить"
            };
            editItem.Click += EditItem_Click;

            ToolStripMenuItem searchItem = new ToolStripMenuItem
            {
                Name = "searchItem",
                Text = "Поиск артикула"
            };
            searchItem.Click += SearchItem_Click;
            ret.Add(openItem);
            ret.Add(createItem);
            ret.Add(deleteItem);
            ret.Add(statusItem);
            ret.Add(searchItem);
            //ret.Add(editItem);
            return ret;
        }

        private void SearchItem_Click(object sender, EventArgs e)
        {
            SearchForm f = new SearchForm();
            f.ShowDialog();
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            using (UserContext db = new UserContext(Settings.constr))
            {
                var instance = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == id);
                CalculationForm f = new CalculationForm(instance);
                f.MdiParent = this.MdiParent;
                f.Show();
            }
        }

        private void EditItem_Click(object sender, EventArgs e)
        {
            
        }

        

        private void DeleteItem_Click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            using (UserContext db = new UserContext(Settings.constr))
            {
                var instance = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == id);
                db.CalculationInsctInstances.Remove(instance);
               
                var pr = db.CalculatedProducts.Where(x => x.CalculationInstanceID == id).ToList();
                if (pr.Count > 0)
                {
                    db.CalculatedProducts.RemoveRange(pr);
                }
               
                db.SaveChanges();
            }
            Init();
        }

        private void CreateItem_Click(object sender, EventArgs e)
        {
            CalculationCreateForm f = new CalculationCreateForm(this);
            f.Show();
            f.Focus();
        }

        public void Init()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetCalculationInstances", conn);
                    cmd.CommandType = CommandType.StoredProcedure;

                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            grid.SetDataTable(ds.Tables[0]);
        }

        //public void CreateStatusMenu()
        //{
        //    using (UserContext db = new UserContext(Settings.constr))
        //    {
        //        var statuses = db.CalculationStatus.ToList();
        //        foreach (var i in statuses)
        //        {
        //            ToolStripMenuItem item = new ToolStripMenuItem();
        //            item.Text = i.StatusValue;
        //            item.Tag = i.ID;
        //            item.Click += status_click;
        //            изменитьСтатусToolStripMenuItem.DropDownItems.Add(item);

        //        }
        //    }
            
            
        //}

        private void status_click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            SetStatus(id, Convert.ToInt32((sender as ToolStripMenuItem).Tag));
        }

        private void SetStatus(int calcId, int status)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var calc = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == calcId);
                calc.Status = status;
                db.SaveChanges();
                Init();
            }
        }
    }
}
