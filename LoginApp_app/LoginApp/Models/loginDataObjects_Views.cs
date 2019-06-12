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
    class loginDataObjects_views
    {
        #region public dataviews(s)
        // create data objects based on SQL schema
        public DataTable vlogin_users { get; set; }
        public DataTable vlogin_audit_all { get; set; }
        #endregion
    }
}

