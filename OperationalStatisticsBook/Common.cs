using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OperationalStatisticsBook
{
    class Common
    {
        public static DataTable ExecuteProcedure(String ProcName, string[,] Param)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ToString());
            SqlCommand cmd = new SqlCommand(ProcName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            for (int i = 0; i < Param.Length / 2; i++)
            {
                cmd.Parameters.AddWithValue(Param[i, 0], Param[i, 1]);
            }
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }
        public static DataTable ExecuteProcedure(string ProcName)
        {
            SqlConnection con = new SqlConnection(ConfigurationManager.ConnectionStrings["dtOperation"].ToString());
            SqlCommand cmd = new SqlCommand(ProcName, con);
            cmd.CommandType = CommandType.StoredProcedure;
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            return dt;
        }

    }
}
