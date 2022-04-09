﻿using OpenQA.Selenium;

namespace SimplCommerce.FunctionalTests.Pages
{
    public class HomePage : BasePage
    {
        private const string Url = "https://localhost:44388/";

        public HomePage(IWebDriver driver) : base(driver)
        {
        }

        public HomePage NavigateTo()
        {
            Driver.Navigate().GoToUrl(Url);
            return this;
        }

        public ProductPage NavigateToProductPage(string item)
        {
            return new ProductPage(Driver, item).NavigateTo();
        }
    }
}
