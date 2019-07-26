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
    public partial class Login_App : Form
    {
        // ref to external controller(s) / model(s)
        private loginData data;
        private loginExt ext;
        private loginHash hash;
        private loginProps props;
        private loginInitSchema schema;
        // data objects
        private loginDataObjects_tables tbl;
        private loginDataObjects_views view;

        public Login_App()
        {
            InitializeComponent();
            InstantiateObjects();
            InitSchema();
            checkRecsExist();
        }

        // INSTANTIATE CLASS(ES)
        public void InstantiateObjects()
        {
            // controller objects
            data = new loginData();
            ext = new loginExt();
            //hash = new loginHash();

            // model objects
            //props = new loginProps();
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

        private void checkRecsExist()
        {
            data.Select(view.vlogin_users, view.vlogin_users.Columns["first_name"], "cole");
            // run after InstantiateObjects()
            // dynamically query SQL || if no records in user_main, all text fields ReadOnly
        }

        #region focus events
        private void txtUsername_LostFocus(object sender, EventArgs e)
        {
            // this event will validate the user exists in SQL
        }
        #endregion

        #region button events
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // TO DO: if username entered, load user info in admin form

            Admin frm = new Admin(); // call admin.cs
            frm.Show();

        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // validate both fields are filled in
            // fire login logic
                // hash password
        }

        private void btnShowPass_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text.Length > 0)
            {
                txtPassword.PasswordChar = ext.togglePassChar(txtPassword.PasswordChar);
            }
        }
        #endregion

    }
}
