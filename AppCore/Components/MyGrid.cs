using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore.Components
{
    public partial class MyGrid : UserControl
    {
        private MyGridSettings _settings;
        public MyGrid(MyGridSettings settings)
        {
            InitializeComponent();
            _settings = settings;
            CreateContextMenu();

        }

        private void CreateContextMenu()
        {
            if (_settings.ContextMenuItems.Count>0)
            contextMenuStrip1.Items.AddRange(_settings.ContextMenuItems.ToArray());
        }

        public void SetDataTable(DataTable dt)
        {
            gridControl1.DataSource = dt;
        }

        public int GetSelectedID()
        {
            if (gridView1.SelectedRowsCount > 0)
            {
                var current = gridView1.GetSelectedRows()[0];
                int id = Convert.ToInt32(gridView1.GetRowCellValue(current, "ID"));
                return id;
            }
            return -1;

        }
    }
}
