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
        DataHelpers dthelpers = new DataHelpers();

        // data conn
        static string dataconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region data select
        public DataTable Select(DataTable obj, DataColumn whereCol, string whereVal)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            StringBuilder query = new StringBuilder("SELECT * FROM ");

            query.Append(" " + obj + " ");
            if (!string.IsNullOrEmpty(whereCol.ColumnName) && !string.IsNullOrEmpty(whereVal))
            {
                whereVal = dthelpers.IncludeSingleQuotes(true, whereVal);
                query.Append(" WHERE " + whereCol + " = " + whereVal);
            }

            try
            {
                SqlCommand cmd = new SqlCommand(query.ToString(), conn);
                SqlParameter param = new SqlParameter();
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                conn.Open();
                sda.Fill(obj);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); } // close db connection


            return obj;
        }

        //public DataTable Select(DataTable obj, DataColumn whereCol, string whereVal)
        //{
        //    SqlConnection conn = new SqlConnection(dataconnstrng);
        //    StringBuilder query = new StringBuilder("SELECT * FROM ");

        //    query.Append(" " + obj + " ");
        //    query.Append(" WHERE " + whereCol + " = '" + whereVal + "'");

        //    try
        //    {
        //        SqlCommand cmd = new SqlCommand(query.ToString(), conn);
        //        SqlParameter param = new SqlParameter();
        //        SqlDataAdapter sda = new SqlDataAdapter(cmd);
        //        conn.Open();
        //        sda.Fill(obj);
        //    }
        //    catch (Exception ex) { MessageBox.Show(ex.Message); }
        //    finally { conn.Close(); } // close db connection


        //    return obj;
        //}
        #endregion
    }

    public  class DataHelpers
    {
        public string IncludeSingleQuotes(bool include, string whereVal)
        {
            string ret = whereVal;
            if (include) { ret = "'" + whereVal + "'"; }

            return ret;

        }
    }
}
