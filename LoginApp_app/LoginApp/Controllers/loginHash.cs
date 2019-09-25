using LoginApp.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace LoginApp.Controllers
{
    class loginHash
    {
        // CD: testing base functionality for parsing hash
        public string hashSHA2_512(string val)
        {
            var sha2_512 = SHA512.Create(); // derived from System.Security.Cryptpography{}
            var bytes = Encoding.ASCII.GetBytes(val);
            var hash = sha2_512.ComputeHash(bytes);

            var sb = new StringBuilder();
            for (var i = 0; i < hash.Length; i++)
            {
                sb.Append(hash[i].ToString("X2"));
            }
            return sb.ToString();
        }
    }
}
