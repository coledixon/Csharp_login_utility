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
        private loginProps props;

        public Admin()
        {
            InitializeComponent();
            InstantiateObjects();
        }

        // INSTANTIATE CLASS(ES)
        public void InstantiateObjects()
        {
            data = new loginData();
            ext = new loginExt();
            //hash = new loginHash();
            props = new loginProps();
        }

        #region button events
        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (checkFieldvals())
            {
                if (!data.Insert(txtUserName.Text, txtFName.Text, txtLName.Text, txtPassword.Text))
                {
                    MessageBox.Show("ERROR ON DATAA INSERT: btnAdd_Click > loginData.Insert()");
                }
            }
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
            // dynamically query SQL to validate username does not exist
        }
        private void txtPassword_LostFocus(object sender, EventArgs e)
        {
            // DEBUG: firing before button event (showpass_click)
            ext.valPasswordReqs(txtPassword.Text);
        }
        #endregion

        private bool checkFieldvals()
        {
            if (string.IsNullOrEmpty(txtFName.Text) || string.IsNullOrEmpty(txtLName.Text)
                || string.IsNullOrEmpty(txtUserName.Text) || string.IsNullOrEmpty(txtPassword.Text))
            {
                MessageBox.Show("all fields required. please review form before submission.");
                return false;
            }

            return true;
        }
    }
}
