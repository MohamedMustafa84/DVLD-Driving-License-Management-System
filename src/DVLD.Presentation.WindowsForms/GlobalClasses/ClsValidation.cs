using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace DVLD.Presentation.WindowsForms.GlobalClasses
{
    internal class ClsValidation
    {
        public static bool ValidateEmail(string Email)
        {
            var Pattern = @"^[a-zA-Z0-9.!#$%&'*+-/=?^_`{|}~]+@[a-zA-Z0-9-]+(?:\.[a-zA-Z0-9-]+)*$"; 

            var regex = new Regex(Pattern);

            return regex.IsMatch(Email);
        }
    }
}
