using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;

namespace TestingProject.Pages
{
    class DeliveryAddressPage
    {
        private IWebDriver driver;

        #region Locators
        private By selectOnedayRadioButtonLocator = By.Id("mat-radio-40");
        private By continueButtonLocator = By.CssSelector("button.nextButton");
        private By placeOrderLocator = By.Id("checkoutButton");
        private By textLocator = By.CssSelector("div span.ng-star-inserted");
        private By confirmationMessageLocator = By.CssSelector("div h1.confirmation");
        private By itemsLocator = By.CssSelector("table.mat-table");
        private By totalPriceLocator = By.CssSelector("table.price-align tr");

        #endregion

        #region Web Elements
        private IWebElement SelectOneDayRadioButton => driver.FindElement(selectOnedayRadioButtonLocator);
        private IWebElement ContinueButton => driver.FindElement(continueButtonLocator);
        private IWebElement PlaceOrder => driver.FindElement(placeOrderLocator);
        private IWebElement Text => driver.FindElement(textLocator);
        private IWebElement ConfirmationMessage => driver.FindElement(confirmationMessageLocator);
        private IWebElement Items => driver.FindElement(itemsLocator);
       private IList<IWebElement> ListOfPrices => driver.FindElements(totalPriceLocator); 
        #endregion

        #region Methods
        public DeliveryAddressPage(IWebDriver ParentDriver)
        {
            driver = ParentDriver;
        }
        public void WaitRadioButtonOneDayIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(SelectOneDayRadioButton));
        }
        public void ClickOnSelectOneDayRadioButton()
        {
            SelectOneDayRadioButton.Click();
        }
        public void WaitContinueButtonIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(5));
            wait.Until(ExpectedConditions.ElementToBeClickable(ContinueButton));
        }

        public void ClickOnContinueButton()
        {
            //option 1:
            //ContinueButton.Click();

            //option 2:
            /*
            Actions action = new Actions(driver);
            action.MoveToElement(ContinueButton).
                Click().
                Perform();
            */

            //option 3: Javascript
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript("arguments[0].click();", ContinueButton);
        }

        public void ClickOnPlaceOrderAndPay()
        {
            PlaceOrder.Click();
        }
        public void WaitPageLoad()
        {
            string message = "Your order will be delivered in 1 days.";
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.TextToBePresentInElementLocated(By.CssSelector("div span.ng-star-inserted"),message));
        }
        public string GetConfirmationMessage()
        {
            return ConfirmationMessage.Text;
        }
        public void ScrollDrownTotalPrice()
        {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", Items);
        }
        public string GetTotalPrice()
        {
            return ListOfPrices[3].Text;
        }
        #endregion
    }
}
