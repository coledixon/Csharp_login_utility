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
            // REMOVED UNTIL CLASSES BUILT OUT
            InstantiateObjects();
        }

        // INSTANTIATE CLASS(ES)
        public void InstantiateObjects()
        {
            //data = new loginData();
            ext = new loginExt();
            //hash = new loginHash();
            //props = new loginProps();
        }

        #region lost focus events
        private void txtUsername_LostFocus(object sender, EventArgs e)
        {
            // this event will validate the user exists in SQL
        }

        private void txtPassword_LostFocus(object sender, EventArgs e)
        {
            bool succ = ext.valPasswordReqs(txtPassword.Text);
        }
        #endregion

        #region button events
        private void btnAdmin_Click(object sender, EventArgs e)
        {
            // prompt the admin console
                // admin console = create / update / delete || users / pw
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // validate both fields are filled in
            // fire login logic
                // hash password
        }
        #endregion
    }
}
