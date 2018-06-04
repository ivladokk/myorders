using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore.Components.MasterPage
{
    public class Step
    {
        public Control Control { get; set; }
        public bool HasAction { get; set; }
        public Step Next { get; set; }
        public Step Prev { get; set; }
        public bool isCompleted;
        public string Header { get; set; }
        public bool isLast { get; set; }
        public Action DoAction;
    }
}
