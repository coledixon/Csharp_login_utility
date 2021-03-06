﻿using LoginApp.Models;
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
        public DataTable _user = new DataTable("user_main");
        public DataTable _vuser = new DataTable("vlogin_user");

        #region table data objects
        public DataTable InitTable_UserMain()
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

                DataSet tUserData = new DataSet();
                tUserData.Tables.Add(_user_main);

            }
            catch (Exception ex) { MessageBox.Show("Failure initializing user_main :: loginDataObjects_tables"); return _user_main = null; }

            return _user_main;
        }

        // CD REMOVED: using view
        //public DataTable InitTable_PassMain()
        //{
        //    DataTable _pass_main;
        //    try
        //    {
        //        _pass_main = new DataTable("pass_main");

        //        _pass_main.Columns.Add("user_key", typeof(int));
        //        _pass_main.Columns.Add("pass_hash", typeof(string));
        //        _pass_main.Columns.Add("pass_salt", typeof(string));

        //        DataSet tPassData = new DataSet();
        //        tPassData.Tables.Add(_pass_main);

        //    }
        //    catch (Exception ex) { MessageBox.Show("Failure initializing pass_main :: loginDataObjects_tables"); return _pass_main = null; }

        //    return _pass_main;
        //}
        #endregion

        #region view data objects
        public DataTable InitView_VLoginUsers()
        {
            DataTable _vlogin_users;
            try
            {
                _vlogin_users = new DataTable("vlogin_users");

                _vlogin_users.Columns.Add("user_id", typeof(string));
                _vlogin_users.Columns.Add("first_name", typeof(string));
                _vlogin_users.Columns.Add("last_name", typeof(string));
                _vlogin_users.Columns.Add("pass_hash", typeof(string));
                _vlogin_users.Columns.Add("pass_salt", typeof(string));

                DataSet vUserData = new DataSet();
                vUserData.Tables.Add(_vlogin_users);
            }
            catch (Exception ex) { MessageBox.Show("Failure initializing vlogin_users :: loginDataObjects_views"); return _vlogin_users = null; }

            return _vlogin_users;
        }

        public DataTable InitView_VLoginAuditAll()
        {
            DataTable _vlogin_audit_all;
            try
            {
                _vlogin_audit_all = new DataTable("vlogin_audit_all");

                _vlogin_audit_all.Columns.Add("status", typeof(string));
                _vlogin_audit_all.Columns.Add("curr_session_id", typeof(string));
                _vlogin_audit_all.Columns.Add("last_login", typeof(DateTime));
                _vlogin_audit_all.Columns.Add("last_session_id", typeof(string));
                _vlogin_audit_all.Columns.Add("last_logout", typeof(DateTime));

                DataSet loginAuditData = new DataSet();
                loginAuditData.Tables.Add(_vlogin_audit_all);
            }
            catch (Exception ex) { MessageBox.Show("Failure initializing _vlogin_audit_all :: loginDataObjects_views"); return _vlogin_audit_all = null; }

            return _vlogin_audit_all;
        }
        #endregion
    }
}
