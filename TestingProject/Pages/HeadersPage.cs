using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;

namespace TestingProject.Pages
{
    class HeadersPage
    {
        private IWebDriver driver;

        #region locators
        private By accountLocator = By.CssSelector("button#navbarAccount"); //button account
        private By logginLocator = By.Id("navbarLoginButton"); //button loggin before register
        private By yourBasketLocator = By.CssSelector("button[routerlink='/basket']");
        private By ordersAndPaymentLocator = By.CssSelector("#cdk-overlay-2 button[aria-label*='Orders']");
        private By orderHistoryLocator = By.CssSelector("div.cdk-overlay-pane button[aria-label*='history']");
        #endregion

        #region WebElements 
        private IWebElement Account => driver.FindElement(accountLocator);
        private IWebElement Loggin => driver.FindElement(logginLocator);
        private IWebElement Basket => driver.FindElement(yourBasketLocator);
        private IWebElement OrdersAndPayment => driver.FindElement(ordersAndPaymentLocator);
        private IWebElement OrderHistory => driver.FindElement(orderHistoryLocator);
        #endregion

        #region Methods
        public HeadersPage(IWebDriver parentDriver)
        {
            driver = parentDriver;
        }
        public void ClickOnAccount()
        {
            Account.Click();
        }
        public void ClickOnLoggin()
        {
            Loggin.Click();
        }
        public void WaitButtonBasketIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.ElementToBeClickable(Basket));
        }

        public void ClickOnYourBasketButton()
        {
            Basket.Click();
        }
        public void ClickOnOrdersAndPaymentButton()
        {
            OrdersAndPayment.Click();
        }
        public void WaitOrderHistoryButtonIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(OrderHistory));
        }

        public void ClickOnOrderHistoryButton()
        {
            OrderHistory.Click();
        }
        #endregion
    }
}
