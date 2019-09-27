using LoginApp.Controllers;
using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace LoginApp.Controllers
{
    class loginExt
    {
        // main external method class
        public char togglePassChar(char p)
        {
            // dynamically display text or PassChar
            return p = (p == '*') ? '\0' : '*';
        }

        public bool valPasswordReqs(string pw)
        {
            bool pass = true; // assume success

            // ensure password meets criteria
            pass = parseNumeric(pw, pass);
            if (!pass) { MessageBox.Show("password must be alpha-numeric"); return pass; }

            pass = parseSpecialChar(pw, pass);
            if (!pass) { MessageBox.Show("password must contain at least one (1) special character"); return pass; }

            return pass; // default return
        }

        #region helper methods
        // HELPER METHODS
        private static bool parseNumeric(string _pw, bool _pass)
        {
            if (!_pw.Any(Char.IsDigit)) { _pass = false; }

            return _pass;
        }

        private static bool parseSpecialChar(string _pw, bool _pass)
        {
            var regex = new Regex("^[a-zA-Z0-9_]*$"); // regex for special chars

            if (regex.IsMatch(_pw)) { _pass = false; }

            return _pass;
        }
            #region notes on regex
            // ^ : start of string
            // [ : beginning of character group
            // a - z : any lowercase letter
            // A - Z : any uppercase letter
            // 0 - 9 : any digit
            // _ : underscore
            // ] : end of character group
            // * : zero or more of the given characters
            // $ : end of string
            #endregion
        #endregion

    }
}
