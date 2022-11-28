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
        public static Decimal ConvertToDecimal(string value)
        {
            decimal tmp = 0;

            try
            {
                tmp = Decimal.Parse(value);
            }
            catch
            {
                tmp = 0;
            }
            return tmp;
        }

        public static decimal GetSum(System.Windows.Forms.DataGridViewRowCollection rows, int fromRow, int ToRows, int SumColumnIndex)
        {
            decimal Sum = 0;
            try
            {


                for (int i = fromRow; i <= ToRows; i++)
                {
                    Sum += Common.ConvertToDecimal(rows[i].Cells[SumColumnIndex].Value.ToString());
                }
            }
            catch (Exception ex)
            {

            }
            return Sum;
        }


        public static void SetRowNonEditable(System.Windows.Forms.DataGridView dataGridView1, int RowIndex)
        {
            dataGridView1.Rows[RowIndex].ReadOnly = true;
            dataGridView1.Rows[RowIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
        }

        public static void SetColumnNonEditable(System.Windows.Forms.DataGridView dataGridView1, int ColunIndex)
        {
            dataGridView1.Columns[ColunIndex].ReadOnly = true;
            dataGridView1.Columns[ColunIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;
        }

        public static void SetColumnNonEditable(System.Windows.Forms.DataGridView dataGridView1, int ColunIndex, int exceptForRows)
        {
            dataGridView1.Columns[ColunIndex].ReadOnly = true;
            dataGridView1.Columns[ColunIndex].DefaultCellStyle.BackColor = System.Drawing.Color.LightGray;

            if (exceptForRows != -1)
            {
                dataGridView1.Rows[exceptForRows].Cells[ColunIndex].ReadOnly = false;
                dataGridView1.Rows[exceptForRows].Cells[ColunIndex].Style.BackColor = System.Drawing.Color.White;
            }
        }

        public static void SetCELLumnNonEditable(System.Windows.Forms.DataGridView dataGridView1, int ColunIndex, int RowIndex)
        {
            dataGridView1.Rows[RowIndex].Cells[ColunIndex].ReadOnly = true;
            dataGridView1.Rows[RowIndex].Cells[ColunIndex].Style.BackColor = System.Drawing.Color.LightGray;
        }

    }
}
