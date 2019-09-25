using LoginApp.Controllers;
using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LoginApp
{
    public partial class Admin : Form
    {
        bool showpass = false;
        // ref to external controller(s) / model(s)
        private loginData data;
        private loginExt ext;
        private loginHash hash;
        private adminHelpers helpers;
        private loginProps props;
        private loginInitSchema schema;

        // data objects
        private loginDataObjects_tables tbl;
        private loginDataObjects_views view;

        public Admin()
        {
            InitializeComponent();
            InstantiateObjects();
            InitSchema();
        }

        // INSTANTIATE CLASS(ES)
        public void InstantiateObjects()
        {
            data = new loginData();
            ext = new loginExt();
            //hash = new loginHash();
            helpers = new adminHelpers();

            // model objects
            props = new loginProps();
            tbl = new loginDataObjects_tables();
            view = new loginDataObjects_views();

            // data objects
            schema = new loginInitSchema();
        }

        public void InitSchema()
        {
            tbl.user_main = schema.InitTable_UserMain();
            // CD REMOVED: using view tbl.pass_main = schema.InitTable_PassMain();

            view.vlogin_users = schema.InitView_VLoginUsers();
            view.vlogin_audit_all = schema.InitView_VLoginAuditAll();
        }

        #region button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (helpers.checkFieldvals(txtFName.Text, txtLName.Text, txtUserName.Text, txtPassword.Text))
            {
                if (!data.Insert(txtUserName.Text, txtFName.Text, txtLName.Text, txtPassword.Text))
                {
                    MessageBox.Show("ERROR ON DATA INSERT: Admin.btnAdd_Click > loginData.Insert()");
                }
            }

            CloseForm(this);
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // SQL update func
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // SQL delete func
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            // dynamically remove PassChar prop from txtPassword
            if (txtPassword.Text.Length > 0)
            {
                txtPassword.PasswordChar = ext.togglePassChar(txtPassword.PasswordChar);
            }
        }
        #endregion

        #region focus events
        private void txtUserName_LostFocus(object sender, EventArgs e)
        {
            if (!string.IsNullOrEmpty(txtUserName.Text))
            {
                if (data.Select(view.vlogin_users, txtUserName.Text))
                {
                    MessageBox.Show("username already exists");
                }
            }
        }

        private void txtPassword_LostFocus(object sender, EventArgs e)
        {
            // DEBUG: firing before button event (showpass_click)
            ext.valPasswordReqs(txtPassword.Text);
        }
        #endregion

        #region close events
        public void CloseForm(object form)
        {
            this.Close();
        }
        #endregion
    }

    public class adminHelpers
    {
        public bool checkFieldvals(string firstName, string lastName, string userName, string pass)
        {
            if (string.IsNullOrEmpty(firstName) || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(pass))
            {
                MessageBox.Show("all fields required. please review form before submission.");
                return false;
            }

            return true;
        }
    }
}

