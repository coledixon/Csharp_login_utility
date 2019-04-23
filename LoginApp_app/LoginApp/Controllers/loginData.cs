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
        loginDataObjects_tables tbls = new loginDataObjects_tables();

        // data conn
        static string dataconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region data select
        public DataTable Select(string where)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            try
            {
                tbls.User_Main.Select("WHERE first_name = " + where);
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
            finally { conn.Close(); } // close db connection


            return tbls.User_Main;
        }
        #endregion
    }
}
