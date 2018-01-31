using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyOrders
{

    public partial class DictionaryForm : Form
    {
        public DictionaryForm()
        {
            InitializeComponent();




        }


        public void InitDictionary(string dicName)
        {
            using (UserContext db = new UserContext(Settings.constr))
            {
                var a = GetPropValue(db, dicName);

                var type = Type.GetType(dicName);

               
                //var c = a as System.Data.Entity.DbSet<>;




            }
        }


        public static object GetPropValue(object src, string propName)
        {
            return src.GetType().GetProperty(propName).GetValue(src, null);
        }

    }

    
    public class DictionaryData
    {

    }

    
}
