using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dropbox.Api;
namespace Loader
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (var dbx = new DropboxClient("kxfB_FHXHQAAAAAAAAAACRuNdmaBEpWhY83Yed64OxkEuXXHLKfpEaMkxG5Rsnlc"))
            {
                var list = dbx.Files.ListFolderAsync("/test").Result;
                var res = dbx.Files.DownloadZipAsync("/test").Result;

            }
        }
    }
}
