using SimplCommerce.AcceptanceTests.Pages.ShoppingCart;

namespace SimplCommerce.AcceptanceTests.Pages
{
    public class NavigationBar : BasePage
    {
        public NavigationBar(IWebDriver driver) : base(driver)
        {
        }

        public HomePage NavigateToHomePage() => new HomePage(Driver).NavigateTo();

        public ShoppingCartPage NavigateToShoppingCart() => new ShoppingCartPage(Driver).NavigateTo();
    }
}
