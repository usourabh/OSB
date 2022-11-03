using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationalStatisticsBook
{
  public  class AllPageDataContext
    {
        public DataTable GetIndexPageData_Page1(int OsbId)
        {
            String[,] param = new string[,]
                   {
                   {"@OsbId",OsbId.ToString()},
                };
            DataTable dt = Common.ExecuteProcedure("GetAllrptIndexPrintPage", param);
            return dt;
        }
    }
}
