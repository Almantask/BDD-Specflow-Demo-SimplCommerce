//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using OpenQA.Selenium;

//namespace SimplCommerce.FunctionalTests.Hooks
//{
//    [Binding]
//    public class Page
//    {
//        private readonly IWebDriver _driver;

//        public Page(IWebDriver driver)
//        {
//            _driver = driver;
//        }

//        [BeforeScenario("ShoppingCart")]
//        public void BeforeFeature()
//        {
//            _driver.Navigate().GoToUrl("https://localhost:44388/woman");
//        }
//    }
//}
