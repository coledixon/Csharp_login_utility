using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp.Controllers
{
    class loginData
    {
        // INSTANTIATE CLASS(ES)
        loginProps props = new loginProps();

        // data conn
        static string dataconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region data select
        public DataTable Select(DataTable tbl, string col, string filter)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            string query = (DataHelpers.EvalQueryType(1) + 
                tbl + " WHERE " + col + "=" + filter);
            try
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                SqlParameter param = new SqlParameter();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                conn.Open();
                sda.Fill(tbl);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); } // close db connection


            return tbl;
        }
        #endregion
    }

    static class DataHelpers
    {
        //public static string CompileSqlQuery(int queryType, string tbl, List<string> cols, string filter)
        //{
        //    string q;

        //    return q;
        //}

        public static string EvalQueryType(int type)
        {
            string ret;

            if (string.IsNullOrEmpty(type.ToString())) { return ret = null; }

            switch (type)
            {
                case 1: ret = "SELECT * FROM ";
                    break;
                case 2: ret = "INSERT INTO ";
                    break;
                case 3: ret = "UPDATE ";
                    break;
                case 4: ret = "DELETE FROM ";
                    break;
                default: ret = "SELECT * FROM ";
                    break;
            }

            return ret;
        }
    }
}
