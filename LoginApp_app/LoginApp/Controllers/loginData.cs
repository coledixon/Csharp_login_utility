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
        public DataTable Select(DataTable tbl, string filter)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            try
            {
                tbl.Select("WHERE first_name = " + filter);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); } // close db connection


            return tbl;
        }
        #endregion
    }
}
