namespace SimplCommerce.AcceptanceTests.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage NavigateTo()
        {
            NavigateTo(Url);
            return this;
        }

        public ProductPage NavigateToProductPage(string item)
        {
            return new ProductPage(Driver, item).NavigateTo();
        }
    }
}
