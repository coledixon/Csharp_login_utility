using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Reflection;


namespace LoginApp.Models
{
    class loginProps
    {
        // SQL col names not same as props (schema cols include _)
        #region get/set
        // user_main
        public int UserKey { get; set; }
        public string UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime CreateDate { get; set; }

        // pass_main
        public string PassHash { get; set; }
        public string PassSalt { get; set; }

        // login_audit
        public int LoginStatus { get; set; }
        public string CurrSessId { get; set; }
        public DateTime LastLogin { get; set; }

        // logout_audit
        public int LogoutStatus { get; set; }
        public DateTime LastLogout { get; set; }
        public string LastSessId { get; set; }

        // user_key_store
        public int NewUserKey { get; set; }
        #endregion
    }
}
