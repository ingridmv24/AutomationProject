using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.WaitHelpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject.Pages
{
    class BodyPage
    {
        private IWebDriver driver;

        #region locators
        private By addBasketButtonLocator = By.CssSelector("mat-card button.btn-basket"); //to add products in basket
        private By checkoutButtonLocator = By.Id("checkoutButton"); //button checkout
        private By addNewAddresButtonLocator = By.CssSelector("div.ng-star-inserted button");

        #endregion

        #region WebElements
        private IList<IWebElement> ListOfProducts => driver.FindElements(addBasketButtonLocator);
        private IWebElement CheckOutButton => driver.FindElement(checkoutButtonLocator);
        private IWebElement AddNewAddresButton => driver.FindElement(addNewAddresButtonLocator);
        #endregion

        #region Methods
        public BodyPage(IWebDriver parentDriver)
        {
            driver = parentDriver;
        }
        public void WaitProductsAreClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(By.CssSelector("mat-card button.btn-basket")));
        }
        public void ClickOnAppleJuice()
        {
            ListOfProducts[0].Click();
        }
        public void ClickOnApplePomace()
        {
            ListOfProducts[1].Click();
        }
        public void WaitCheckOutButtonIsClickable()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            wait.Until(ExpectedConditions.ElementToBeClickable(CheckOutButton));
        }
        public void ClickOnCheckOutButton()
        {
            CheckOutButton.Click();
        }
        public void ClickOnAddNewAddresButton()
        {
            AddNewAddresButton.Click();
        }

        #endregion
    }
}
