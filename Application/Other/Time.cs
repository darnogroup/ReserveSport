using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Other
{
    public static class Time
    {
        public static string ToShamsi(this DateTime date)
        {
            PersianCalendar pc = new PersianCalendar();
            return pc.GetYear(date).ToString() + "/" + pc.GetMonth(date).ToString("00") + "/" +
                   pc.GetDayOfMonth(date).ToString("00");
        }

        public static string GetEnglishNumbers(this string s)
        {
            return s.Replace("۰", "0").Replace("۱", "1").Replace("۲", "2").Replace("۳", "3").Replace("۴", "4").Replace("۵", "5").Replace("۶", "6").Replace("۷", "7").Replace("۸", "8").Replace("۹", "9");
        }
        public static string GetPersianNumbers(this string s)
        {
            return s.Replace("0", "۰").Replace("1", "۱").Replace("2", "۲").Replace("3", "۳").Replace("4", "۴").Replace("5", "۵").Replace("6", "۶").Replace("7", "۷").Replace("8", "۸").Replace("9", "۹");
        }

        public static DateTime ToMiladiDateTime(this string ts)
        {
            var spliteDate = ts.GetEnglishNumbers().Split('/');

            int year = int.Parse(spliteDate[0]);
            int month = int.Parse(spliteDate[1]);
            int day = int.Parse(spliteDate[2]);
            DateTime currentDate = new DateTime(year, month, day, new PersianCalendar());
            return currentDate;
        }
        public static int Season(string month)
        {
            List<string> partOne = new List<string>();
            partOne.Add("01");
            partOne.Add("02");
            partOne.Add("03");
            partOne.Add("04");
            partOne.Add("05");
            partOne.Add("06");
            List<string> partTwo = new List<string>();
            partTwo.Add("07");
            partTwo.Add("08");
            partTwo.Add("09");
            partTwo.Add("10");
            partTwo.Add("11");
            List<string> partThree = new List<string>();
            partThree.Add("12");
            if (partOne.Any(a => a.Contains(month)))
            {
                return 31;
            }
            else if (partTwo.Any(a => a.Contains(month)))
            {
                return 30;
            }
            else
            {
                return 29;
            }
        }

        public static int Day(this string ts)
        {
            var convertDate = ts.GetEnglishNumbers().Split('/');
            int day = int.Parse(convertDate[2]);
            return day;
        }
        public static int Month(this string ts)
        {
            var convertDate = ts.GetEnglishNumbers().Split('/');
            int month = int.Parse(convertDate[1]);
            return month;
        }
        public static int Year(this string ts)
        {
            var convertDate = ts.GetEnglishNumbers().Split('/');
            int year = int.Parse(convertDate[0]);
            return year;
        }
        public static string YearMonth(this string ts, int c)
        {
            var convertDate = ts.GetEnglishNumbers().Split('/');

            int year = int.Parse(convertDate[0]);
            int month = int.Parse(convertDate[1]);
            var currentDate = year + "/" + month + "/" + c.ToString();
            return currentDate;
        }
        public static string JustYear( int year, int month, int day)
        {

            var currentDate = year + "/" + month + "/" + day;
            return currentDate;
        }
    }
}
