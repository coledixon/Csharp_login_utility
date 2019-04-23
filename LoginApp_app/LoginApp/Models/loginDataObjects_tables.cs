using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;
using System.Windows.Forms;

namespace LoginApp.Models
{
    class loginDataObjects_tables
    {
        #region public datatable(s)
        // create data objects based on SQL schema
        public DataTable User_main
        {
            get { return User_main = InitTable_UserMain(); }
            protected set { this.User_main = value; }
        }

        public DataTable Pass_main
        {
            get { return Pass_main = InitTable_PassMain(); }
            protected set { this.Pass_main = value; }
        }
        #endregion

        #region table data objects
        private DataTable InitTable_UserMain()
        {
            DataTable _user_main = new DataTable();
            try
            {
                _user_main.Columns.Add("user_key", typeof(int));
                _user_main.Columns.Add("user_id", typeof(string));
                _user_main.Columns.Add("first_name", typeof(string));
                _user_main.Columns.Add("last_name", typeof(string));
                _user_main.Columns.Add("create_date", typeof(DateTime));

                DataColumn pk = new DataColumn();
                pk = _user_main.Columns[0];
                _user_main.PrimaryKey = pk;
            }
            catch (Exception ex) { MessageBox.Show("Failure initializing user_main :: loginDataObjects_tables"); return _user_main = null; }

            return _user_main;
        }

        private DataTable InitTable_PassMain()
        {
            DataTable _pass_main = new DataTable();
            try
            {
                _pass_main.Columns.Add("pass_hash", typeof(string));
                _pass_main.Columns.Add("pass_salt", typeof(string));
            }
            catch (Exception ex) { MessageBox.Show("Failure initializing pass_main :: loginDataObjects_tables"); return _pass_main = null; }

            return _pass_main;
        }

        #endregion
    }
}
