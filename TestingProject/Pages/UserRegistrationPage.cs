using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace TestingProject.Pages
{
    class UserRegistrationPage
    {
        private IWebDriver driver;

        #region locators
        private By writeTextBoxEmailLocator = By.Id("emailControl"); //textbox email
        private By writeTextBoxPasswordLocator = By.Id("passwordControl"); //textbox password
        private By writeTextBoxRepeatPasswordLocator = By.Id("repeatPasswordControl"); //textbox repeat password
        private By securityQuestionLocator = By.CssSelector("div#mat-select-value-3");   //texbox security question
        private By selectSecurityQuestionLocator = By.Id("mat-option-3"); //To select security question 1
        private By writeTextBoxAnswerLocator = By.Id("securityAnswerControl"); //textbox security answer
        private By registerButtonLocator = By.Id("registerButton"); //button register
        #endregion

        #region IWebElements
        private IWebElement TextBoxEmail => driver.FindElement(writeTextBoxEmailLocator);
        private IWebElement TextBoxPassword => driver.FindElement(writeTextBoxPasswordLocator);
        private IWebElement TextBoxRepeatPassword => driver.FindElement(writeTextBoxRepeatPasswordLocator);
        private IWebElement SecurityQuestionTextBox => driver.FindElement(securityQuestionLocator);
        private IWebElement SelectSecurityQuestion => driver.FindElement(selectSecurityQuestionLocator);
        private IWebElement TextBoxAnswer => driver.FindElement(writeTextBoxAnswerLocator);
        private IWebElement RegisterButton => driver.FindElement(registerButtonLocator);
        #endregion

        #region Methods
        public UserRegistrationPage (IWebDriver parentDriver)
        {
            driver = parentDriver;
        }

        public void ClickOnTextBoxEmail()
        {
            TextBoxEmail.Click();
        }
        public void WriteOnEmailRegistration(string email)
        {
            TextBoxEmail.SendKeys(email);
        }

        public void ClickOnTextBoxPassword()
        {
            TextBoxPassword.Click();
        }
        public void WriteOnPasswordRegistration(string password)
        {
            TextBoxPassword.SendKeys(password);
        }

        public void ClickOnRepeatPassword()
        {
            TextBoxRepeatPassword.Click();
        }

        public void WriteOnRepeatPassword(string repeatPassword)
        {
            TextBoxRepeatPassword.SendKeys(repeatPassword);
        }

        public void ClickOnButtonOptionSecurityQuestion()
        {
            SecurityQuestionTextBox.Click();
        }
        public void SelectSecurityquestion()
        {
            SelectSecurityQuestion.Click();
        }

        public void ClickOnSecurityAnswer()
        {
            TextBoxAnswer.Click();
        }

        public void WriteOnSecurityAnswer(string security_Answer)
        {
            TextBoxAnswer.SendKeys(security_Answer);
        }
        public void ClickOnRegisterButton()
        {
            RegisterButton.Click();
        }
        #endregion
    }
}

