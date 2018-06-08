using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore.Components
{
    public partial class LoadingForm : Form
    {
       // private Action _task;

        public LoadingForm()
        {
            InitializeComponent();
            progressBar1.Style = ProgressBarStyle.Marquee;
            progressBar1.MarqueeAnimationSpeed = 1000;
            this.ShowDialog();
            // _task = task;


        }

        public void StartTask()
        {
            
            //_task.BeginInvoke(Callback, null);
            //  
           
            //Invoke(() =>  Task.Run(_task));
             
           

        }

        private void Callback(IAsyncResult ar)
        {
            throw new NotImplementedException();
        }

        public void Cancel()
        {

           
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            Cancel();
        }
    }
}
