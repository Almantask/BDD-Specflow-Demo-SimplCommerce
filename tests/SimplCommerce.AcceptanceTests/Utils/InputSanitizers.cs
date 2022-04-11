namespace SimplCommerce.AcceptanceTests.Utils
{
    public class InputSanitizers
    {
        public static string Money(string money) => money.Replace("$", "");
    }
}
