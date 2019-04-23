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

namespace LoginApp.Models
{
    class loginDataObjects_tables
    {
        
        #region public datatable(s)
        // create data objects based on SQL schema
        public DataTable user_main { get; set; }
        public DataTable pass_main { get; set; }
        #endregion
    }
}
