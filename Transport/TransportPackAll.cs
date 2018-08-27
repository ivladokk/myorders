using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Components;
using AppCore.Interfaces;
using AppCore.Settings;

namespace Transport
{
    public partial class TransportPackAll : Form, IUpdForm
    {
        private MyGrid grid;
        public TransportPackAll()
        {
            InitializeComponent();
            MyGridSettings settings = new MyGridSettings();
            settings.ContextMenuItems = GetMenuItems();
            settings.AutoSizeColums = true;
            grid = new MyGrid(settings);
            grid.Dock = DockStyle.Fill;
            Controls.Add(grid);
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
                var statuses = db.TransportPackStatus.ToList();
                foreach (var i in statuses)
                {
                    ToolStripMenuItem item = new ToolStripMenuItem();
                    item.Text = i.StatusValue;
                    item.Tag = i.ID;
                    item.Click += status_click;
                    statusItem.DropDownItems.Add(item);

                }
            }



           /* ToolStripMenuItem editItem = new ToolStripMenuItem
            {
                Name = "editItem",
                Text = "Изменить"
            };
            editItem.Click += EditItem_Click;*/

            ret.Add(openItem);
            ret.Add(createItem);
            ret.Add(deleteItem);
            ret.Add(statusItem);
            //ret.Add(editItem);
            return ret;
        }

        private void CreateItem_Click(object sender, EventArgs e)
        {
            TransportPackCreateForm f = new TransportPackCreateForm(this);
            f.ShowDialog();
            f.Focus();
        }

        public void Init()
        {
            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetTransportPacks", conn);
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
        private void status_click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            SetStatus(id, Convert.ToInt32((sender as ToolStripMenuItem).Tag));
        }
        private void SetStatus(int packId, int status)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var pack = db.TransportPacks.FirstOrDefault(x => x.ID == packId);
                pack.Status = status;
                db.SaveChanges();
                Init();
            }
        }

        private void OpenItem_Click(object sender, EventArgs e)
        {
            var id = grid.GetSelectedID();
            if (id < 0) return;
            TransportPackOpenForm f = new TransportPackOpenForm(id)
            {
                MdiParent = this.MdiParent,
                WindowState = FormWindowState.Maximized
            };
            f.Show();

        }
        private void DeleteItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены?", "Удаление", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                var id = grid.GetSelectedID();
                if (id < 0) return;
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var pack = db.TransportPacks.FirstOrDefault(x => x.ID == id);
                    db.TransportPacks.Remove(pack);

                    var pr = db.TransportPackItems.Where(x => x.TransportPackID == id).ToList();
                    if (pr.Count > 0)
                    {
                        db.TransportPackItems.RemoveRange(pr);
                    }

                    db.SaveChanges();
                }
                Init();
            }

        }
    }
}
