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
    class LoginPage
    {
        private IWebDriver driver;

        #region locators
        private By registerLocator = By.CssSelector("#newCustomerLink a"); //text not yet a customer
        private By emailLoginTextBoxLocator = By.Id("email");
        private By passwordLoginTextBoxLocator = By.Id("password");
        private By loginButtonLocator = By.Id("loginButton"); //button register
        #endregion

        #region WebElements
        private IWebElement RegisterUser => driver.FindElement(registerLocator);
        private IWebElement LoginTextbox => driver.FindElement(emailLoginTextBoxLocator);
        private IWebElement PasswordTextBox => driver.FindElement(passwordLoginTextBoxLocator);
        private IWebElement LoginButton => driver.FindElement(loginButtonLocator);
        #endregion

        #region Methods
        public LoginPage (IWebDriver parentDriver)
        {
            driver = parentDriver;
        }

        public void ScrollDrownNotYetRegisterUserText()
        {
            ((IJavaScriptExecutor)driver)
            .ExecuteScript("arguments[0].scrollIntoView(true);", RegisterUser);
        }
        public void ClickOnNotYetCostumer()
        {
            RegisterUser.Click();  
        }
        public void ClickOnEmailLoginTextBox()
        {
            LoginTextbox.Click();
        }
        public void WriteOnEmailTextBoxLogin(string emailLogin)
        {
            LoginTextbox.SendKeys(emailLogin);
        }
        public void ClickOnPasswordLoginTextBox()
        {
            PasswordTextBox.Click();
        }
        public void WriteOnPasswordTextBoxLogin(string passwordForLogin)
        {
            PasswordTextBox.SendKeys(passwordForLogin);
        }
        public void ClickOnLoginButton()
        {
            LoginButton.Click();                    
        }   
        #endregion
    }
}
