using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.Globalization;
using System.Windows.Forms;
using AppCore;
using AppCore.Models;
using AppCore.Settings;

namespace MyOrders
{
    public static class Launcher
    {
        public static void StartApp()
        {
            if (!String.IsNullOrEmpty(Settings.constr))
            {
                Application.Run(new Form1());
            }
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
