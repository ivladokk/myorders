using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AppCore.Components.MasterPage
{
    public class MasterPageItem
    {
        public bool isFirst;
        public bool isLast;
        public Control ItemContent { get; set; }
        public MasterPageItem NextItem;
        public MasterPageItem PreviousItem;

        public bool isNextAvaible { get; set; }

    }
}
