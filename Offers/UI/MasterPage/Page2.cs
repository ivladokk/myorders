using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
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

namespace Offers.UI.MasterPage
{
    public partial class Page2 : UserControl
    {
        public string OfferNumber { get; set; }
        public string Subject { get; set; }
        public string SubjectRus { get; set; }
        public int ManufacterID { get; set; }
        public string HeaderText { get; set; }
        public string HeaderTextRus { get; set; }

        private OfferHeader _headerEditModel { get; set; }

        public Page2()
        {
            InitializeComponent();
            LoadManufacters();
            tb_num.DataBindings.Add("Text", this, "OfferNumber");
            tb_subject.DataBindings.Add("Text", this, "Subject");
            tb_subject_rus.DataBindings.Add("Text", this, "SubjectRus");
            cb_manufacter.DataBindings.Add("SelectedValue", this, "ManufacterID");
            tb_text.DataBindings.Add("Text", this, "HeaderText");
            tb_text_rus.DataBindings.Add("Text", this, "HeaderTextRus");

        }

        public Page2(OfferHeader header)
        {
            InitializeComponent();
            _headerEditModel = header;
            LoadManufacters();
            tb_num.DataBindings.Add("Text", _headerEditModel, "OfferNumber");
            tb_subject.DataBindings.Add("Text", _headerEditModel, "Subject");
            tb_subject_rus.DataBindings.Add("Text", _headerEditModel, "SubjectRus");
            cb_manufacter.DataBindings.Add("SelectedValue", _headerEditModel, "ManufacterID");
            tb_text.DataBindings.Add("Text", _headerEditModel, "HeaderText");
            tb_text_rus.DataBindings.Add("Text", _headerEditModel, "HeaderTextRus");

        }

        public OfferHeader GetHeader()
        {
            return new OfferHeader
            {
                OfferNumber = OfferNumber,
                SubjectRus = SubjectRus,
                Subject = Subject,
                ManufacterID = ManufacterID,
                HeaderText = HeaderText,
                HeaderTextRus = HeaderTextRus
            };
        }
        public void LoadManufacters()
        {
            BindingList<Manufacter> manufacterDS = new BindingList<Manufacter>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Manufacters)
                {
                    manufacterDS.Add(i);
                }
            }

            cb_manufacter.DisplayMember = "NameRus";
            cb_manufacter.ValueMember = "ID";
            cb_manufacter.DataSource = manufacterDS;
        }

        public bool IsValid()
        {
            return true;
        }

    }

}
