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
        // filter select
        public DataTable Select(DataTable obj, DataColumn whereCol, string whereVal)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            StringBuilder query = new StringBuilder("SELECT * FROM ");

            query.Append(obj);
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

        // general 'SELECT *'
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

        // user/pass select
        public DataTable Select(DataTable obj, string userId, string passHash)
        {
            SqlConnection conn = new SqlConnection(dataconnstrng);
            StringBuilder query = new StringBuilder("SELECT * FROM ");

            query.Append(obj);
            if (!string.IsNullOrEmpty(userId) && !string.IsNullOrEmpty(passHash))
            {
                string where = " user_id = " + dthelpers.IncludeSingleQuotes(true, userId)
                    + " AND pass_hash =" + dthelpers.IncludeSingleQuotes(true, passHash);
                query.Append(" " + where);
            }
            else { throw new Exception("user_id && pass required"); }

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
                cmd.Parameters.AddWithValue("first_name", firstName);
                cmd.Parameters.AddWithValue("last_name", lastName);
                cmd.Parameters.AddWithValue("password", pass);
                 // output(s)
                cmd.Parameters.Add("@retval", SqlDbType.Int).Direction = ParameterDirection.Output;
                cmd.Parameters.Add("@errmess", SqlDbType.VarChar, 250).Direction = ParameterDirection.Output;

                conn.Open(); // open db connection
                cmd.ExecuteNonQuery(); // exec proc

                // capture output(s)
                retval = Convert.ToInt32(cmd.Parameters["@retval"].Value);
                errmess = cmd.Parameters["@errmess"].Value.ToString();

                isSuccess = true;
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
