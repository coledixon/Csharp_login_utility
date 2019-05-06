using LoginApp.Models;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LoginApp.Controllers
{
    class loginInitSchema
    {
        loginDataObjects_tables t = new loginDataObjects_tables();

        #region table data objects
        public void InitTable_UserMain()
        {
            DataTable _user_main;
            try
            {
                _user_main = new DataTable("user_main");

                _user_main.Columns.Add("user_key", typeof(int));
                _user_main.Columns.Add("user_id", typeof(string));
                _user_main.Columns.Add("first_name", typeof(string));
                _user_main.Columns.Add("last_name", typeof(string));
                _user_main.Columns.Add("create_date", typeof(DateTime));

                _user_main.PrimaryKey = new DataColumn[] { _user_main.Columns["user_key"] };

                DataSet userData = new DataSet();
                userData.Tables.Add(_user_main);

            }
            catch (Exception ex) { MessageBox.Show("Failure initializing user_main :: loginDataObjects_tables"); return; }
        }

        public DataTable InitTable_PassMain()
        {
            DataTable _pass_main;
            try
            {
                _pass_main = new DataTable();

                _pass_main.Columns.Add("user_key", typeof(int));
                _pass_main.Columns.Add("pass_hash", typeof(string));
                _pass_main.Columns.Add("pass_salt", typeof(string));

            }
            catch (Exception ex) { MessageBox.Show("Failure initializing pass_main :: loginDataObjects_tables"); return _pass_main = null; }

            return _pass_main;
        }
        #endregion
    }
}
