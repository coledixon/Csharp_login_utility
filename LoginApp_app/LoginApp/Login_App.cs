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

        public Login_App()
        {
            InitializeComponent();
            InstantiateObjects();
            checkRecsExist();
        }

        // INSTANTIATE CLASS(ES)
        public void InstantiateObjects()
        {
            data = new loginData();
            ext = new loginExt();
            //hash = new loginHash();
            //props = new loginProps();
        }

        private void checkRecsExist()
        {
            data.Select("cole");
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
