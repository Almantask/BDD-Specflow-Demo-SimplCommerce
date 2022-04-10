using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Humanizer;

namespace SimplCommerce.AcceptanceTests.Extensions
{
    public static class StringExtensions
    {
        public static T ConvertTo<T>(this string text, Func<string, string>? sanitize = null)
        {
            var value = sanitize?.Invoke(text) ?? text;
            return (T)Convert.ChangeType(value, typeof(T));
        }
    }
}
