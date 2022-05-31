using OpenQA.Selenium;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject.Pages
{
    class PaymentOptionsPage
    {
        private IWebDriver driver;

        #region Locators
        private By addNewCardLocator = By.CssSelector("[class*='mat-content']");
        private By nameTextBoxLocator = By.Id("mat-input-16");
        private By cardNumberTextBoxLocator = By.Id("mat-input-17");
        private By expiryMonthLocator = By.Id("mat-input-18");
        private By expiryYearLocator = By.Id("mat-input-19");
        private By submitButtonLocator = By.CssSelector("button#submitButton");
        private By radioButtonCardLocator = By.Id("mat-radio-43");
        #endregion

        #region Web Elements
        private IWebElement AddNewCard => driver.FindElement(addNewCardLocator);
        private IWebElement NameTextBox => driver.FindElement(nameTextBoxLocator);
        private IWebElement CardNumberTextBox => driver.FindElement(cardNumberTextBoxLocator);
        private IWebElement ExpiryMonth => driver.FindElement(expiryMonthLocator);
        private IWebElement ExpiryYear => driver.FindElement(expiryYearLocator);
        private IWebElement SubmitButton => driver.FindElement(submitButtonLocator);
        private IWebElement RadioButtonCard => driver.FindElement(radioButtonCardLocator);
        #endregion

        #region Methods
        public PaymentOptionsPage(IWebDriver ParentDriver)
        {
            driver = ParentDriver;
        }
        public void WaitAddNewCardTextIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(AddNewCard));
        }
        public void ClickOnAddNewCard()
        {
            AddNewCard.Click();
        }
        public void WaitNameTextBoxIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(NameTextBox));
        }

        public void ClickOnNameTextBox()
        {
            NameTextBox.Click();
        }
        public void WriteOnNameTextBox(string name)
        {
            NameTextBox.SendKeys(name);
        }
        public void ClickOnCardNumberTextBox()
        {
            CardNumberTextBox.Click();
        }
        public void WriteOnCardNumberTextBox(string cardNumber)
        {
            CardNumberTextBox.SendKeys(cardNumber);
        }

        public void SelectMonth()
        {
            SelectElement selectMonth = new SelectElement(ExpiryMonth);
            selectMonth.SelectByValue("5");
        }
        public void SelectYear()
        {
            SelectElement selectYear = new SelectElement(ExpiryYear);
            selectYear.SelectByValue("2085");
        }
        public void WaitSubmitButtonIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(SubmitButton));
        }
        public void ClickOnSubmitButton()
        {
            IJavaScriptExecutor executor = driver as IJavaScriptExecutor;
            executor.ExecuteScript("arguments[0].click();", SubmitButton);
        }
        public void ClickOnRadioButtonCard()
        {
            RadioButtonCard.Click();
        }
        #endregion
    }
}
