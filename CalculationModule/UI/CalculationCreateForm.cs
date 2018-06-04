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
using AppCore.Settings;
using CalculationModule.UI.MasterPages;
using DevExpress.Pdf.Native;
using DevExpress.XtraEditors;

namespace CalculationModule.UI
{


    public partial class CalculationCreateForm : XtraForm
    {
        private Step _currentStep;
        private List<Step> _steps = new List<Step>();
        private CalculationWorker _worker;

        private Page1 page1 = new Page1();
        private Page2 page2 = new Page2();
        private Page3 page3;
        private Page4 page4;
        private Step step1;
        private Step step2;
        private Step step3;
        private Step step4;
        private CalculationMain _sender;
        private bool isCopmleted = false;
        public CalculationCreateForm(CalculationMain sender)
        {
            InitializeComponent();
            _sender = sender;
            this.Focus();
            _worker = new CalculationWorker();
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
                Header = "Шаг 1/4: Выберите тип и введите название",
                isLast = false
            };
            
            step2 = new Step
            {
                Control = page2,
                Prev = step1,
                HasAction = true,
                isCompleted = false,
                DoAction = Action2,
                Header = "Шаг 2/4: Импорт товаров",
                isLast = false
            };
            
            step1.Next = step2;
            
            
            _steps.Add(step1);
            
        }

        private void Action1()
        {
            if (page1.ContrAgentID == 0)
            {
                MessageBox.Show("Выберите контрагента");
                return;
            }
            _worker.CreateInstance(page1.SelectedTypeID, page1.CalcName, page1.ContrAgentID);
            page3 = new Page3(_worker.calculationInstance);
            step3 = new Step
            {
                Control = page3,
                Prev = step2,
                HasAction = true,
                isCompleted = false,
                DoAction = Action3,
                Header = "Шаг 3/4: Заполните значения",
                isLast = false
            };
            step2.Next = step3;
            _steps.Add(step2);
            _steps.Add(step3);
            _currentStep.isCompleted = true;
        }
        private void Action2()
        {
            if (page2.dt != null)
            {
                _worker.ImportProducts(page2.dt);
                _currentStep.isCompleted = true;
            }
            else _currentStep.isCompleted = false;
        }

        private void Action3()
        {
            if (page3.ManualConstants != null)
            {
                _worker.FillConstants(page3.ManualConstants);
                _worker.ProcessNew();
                _currentStep.isCompleted = true;
                page4 = new Page4(_worker.GetDataTable());
                step4 = new Step
                {
                    Control = page4,
                    HasAction = false,
                    Next = null,
                    Prev = step3,
                    Header = "Шаг 4/4: Предварительный просмотр калькуляции",
                    isLast = true
                };
                step3.Next = step4;
                _steps.Add(step4);
            }
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
            isCopmleted = true;
            _worker.SaveResults();
            _sender.Load();
            this.Close();
        }

        private void Clear()
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                if (_worker.calculationInstance != null)
                {
                    var inst = db.CalculationInsctInstances.FirstOrDefault(x => x.ID == _worker.calculationInstance.ID);
                    if (inst != null)
                    {
                        db.CalculationInsctInstances.Remove(inst);
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
                    Clear();
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
