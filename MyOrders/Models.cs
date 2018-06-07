using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MyOrders
{
    public static class Settings
    {

        
        


        public static string constr = System.IO.File.ReadAllText("dbconfig.txt");//@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=d:\Projects\MyOrders\MyOrders\GoodsDB.mdf;Integrated Security=True";
        public static int currentYear = Convert.ToInt32(getSettingValue("currentYear"));

        public static int maxWidth = Convert.ToInt32(getSettingValue("maxWidth"));
        public static int maxHeight = Convert.ToInt32(getSettingValue("maxHeight"));
        public static int maxLenght = Convert.ToInt32(getSettingValue("maxLenght"));

        public static double realSize = Convert.ToInt32(getSettingValue("realSize"));
        public static double pxSize = Convert.ToInt32(getSettingValue("pxSize"));

        public static double scale = pxSize / realSize;

        public static bool isShowWeekends = Convert.ToBoolean(getSettingValue("isShowWeekends"));

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
    public class Order
    {
        public int ID { get; set; }
        public DateTime AddDate { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime ControlDate { get; set; }
        public string Provider { get; set; }
        public int AcceptNum { get; set; }
        public int Status { get; set; }
        public int PlaceCount { get; set; }
        public int? ContrAgentID { get; set; }
        public string NumberKP { get; set; }
        public int? ProviderID { get; set; }
    }

    public class Good
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public int Lenght { get; set; }
        public int Weight { get; set; }
        public string Comments { get; set; }
    }

    public class Status
    {
        public int StatusID { get; set; }
        public string StatusValue { get; set; }
        public string StatusColor { get; set; }
        
    }



    public class ContrAgent
    {
        public int ContrAgentID { get; set; }
        public string Name { get; set; }
        public string NameEng { get; set; }
        public string Address { get; set; }
       // public List<ItemParam> AddParams { get; set; }

    }

    public class ItemParam
    {
        public int ParamType { get; set; }
        public object ParamValue { get; set; }
    }


    public class CurrencyCode
    {
        [Key]
        public int CurrencyID { get; set; }
        public int Code { get; set; }
        public string CurrencyName { get; set; }
    }


    public class Payment
    {
        public int ID { get; set; }
        public decimal Sum { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ContrAgentID { get; set; }
        public int PaymentStatus { get; set; }
        public int TransactionID { get; set; }
        public int PaymentType { get; set; }
        public string Comments { get; set; }
        public int PaymentCurrencyCode { get; set; }
        public string CreditNum { get; set; }
        public string Acc { get; set; }
        public DateTime ControlDate { get; set; }
        public int ColorID { get; set; }
    }
    public class FuturePayment
    {
        public int ID { get; set; }
        public decimal Sum { get; set; }
        public DateTime CreateDate { get; set; }
        public int ContrAgentID { get; set; }
        public int PaymentType { get; set; }
        public string Comments { get; set; }
        public int PaymentCurrencyCode { get; set; }
        public string CreditNum { get; set; }
        public string Acc { get; set; }
        public int ColorID { get; set; }
        //public int PaymentID { get; set; }
    }

    public class PaymentStatus
    {
        public int PaymentStatusID { get; set; }
        public string PaymentStatusValue { get; set; }
    }

    public class Transaction
    {
        public int ID { get; set; }
        public decimal Sum { get; set; }
        public DateTime TransactionDate { get; set; }
        public int PaymentID { get; set; }
        public int TransactionCurrencyCode { get; set; }
        
    }

    public class Balance
    {
        public int ID { get; set; }
        public int BalanceCurrency { get; set; }
        public decimal TotalSum { get; set; }

    }

    public class PaymentColor
    {
        public int ID { get; set; }
        public string Color { get; set; }
        public string Value { get; set; }
        public string ColorRus { get; set; }
    }
    public class BalanceOnDay
    {
        public int ID { get; set; }
        public int WorkDayID { get; set; }
        public int CurrencyID { get; set; }
        public decimal StartAmount { get; set; }
        public decimal CurrentAmount { get; set; }
    }
    public class WorkDay
    {
        public int WorkDayID { get; set; }
        public DateTime WorkDayDate { get; set; }
        public int isLast { get; set; }
    }

    public class Rate
    {
        public int ID { get; set; }
        public int FromCurID { get; set; }
        public int ToCurID { get; set; }
        public double RateValue { get; set; }
        public int Scale { get; set; }
        public int WorkDayID { get; set; }
        public DateTime RateDate { get; set; }

    }

}
