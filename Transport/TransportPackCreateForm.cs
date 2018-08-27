using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;
using DevExpress.Data;
using DevExpress.Utils;
using DevExpress.XtraEditors.Repository;
using DevExpress.XtraGrid;
using DevExpress.XtraGrid.Columns;
using DevExpress.XtraGrid.Views.Grid;

namespace Transport
{
    public partial class TransportPackCreateForm : Form
    {
        GridControl grid;
        GridView view;
        GridView detailView;
        GridLevelNode detailNode;

        public int ContrAgentFrom { get; set; }
        public int ContrAgentTo { get; set; }
        public int Item { get; set; }
        public int CalculationType { get; set; }
        public string PackName { get; set; }

        private int _mode;
        private int _packID;
        private TransportPackAll _sender;
        public List<CalculationInstance> GetInstances()
        {
            List<CalculationInstance> ret = new List<CalculationInstance>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                ret = db.CalculationInsctInstances.Where(x =>
                    x.CalculationTypeID == CalculationType && x.ContrAgentID == ContrAgentFrom &&
                    x.ContrAgentID2 == ContrAgentTo).ToList();
            }
            return ret;
        }

        public TransportPackCreateForm(int packID)
        {
            _mode = 2;
            _packID = packID;
        }

        public TransportPackCreateForm(TransportPackAll sender)
        {

            InitializeComponent();
            _sender = sender;
            _mode = 1;
            _packID = -1;
            LoadTypes();
            LoadAgents();
            //LoadCalculationItems();
            InitializeGrid();
            tb_name.DataBindings.Add("Text", this, "PackName");

        }
        private void InitializeGrid()
        {
            grid = new GridControl();
            view = new GridView(grid);
            detailView = new GridView(grid);
            detailView.OptionsSelection.MultiSelect = true;
            detailView.OptionsSelection.MultiSelectMode = GridMultiSelectMode.CheckBoxRowSelect;
            detailView.OptionsSelection.ShowCheckBoxSelectorInColumnHeader = DefaultBoolean.True;
            
            detailNode = grid.LevelTree.Nodes.Add("SuppliersProducts", detailView);
            grid.Dock = DockStyle.Fill;
            this.panel1.Controls.Add(grid);
        }

        private void LoadAgents()
        {
            BindingList<ContrAgent> Contragents = new BindingList<ContrAgent>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Contragents.ToList())
                {
                    Contragents.Add(i);
                }
            }
            BindingList<ContrAgent> Contragents2 = new BindingList<ContrAgent>();

            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.Contragents.ToList())
                {
                    Contragents2.Add(i);
                }
            }


            cb_contragent_from.DisplayMember = "Name";
            cb_contragent_from.ValueMember = "ContrAgentID";
            cb_contragent_from.DataSource = Contragents;
            cb_contragent_from.DataBindings.Add("SelectedValue", this, "ContrAgentFrom");
            //ContrAgentID = (int) cb_Contragent.EditValue;
           

            cb_contragent_to.DisplayMember = "Name";
            cb_contragent_to.ValueMember = "ContrAgentID";
            cb_contragent_to.DataSource = Contragents2;
            cb_contragent_to.DataBindings.Add("SelectedValue", this, "ContrAgentTo");
        }

        private void LoadTypes()
        {
            List<CalculationType> typesDS = new List<CalculationType>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                foreach (var i in db.CalculationTypes.ToList())
                {
                    typesDS.Add(i);
                }
            }
            cb_calc_type.DisplayMember = "Name";
            cb_calc_type.ValueMember = "ID";
            cb_calc_type.DataSource = typesDS;
            cb_calc_type.DataBindings.Add("SelectedValue", this, "CalculationType");
        }

        private bool itemsLoaded = false;
        private void LoadCalculationItems()
        {
            List<CalculationItem> itemsDS = new List<CalculationItem>();
            using (UserContext db = new UserContext(Settings.constr))
            {
                var list = db.CalculationItems.Where(x => x.CalculationTypeID == CalculationType).ToList();
                foreach (var i in list)
                {
                    itemsDS.Add(i);
                }
            }
            cb_item.DisplayMember = "ItemName";
            cb_item.ValueMember = "ID";
            cb_item.DataSource = itemsDS;
            if (!itemsLoaded)
                cb_item.DataBindings.Add("SelectedValue", this, "Item");
        }

        public void InitGrid()
        {
            if (view != null && detailView != null)
            {
                
                view.Columns.AddField("InstanceID").VisibleIndex = 0;
                view.Columns.AddField("Name").VisibleIndex = 1;

                var col = detailView.Columns.AddField("Checked");
                col.Caption = "Выбрать";
                col.VisibleIndex = 0;
                col.OptionsColumn.AllowEdit = true;
                col.ColumnEdit = new RepositoryItemCheckEdit();

                var col2 = detailView.Columns.AddField("VendorCode");
                col2.Caption = "Артикул";
                col2.VisibleIndex = 1;
                col2.OptionsColumn.AllowEdit = false;
                var col3 = detailView.Columns.AddField("Name");
                col3.Caption = "Наименование";
                col3.VisibleIndex = 2;
                col3.OptionsColumn.AllowEdit = false;
                var col4 = detailView.Columns.AddField("Count");
                col4.Caption = "Кол-во";
                col4.VisibleIndex = 3;
                col4.OptionsColumn.AllowEdit = false;
                var col5 = detailView.Columns.AddField("TotalValue");
                col5.Caption = "Итог";
                col5.VisibleIndex = 4;
                col5.OptionsColumn.AllowEdit = false;
                var col6 = detailView.Columns.AddField("Instance");
                col6.VisibleIndex = 5;
                col6.OptionsColumn.AllowEdit = false;
            }
        }

        public List<CalculatedProductView> allProducts = new List<CalculatedProductView>();
        private void InitDS()
        {
            List<CalculationInstanceDetail> details = new List<CalculationInstanceDetail>();
            var instances = GetInstances();
            foreach (var i in instances)
            {
                using (UserContext db = new UserContext(Settings.constr))
                {
                    var products = db.CalculatedProducts.Where(x => x.CalculationInstanceID == i.ID).ToList();
                    var productsView = new List<CalculatedProductView>();
                    foreach (var pr in products)
                    {

                        var totalValue =
                            db.CalculatedItems.FirstOrDefault(x => x.CalculatedProductID == pr.ID && x.ItemID == Item);
                        productsView.Add(new CalculatedProductView
                        {
                            ID = pr.ID,
                            Instance = pr.CalculationInstanceID,
                            VendorCode = pr.VendorCode,
                            Count = pr.Count,
                            Name = pr.ProductName,
                            Checked = false,
                            TotalValue = totalValue != null ? totalValue.Value : 0
                        });
                    }
                    allProducts.AddRange(productsView);
                    CalculationInstanceDetail detail = new CalculationInstanceDetail
                    {
                        InstanceID = i.ID,
                        Products = productsView,
                        Name = i.Name
                    };
                    details.Add(detail);

                }
                grid.DataSource = details;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ContrAgentFrom == 0 || ContrAgentTo == 0)
            {
                MessageBox.Show("Выберите контрагентов!");
                return;
            }

            if (CalculationType == 0)
            {
                MessageBox.Show("Выберите тип калькуляции!");
                return;
            }

            if (Item == 0)
            {
                MessageBox.Show("Выберите итоговый элемент!");
                return;
            }
            InitGrid();
            InitDS();
        }

        private void btn_save_Click(object sender, EventArgs e)
        {
            TransportWorker worker = new TransportWorker();
            worker.CreatePack(PackName, ContrAgentFrom, ContrAgentTo, Item);
            var packItems = new List<TransportPackItem>();
            foreach (var i in allProducts.Where(x=>x.Checked))
            {
                packItems.Add(new TransportPackItem
                {
                    CalculatedProductID = i.ID,
                    TotalValue = i.TotalValue
                });
            }
            worker.SetItems(packItems);
            worker.SavePack();
            _sender.Init();
            this.Close();
        }

        private void cb_calc_type_SelectedValueChanged(object sender, EventArgs e)
        {
            if (cb_calc_type.SelectedValue!=null)
                CalculationType = (int) cb_calc_type.SelectedValue;
            if (CalculationType != 0)
            {
                LoadCalculationItems();
                itemsLoaded = true;
            }
            
        }
    }


    public class CalculationInstanceDetail
    {
        private List<CalculatedProductView> products = new List<CalculatedProductView>();
        public int InstanceID { get; set; }
        public string Name { get; set; }
        public List<CalculatedProductView> Products
        {
            get
            {
                return products;
            }
            set
            {
                products = value;
            }
        }
    }

    public class CalculatedProductView
    {
        public bool Checked { get; set; }
        public int ID { get; set; }
        public string Name { get; set; }
        public string VendorCode { get; set; }
        public int Count { get; set; }
        public decimal TotalValue { get; set; }
        public int Instance { get; set; }
        
    }

    
}
