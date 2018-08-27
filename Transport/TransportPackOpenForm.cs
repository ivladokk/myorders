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
using AppCore.Components;
using AppCore.Settings;

namespace Transport
{
    public partial class TransportPackOpenForm : Form
    {
        public MyGrid grid;
        public TransportPackOpenForm(int packId)
        {
            InitializeComponent();
            MyGridSettings settings = new MyGridSettings();
            settings.AutoSizeColums = true;
            settings.ContextMenuItems = new List<ToolStripMenuItem>();
            grid = new MyGrid(settings);
            grid.Dock = DockStyle.Fill;
            Controls.Add(grid);

            DataSet ds = new DataSet();
            try
            {

                using (SqlConnection conn = new SqlConnection(Settings.constr))
                {
                    SqlCommand cmd = new SqlCommand("GetTransportPackById", conn);
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.Add(new SqlParameter("@ID", SqlDbType.Int));
                    cmd.Parameters["@ID"].Value = packId;
                    SqlDataAdapter da = new SqlDataAdapter();
                    da.SelectCommand = cmd;
                    da.Fill(ds);
                    grid.SetDataTable(ds.Tables[0]);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
