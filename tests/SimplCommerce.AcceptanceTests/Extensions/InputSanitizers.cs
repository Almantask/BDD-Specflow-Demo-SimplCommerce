namespace SimplCommerce.AcceptanceTests.Extensions
{
    public class InputSanitizers
    {
        public static string Money(string money) => money.Replace("$", "");
    }
}
