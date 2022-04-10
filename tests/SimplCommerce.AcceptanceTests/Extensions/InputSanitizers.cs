using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimplCommerce.AcceptanceTests.Extensions
{
    public class InputSanitizers
    {
        public static string Money(string money) => money.Replace("$", "");
    }
}
