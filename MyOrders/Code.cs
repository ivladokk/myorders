using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;

namespace MyOrders
{
    class UserContext : DbContext
    {
        public UserContext(string nameOrConnectionString) :
            base(Settings.constr)
        {
            
        }
        
        public DbSet<Order> Orders { get; set; }
        public DbSet<Good> Goods { get; set; }
        public DbSet<Status> OrderStatuses { get; set; }
        public DbSet<ContrAgent> Contragents{ get; set; }
        public DbSet<Payment> Payments { get; set; } 
        public DbSet<CurrencyCode> CurrencyCodes { get; set; }
        public DbSet<Transaction> Transactions{ get; set; }
        public DbSet<BalanceOnDay> BalanceOnDays { get; set; }
        public DbSet<PaymentColor> PaymentColors { get; set; }
        public DbSet<WorkDay> WorkDays { get; set; }
        public DbSet<FuturePayment> FuturePayments { get; set; }
        public DbSet<Rate> Rates { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            Database.SetInitializer<UserContext>(null);

            base.OnModelCreating(modelBuilder);
        }

    }
    

    class CalendarSetting
    {
        public static List<DateTime> getDaysOfWeek(int Week)
        {


            


            List<DateTime> days = new List<DateTime>();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;
            Calendar cal = dfi.Calendar;

            DateTime firstday = FirstDateOfWeek(Settings.currentYear, Week, CultureInfo.CurrentCulture);

            if (firstday.DayOfWeek == DayOfWeek.Monday)
            {
                for (int i = 0; i < 7; i++)
                    days.Add(firstday.AddDays(i));
            }

            return days;
        }

        public static List<DateTime> getDaysOfTwoWeeks(int Week)
        {
            List<DateTime> days = new List<DateTime>();

            DateTimeFormatInfo dfi = DateTimeFormatInfo.CurrentInfo;

            Calendar cal = dfi.Calendar;

            DateTime firstday = FirstDateOfWeek(Settings.currentYear, Week, CultureInfo.GetCultureInfo("ru-RU"));

            if (firstday.DayOfWeek == DayOfWeek.Monday)
            {
                for (int i = 0; i < 14; i++)
                    days.Add(firstday.AddDays(i));
            }

            return days;
        }

        public static int GetWeekOfYear(DateTime time)
        {
            DayOfWeek day = CultureInfo.InvariantCulture.Calendar.GetDayOfWeek(time);
            if (day >= DayOfWeek.Monday && day <= DayOfWeek.Wednesday)
            {
                time = time.AddDays(3);
            }

            return CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(time, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
        }

        public static DateTime FirstDateOfWeek(int year, int weekOfYear, System.Globalization.CultureInfo ci)
        {
            DateTime jan1 = new DateTime(year, 1, 1);
            int daysOffset = (int)ci.DateTimeFormat.FirstDayOfWeek - (int)jan1.DayOfWeek;
            DateTime firstWeekDay = jan1.AddDays(daysOffset);
            int firstWeek = ci.Calendar.GetWeekOfYear(jan1, ci.DateTimeFormat.CalendarWeekRule, ci.DateTimeFormat.FirstDayOfWeek);
            if ((firstWeek <= 1 || firstWeek >= 52) && daysOffset >= -3)
            {
                weekOfYear -= 1;
            }
            return firstWeekDay.AddDays(weekOfYear * 7);
        }
    }
}
