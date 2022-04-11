﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace SimplCommerce.AcceptanceTests.Pages;

public class ProductPage : BasePage
{
    protected string Url { get; }

    public ProductPage(IWebDriver driver, string product) : base(driver)
    {
        var sanitizedProduct = product.Replace(" ", "-").ToLower();
        Url = $@"https://localhost:44388/{sanitizedProduct}";
    }

    public ProductPage NavigateTo()
    {
        Driver.Navigate().GoToUrl(Url);
        return this;
    }

    public ProductPage AddToCart()
    {
        var addToCartButton = Driver.FindElements(By.CssSelector(".btn.btn-lg.btn-add-cart"));
        addToCartButton?.FirstOrDefault()?.Click();
        return this;
    }

    public ProductPage CloseProductAddedToCartModal()
    {
        var waitDriver = new WebDriverWait(Driver, TimeSpan.FromMilliseconds(2000));
        var closeButton = waitDriver.Until(driver => driver.FindElement(By.ClassName("close")));
        closeButton.Click();

        return this;
    }
}
