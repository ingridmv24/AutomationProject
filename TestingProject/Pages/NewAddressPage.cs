using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingProject.Pages
{
    class NewAddressPage
    {
        private IWebDriver driver;

        #region locators
        private By countryTextBoxLocator = By.Id("mat-input-9");
        private By nameTextBoxLocator = By.Id("mat-input-10");
        private By mobileNumberTextBoxLocator = By.Id("mat-input-11");
        private By zipCodeTextBoxLocator = By.Id("mat-input-12");
        private By addressTextBoxLocator = By.Id("address");
        private By cityTextBoxLocator = By.Id("mat-input-14");
        private By stateTextBoxLocator = By.Id("mat-input-15");
        private By submitButtonLocator = By.Id("submitButton");
        private By selectAddressLocator = By.Id("mat-radio-39");
        private By continueButtonLocator = By.CssSelector("[aria-label*='Proceed']");
        #endregion

        #region WebElements 
        private IWebElement CountryTextBox => driver.FindElement(countryTextBoxLocator);
        private IWebElement NameTextbox => driver.FindElement(nameTextBoxLocator);
        private IWebElement MobileNumberTextbox => driver.FindElement(mobileNumberTextBoxLocator);
        private IWebElement ZipCodeTextBox => driver.FindElement(zipCodeTextBoxLocator);
        private IWebElement AddresTextBox => driver.FindElement(addressTextBoxLocator);
        private IWebElement CityTextBox => driver.FindElement(cityTextBoxLocator);
        private IWebElement StateTextBox => driver.FindElement(stateTextBoxLocator);
        private IWebElement SubmitButton => driver.FindElement(submitButtonLocator);
        private IWebElement SelectAddres => driver.FindElement(selectAddressLocator);
        private IWebElement ContinueButton => driver.FindElement(continueButtonLocator);
        #endregion

        #region Methods
        public NewAddressPage(IWebDriver parentDriver)
        {
            driver = parentDriver;
        }

        public void ClickOnCountryTextBox()
        {
            CountryTextBox.Click();
        }

        public void WriteOnCountryTextBox(string country)
        {
            CountryTextBox.SendKeys(country);
        }
        public void ClickOnNameTextBox()
        {
            NameTextbox.Click();
        }

        public void WriteOnNameTextBox(string name)
        {
            NameTextbox.SendKeys(name);
        }
        public void ClickOnMobileNumberTextBox()
        {
            MobileNumberTextbox.Click();
        }

        public void WriteOnMobileNumberTextBox(string mobileNumber)
        {
            MobileNumberTextbox.SendKeys(mobileNumber);

        }
        public void ClickOnZipCodeTextBox()
        {
            ZipCodeTextBox.Click();
        }
        public void WriteOnZipCodeTextBox(string zipCode)
        {
            ZipCodeTextBox.SendKeys(zipCode);
        }
        public void ClickOnAddressTextBox()
        {
            AddresTextBox.Click();
        }
        public void WriteOnAddressTextBox(string address)
        {
            AddresTextBox.SendKeys(address);
        }
        public void ClickOnCityTextBox()
        {
            CityTextBox.Click();
        }
        public void WriteOnCityTextBox(string city)
        {
            CityTextBox.SendKeys(city);
        }
        public void ClickOnStateTextBox()
        {
            StateTextBox.Click();
        }
        public void WriteOnStateTextBox(string state)
        {
            StateTextBox.SendKeys(state);
        }
        public void ClickOnSubmitButton()
        {
            SubmitButton.Click();
        }
        public void ClickOnRadioButtonSelectAddres()
        {
            SelectAddres.Click();
        }
        public void ClickOnContinueButton()
        {
            ContinueButton.Click();       
        }
        #endregion

    }
}
