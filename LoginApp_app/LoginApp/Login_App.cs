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
        }

        // INSTANTIATE CLASS(ES)
        public void InstantiateObjects()
        {
            data = new loginData();
            ext = new loginExt();
            hash = new loginHash();
            props = new loginProps();
        }
    }
}
