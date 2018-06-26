using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AppCore.Settings
{
    public static class Settings
    {
        public static string constr = "";//System.IO.File.ReadAllText("dbconfig.txt");//@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Projects\MyOrders\MyOrders\GoodsDB.mdf;Integrated Security=True";
        public static int currentYear = Convert.ToInt32(getSettingValue("currentYear"));
        public static string AppName = "";
        public static int maxWidth = Convert.ToInt32(getSettingValue("maxWidth"));
        public static int maxHeight = Convert.ToInt32(getSettingValue("maxHeight"));
        public static int maxLenght = Convert.ToInt32(getSettingValue("maxLenght"));

        public static double realSize = Convert.ToInt32(getSettingValue("realSize"));
        public static double pxSize = Convert.ToInt32(getSettingValue("pxSize"));

        public static double scale = pxSize / realSize;

        public static bool isShowWeekends = Convert.ToBoolean(getSettingValue("isShowWeekends"));

        public static void SetConstr(string str)
        {
            constr = str;
        }

        public static void SetAppName(string str)
        {
            AppName = str;
        }
        public static int ConvertSizeToPx(int size)
        {
            return Convert.ToInt32(size * scale);
        }



        public static object getSettingValue(string setting)
        {
            var settingsXml = new XmlDocument();
            settingsXml.Load(@"settings.xml");
            return settingsXml["root"][setting].InnerText;

        }

    }
}
