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

        // data connth
        static string dataconnstrng = ConfigurationManager.ConnectionStrings["connstrng"].ConnectionString;

        #region data select
        // base select
        public DataTable Select(DataTable obj)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            StringBuilder query = new StringBuilder("SELECT * FROM ");

            query.Append(obj);

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

        // filter select(s)
        public DataTable Select(DataTable obj, string firstName, string lastName)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            StringBuilder query = new StringBuilder("SELECT * FROM ");

            query.Append(obj);
            if (!string.IsNullOrEmpty(firstName) && !string.IsNullOrEmpty(lastName))
            {
                string where = "WHERE first_name = " + dthelpers.IncludeSingleQuotes(true, firstName)
                    + " AND " + dthelpers.IncludeSingleQuotes(true, lastName);
                query.Append(" " + where);
            }
            else { throw new Exception("first_name && last_name are required as parameters"); }

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

        public DataTable Select(DataTable obj, string userId)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            StringBuilder query = new StringBuilder("SELECT * FROM ");

            query.Append(obj);
            if (!string.IsNullOrEmpty(userId))
            {
                string where = "WHERE user_id = " + dthelpers.IncludeSingleQuotes(true, userId);
                query.Append(" " + where);
            }
            else { throw new Exception("user_id required as parameter"); }

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
        #endregion

        #region data insert
        // insert new user
        public bool Insert(string userId, string firstName, string lastName, string pass)
        {
            bool isSuccess = false; // assume failure
            SqlConnection conn = new SqlConnection(dataconnstrng);
            int retval; string errmess;

            try
            {
                SqlCommand cmd = new SqlCommand("spcreateUser", conn) { CommandType = CommandType.StoredProcedure };
                // input(s)
                cmd.Parameters.AddWithValue("@user_id", userId);
                cmd.Parameters.AddWithValue("@first_name", firstName);
                cmd.Parameters.AddWithValue("@last_name", lastName);
                cmd.Parameters.AddWithValue("@password", pass);
                 // output(s)
                cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@errmess", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;

                conn.Open(); // open db connection
                cmd.ExecuteNonQuery(); // exec proc

                // capture output(s)
                retval = Convert.ToInt32(cmd.Parameters["@retval"].Value);
                errmess = cmd.Parameters["@errmess"].Value.ToString();

                isSuccess = (retval > 0) ? true : false;
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); isSuccess = false; }
            finally { conn.Close(); }

            return isSuccess;
        }
        #endregion

        #region data create
        public bool CreateSession()
        {
            // create SQL login session via spcreateSession
            return false;
        }
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
