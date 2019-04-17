using LoginApp.Controllers;
using LoginApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace LoginApp.Controllers
{
    class loginExt
    {
        // main external method class
        public bool valPasswordReqs(string pw)
        {

            // DEBUG: IsSymbol not accounting for all symbols

            bool succ = true; // assume success

            if (!pw.Any(Char.IsDigit)) // val numeric firsta
            {
                // throw error stating "pw must contain numeric value"
                succ = false;
                if (!pw.Any(Char.IsSymbol))
                {
                    succ = false;
                    // throw error stating "pw must contain at least one symbol"
                }
            }
            else if (!pw.Any(Char.IsSymbol)) // reverse val order
            {
                // throw error stating "pw must contain at least one symbol"
                succ = false;
                if (!pw.Any(Char.IsDigit))
                {
                    succ = false;
                    // throw error stating "pw must contain numeric value"
                }
            }

            return succ;

        }
    }
}
