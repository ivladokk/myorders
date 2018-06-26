using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using AppCore.Settings;
using DevExpress.UserSkins;
using DevExpress.Skins;
using DevExpress.LookAndFeel;

namespace MyOrders
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        public static void Main(string[] args)
        {
            string constr = "";
            foreach (var i in args)
            {
                constr += i;
                constr += " ";
            }

            Settings.SetConstr(constr.Trim());
 
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            BonusSkins.Register();
            SkinManager.EnableFormSkins();
            UserLookAndFeel.Default.SetSkinStyle("DevExpress Style");
            Application.Run(new Form1());
        }
    }
}
