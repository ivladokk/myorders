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
using AppCore.Components.MasterPage;
using AppCore.Interfaces;
using AppCore.Models;
using AppCore.Settings;
using CalculationModule.UI.MasterPages;
using Offers.UI.MasterPage;
using DevExpress.Pdf.Native;
using DevExpress.XtraEditors;
using Offers;
using Offers.UI;

namespace Offers.UI
{
    public partial class OfferCreateForm : XtraForm
    {
        private Step _currentStep;
        private List<Step> _steps = new List<Step>();
        private OfferWorker _worker;

        private OfferInstance _instance;

        private Page1 page1;
        private Page2 page2;
        private Page3 page3;
        private Page4 page4;
        private Page5 page5 = new Page5();
        private Step step1;
        private Step step2;
        private Step step3;
        private Step step4;
        private Step step5;
        private IUpdForm _sender;
        private bool isCopmleted = false;
        private int type;
        public OfferCreateForm(IUpdForm sender)
        {
            InitializeComponent();
            page1 = new Page1(null);
            page2 = new Page2();
            _sender = sender;
            this.Focus();
            _worker = new OfferWorker();
            CreateSteps();
            _currentStep = _steps.FirstOrDefault(x => x.Prev == null);
            InitCurrentStep();
            type = 1;
        }

        public OfferCreateForm(IUpdForm sender, OfferWorker worker)
        {
            type = 2;
            _worker = worker ?? new OfferWorker();

            page1 = new Page1(_worker.offer);
            page2 = new Page2(_worker.GetHeader());
            InitializeComponent();
            _sender = sender;
            this.Focus();
            CreateSteps();
            _currentStep = _steps.FirstOrDefault(x => x.Prev == null);
            InitCurrentStep();
        }

        private void CreateSteps()
        {
            step1 = new Step
            {
                Control = page1,
                Prev = null,
                HasAction = true,
                isCompleted = false,
                DoAction = Action1,
                Header = "Шаг 1/4: Выберите клиента и введите название",
                isLast = false
            };
            
            step2 = new Step
            {
                Control = page2,
                Prev = step1,
                HasAction = true,
                isCompleted = false,
                DoAction = Action2,
                Header = "Шаг 2/4: Заполните значения",
                isLast = false
            };

           
            step5 = new Step
            {
                Control = page5,
                HasAction = false,
                Next = null,
                Prev = step4,
                Header = "Шаг 5/5: Завершение работы",
                isLast = true
            };

            step1.Next = step2;
            
            
            _steps.Add(step1);
            
        }

        private void Action1()
        {
            if (!page1.isValid())
            {
                MessageBox.Show("Выберите контрагента и валюту!");
                return;
            }

            _worker.CreateOffer(page1.GetOffer());
            page3 = new Page3(_worker.offer, _worker.GetItems());
            step3 = new Step
            {
                Control = page3,
                Prev = step2,
                HasAction = true,
                isCompleted = false,
                DoAction = Action3,
                Header = "Шаг 3/4: Выберите оборудование",
                isLast = false
            };
            step2.Next = step3;
            _steps.Add(step2);
            _steps.Add(step3);
            _currentStep.isCompleted = true;
        }

        private void Action2()
        {
            if (page2.IsValid())
            {
                var header = page2.GetHeader();
                header.OfferID = _worker.offer.ID;
                _worker.SetHeader(header);
                _currentStep.isCompleted = true;

            }
            else _currentStep.isCompleted = false;
        }

        private void Action3()
        {
            var items = page3.GetItems();
            if (items.Count>0)
            {
                _worker.FillItems(items);
               
                _currentStep.isCompleted = true;
                page4 = new Page4(_worker.GetFooter(), items);
                step4 = new Step
                {
                    Control = page4,
                    HasAction = true,
                    DoAction = Action4,
                    Next = step5,
                    Prev = step3,
                    Header = "Шаг 4/4: Заполните футер предложения",
                    isLast = false
                };
                step3.Next = step4;
                _steps.Add(step4);
                _steps.Add(step5);
            }
        }

        public void Action4()
        {
            var footer = page4.footer;
            footer.OfferID = _worker.offer.ID;
            _worker.SetFooter(footer);
            _currentStep.isCompleted = true;
           
        }
        
        private void InitCurrentStep()
        {
            label1.Text = _currentStep.Header;
            flowLayoutPanel1.Controls.Clear();
            flowLayoutPanel1.Controls.Add(_currentStep.Control);
            btn_finish.Enabled = _currentStep.isLast;
            btn_next.Enabled = !_currentStep.isLast;
            btn_prev.Enabled = _currentStep.Prev != null;
            
            
        }
        private void Next()
        {
            if (_currentStep.HasAction)
            {
                _currentStep.DoAction.Invoke();
            }

            if (_currentStep.isCompleted)
            {
                
                _currentStep = _currentStep.Next;
                InitCurrentStep();
            }
                
        }

        private void Prev()
        {
            _currentStep = _currentStep.Prev;
            InitCurrentStep();
        }

        private void btn_next_Click(object sender, EventArgs e)
        {
            Next();
        }

        private void btn_prev_Click(object sender, EventArgs e)
        {
            Prev();
        }

        private void btn_finish_Click(object sender, EventArgs e)
        {
            try
            {
                _worker.Save();
                if (page5.Print)
                    _worker.Print();
                isCopmleted = true;
                this.Close();
                _sender.Init();
            }
            catch (Exception exception)
            {
                MessageBox.Show(exception.Message);
            }
        }

        private void Clear()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                if (_worker.offer != null)
                {
                    var inst = db.Offers.FirstOrDefault(x => x.ID == _worker.offer.ID);
                    if (inst != null)
                    {
                        db.Offers.Remove(inst);
                        db.SaveChanges();
                    }

                }
            }
        }

        private void CalculationCreateForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!isCopmleted)
            {
                DialogResult dialogResult = MessageBox.Show("Вы уверены, что хотите прервать работу?", "Вы уверены", MessageBoxButtons.YesNo);
                if (dialogResult == DialogResult.Yes)
                {
                    if (type == 1)
                    {
                        Clear();
                    }
                    
                    e.Cancel = false;
                }
                else if (dialogResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }
    }

    
}
