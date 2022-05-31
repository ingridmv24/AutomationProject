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
    class AlertsPage
    {
        private IWebDriver driver;

        #region locators
        private By dissmisLocator = By.CssSelector("button.mat-primary");
        private By buttonMeWantitLocator = By.ClassName("cc-btn");
        private By alertLocator = By.TagName("simple-snack-bar");
        #endregion

        #region WebElements 
        private IWebElement Dissmiss => driver.FindElement(dissmisLocator);
        private IWebElement ButtonWeWantIt => driver.FindElement(buttonMeWantitLocator);
        #endregion

        #region Methods
        public AlertsPage(IWebDriver parentDriver)
        {
            driver = parentDriver;
        }

        public void ClickOnDissmis()
        {
            Dissmiss.Click();
        }

        public void ClickOnButtonWeWantIt()
        {
            ButtonWeWantIt.Click();
        }
        public void WaitUntilAlertIsInvisible()
        {
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromSeconds(30));
            wait.Until(ExpectedConditions.PresenceOfAllElementsLocatedBy(alertLocator));

            var alert = driver.FindElement(alertLocator);
            wait.Until(ExpectedConditions.StalenessOf(alert));
        }
        #endregion
    }
}
