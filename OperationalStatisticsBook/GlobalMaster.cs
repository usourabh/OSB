using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationalStatisticsBook
{
    public static class GlobalMaster
    {
        public static List<FinMasterInfo> FinMaster = new List<FinMasterInfo>();

        public static List<KeyValueMaster> MonthMaster = new List<KeyValueMaster>() {
            new KeyValueMaster {Key=1,Value="January" },
            new KeyValueMaster { Key = 2, Value = "February" },
            new KeyValueMaster {Key=3,Value="March" },
            new KeyValueMaster { Key = 4, Value = "April" },
            new KeyValueMaster {Key=5,Value="May" },
            new KeyValueMaster { Key = 6, Value = "June" },
            new KeyValueMaster {Key=7,Value="July" },
            new KeyValueMaster { Key = 8, Value = "August" },
            new KeyValueMaster {Key=9,Value="September" },
            new KeyValueMaster { Key = 10, Value = "October" },
            new KeyValueMaster {Key=11,Value="November" },
            new KeyValueMaster { Key = 12, Value = "December" }
        };
        public static int GetMonthNumber(string MonthName)
        {
            return DateTimeFormatInfo.CurrentInfo.MonthNames.ToList().IndexOf(MonthName) + 1;
        }

        public static KeyValueMaster GetPreviousMonth(int CurrentMonth)
        {

            if (CurrentMonth == 1)
                return GlobalMaster.MonthMaster[11];
            else
                return GlobalMaster.MonthMaster[CurrentMonth - 2];
        }
        public static List<DateInfo> GetPrevousMonthList(int CurrentMonth, int Year,int NoOfPrevousMonth)
        {
            NoOfPrevousMonth = NoOfPrevousMonth * -1;
            List<DateInfo> lst = new List<DateInfo>();
            DateTime CurrentDate = new DateTime(Year, CurrentMonth, 1);
            DateTime tmp = CurrentDate.AddMonths(NoOfPrevousMonth);

            while(CurrentDate!= tmp)
            {
                DateInfo obj = new DateInfo();
                obj.Year = CurrentDate.Year;
                obj.MonthName = String.Format("{0:MMMM}", CurrentDate);
                obj.StartDate = CurrentDate;
                obj.EndDate = CurrentDate.AddMonths(1).AddDays(-1);
                obj.MonthId = CurrentDate.Month;
                lst.Add(obj);
                CurrentDate = CurrentDate.AddMonths(-1);
            }
            return lst;
        }



    }

    public class KeyValueMaster
    {
        public int Key { get; set; }
        public string Value { get; set; }
    }

    public class DateInfo
    {
        public int MonthId { get; set; }
        public string MonthName { get; set; }
        public int Year { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }




}
