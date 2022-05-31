using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace TestingProject.Pages
{
    class OrderHistoryPage
    {
        private IWebDriver driver;

        #region Locators

        private By textInTransintLocator = By.CssSelector("div.heading div.error");
        private By listOfItemsPurchasedLocator = By.CssSelector("mat-table mat-row mat-cell[class*='cdk-column-product']");
        private By listOfTotalPricesLocator = By.CssSelector("mat-table mat-row mat-cell[class*='cdk-column-price']");
        #endregion

        #region IWebElements
        private IWebElement TextInTransit => driver.FindElement(textInTransintLocator);
        private IList<IWebElement> ListOfItemsPurchased => driver.FindElements(listOfItemsPurchasedLocator);
        private IList<IWebElement> ListOfTotalPricesPurchased => driver.FindElements(listOfTotalPricesLocator);
        #endregion

        #region Methods
        public OrderHistoryPage (IWebDriver parentDriver)
        {
            driver = parentDriver;
        }

        public string GetOrderStatus()
        {
            return TextInTransit.Text;
        }
        public int GetAmountOfProductsPurchased()
        {
            var quantityOfItems = ListOfItemsPurchased.Count();
            return quantityOfItems;
        }
        public string GetTotalPricesOfFirstItemPurchased()
        {
            return ListOfTotalPricesPurchased[0].Text;
        }
        public string GetTotalPricesOfSecondItemPurchased()
        {
            return ListOfTotalPricesPurchased[1].Text;
        }
        public void WaitOderHistoryPageLoad()
        {
            string message = "In Transit";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div.heading div.error"), message));
        }
        #endregion

    }
}
