using Microsoft.VisualStudio.TestTools.UnitTesting;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TestingProject.Pages;

namespace TestingProject.Tests
{
    [TestClass]
    public class TestClass
    {
        public TestContext TestContext { get; set; }
        IWebDriver driver;

        [TestInitialize]
        public void TestInit()
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Url = "http://localhost:3000/#/";
        }

        [TestMethod]
        public void WebShopTest()
        {
            var generator = new Random();
            var ramdonNumber = generator.Next(1, 300);
            string emailRegistration = "ingridvm" + ramdonNumber + "@gmail.com";
            string passwordRegistration = "12345";
            string repeatPasswordRegistration = "12345";
            string securityAnswer = "thing";
            string country = "United States";
            string name = "Ingrid";
            string mobileNumber = "3019154718";
            string zipCode = "15001";
            string address = "80 #30-20";
            string city = "Los Angeles";
            string state = "California";
            string cardNumber = "9238562072519503";

            var pageAlerts = new AlertsPage(driver);
            var pageHeaders = new HeadersPage(driver);
            var pageLogin = new LoginPage(driver);
            var pageUserRegistraton = new UserRegistrationPage(driver);
            var pageBody = new BodyPage(driver);
            var pageNewAddres = new NewAddressPage(driver);
            var pageDeliveryAddress = new DeliveryAddressPage(driver);
            var pagePaymentOptions = new PaymentOptionsPage(driver);

            pageAlerts.ClickOnDissmis();
            pageAlerts.ClickOnButtonWeWantIt();
            pageHeaders.ClickOnAccount();
            pageHeaders.ClickOnLoggin();
            pageLogin.ScrollDrownNotYetRegisterUserText();
            pageAlerts.WaitUntilAlertIsInvisible();
            pageLogin.ClickOnNotYetCostumer();

            pageUserRegistraton.ClickOnTextBoxEmail();
            pageUserRegistraton.WriteOnEmailRegistration(emailRegistration);
            pageUserRegistraton.ClickOnTextBoxPassword();
            pageUserRegistraton.WriteOnPasswordRegistration(passwordRegistration);
            pageUserRegistraton.ClickOnRepeatPassword();
            pageUserRegistraton.WriteOnRepeatPassword(repeatPasswordRegistration);
            pageUserRegistraton.ClickOnButtonOptionSecurityQuestion();
            pageUserRegistraton.SelectSecurityquestion();
            pageUserRegistraton.ClickOnSecurityAnswer();
            pageUserRegistraton.WriteOnSecurityAnswer(securityAnswer);
            pageUserRegistraton.ClickOnRegisterButton();

            pageAlerts.WaitUntilAlertIsInvisible();
            pageLogin.ClickOnEmailLoginTextBox();
            pageLogin.WriteOnEmailTextBoxLogin(emailRegistration);
            pageLogin.ClickOnPasswordLoginTextBox();
            pageLogin.WriteOnPasswordTextBoxLogin(passwordRegistration);
            pageLogin.ClickOnLoginButton();

            pageBody.WaitProductsAreClickable();
            pageBody.ClickOnAppleJuice();
            pageBody.ClickOnApplePomace();

            pageHeaders.WaitButtonBasketIsClickable();
            pageHeaders.ClickOnYourBasketButton();
            pageBody.WaitCheckOutButtonIsClickable();
            pageAlerts.WaitUntilAlertIsInvisible();
            pageBody.ClickOnCheckOutButton();

            pageBody.ClickOnAddNewAddresButton();
            pageNewAddres.ClickOnCountryTextBox();
            pageNewAddres.WriteOnCountryTextBox(country);
            pageNewAddres.ClickOnNameTextBox();
            pageNewAddres.WriteOnNameTextBox(name);
            pageNewAddres.ClickOnMobileNumberTextBox();
            pageNewAddres.WriteOnMobileNumberTextBox(mobileNumber);
            pageNewAddres.ClickOnZipCodeTextBox();
            pageNewAddres.WriteOnZipCodeTextBox(zipCode);
            pageNewAddres.ClickOnAddressTextBox();
            pageNewAddres.WriteOnAddressTextBox(address);
            pageNewAddres.ClickOnCityTextBox();
            pageNewAddres.WriteOnCityTextBox(city);
            pageNewAddres.ClickOnStateTextBox();
            pageNewAddres.WriteOnStateTextBox(state);
            pageNewAddres.ClickOnSubmitButton();

            pageAlerts.WaitUntilAlertIsInvisible();
            pageNewAddres.ClickOnRadioButtonSelectAddres();
            pageNewAddres.ClickOnContinueButton();

            pageDeliveryAddress.WaitRadioButtonOneDayIsClickable();
            pageDeliveryAddress.ClickOnSelectOneDayRadioButton();
            pageDeliveryAddress.WaitContinueButtonIsClickable();
            pageDeliveryAddress.ClickOnContinueButton();

            pagePaymentOptions.WaitAddNewCardTextIsClickable();
            pagePaymentOptions.ClickOnAddNewCard();
            pagePaymentOptions.WaitNameTextBoxIsClickable();
            pagePaymentOptions.ClickOnNameTextBox();
            pagePaymentOptions.WriteOnNameTextBox(name);
            pagePaymentOptions.ClickOnCardNumberTextBox();
            pagePaymentOptions.WriteOnCardNumberTextBox(cardNumber);
            pagePaymentOptions.SelectMonth();
            pagePaymentOptions.SelectYear();
            pagePaymentOptions.WaitSubmitButtonIsClickable();
            pagePaymentOptions.ClickOnSubmitButton();
            pageAlerts.WaitUntilAlertIsInvisible();
            pagePaymentOptions.ClickOnRadioButtonCard();
            pageDeliveryAddress.ClickOnContinueButton();

            pageDeliveryAddress.ClickOnPlaceOrderAndPay();
            pageDeliveryAddress.WaitPageLoad();
            pageDeliveryAddress.ScrollDrownTotalPrice();

            //Verify confirmation message
            string confirmationPurchaseMessage = "Thank you for your purchase!";
            var confirmation = pageDeliveryAddress.GetConfirmationMessage();
            Console.WriteLine(confirmation);
            Assert.IsTrue(confirmation.Contains(confirmationPurchaseMessage), "The result did not bring the expected");

            //Verify total price
            var listOfItemPrices = pageDeliveryAddress.GetTotalPrice();
            Console.WriteLine(listOfItemPrices);
            Assert.AreEqual("3.87¤",listOfItemPrices, "Total price does not match");
        }

        [TestMethod]
        public void VerifyOrderStatus()
        {
            string emailRegistration = "ingrid@gmail.com";
            string passwordRegistration = "12345";

            var pageAlerts = new AlertsPage(driver);
            var pageHeaders = new HeadersPage(driver);
            var pageLogin = new LoginPage(driver);
            var pageOrderHistory = new OrderHistoryPage(driver);

            pageAlerts.ClickOnDissmis();
            pageAlerts.ClickOnButtonWeWantIt();
            pageHeaders.ClickOnAccount();
            pageHeaders.ClickOnLoggin();

            pageLogin.ClickOnEmailLoginTextBox();
            pageLogin.WriteOnEmailTextBoxLogin(emailRegistration);
            pageLogin.ClickOnPasswordLoginTextBox();
            pageLogin.WriteOnPasswordTextBoxLogin(passwordRegistration);
            pageLogin.ClickOnLoginButton();

            pageHeaders.ClickOnAccount();
            pageAlerts.WaitUntilAlertIsInvisible();
            pageHeaders.ClickOnOrdersAndPaymentButton();
            pageHeaders.ClickOnOrderHistoryButton();
            pageOrderHistory.WaitOderHistoryPageLoad();

            //1.Verify Status is in transit
            string orderStatusMessage = "In Transit";
            var statusMessage = pageOrderHistory.GetOrderStatus();
            Console.WriteLine(statusMessage);
            Assert.IsTrue(statusMessage.Contains(orderStatusMessage), "The result did not bring the expected");

            //2.Verify list of products has two items
            var quantityOfItems = pageOrderHistory.GetAmountOfProductsPurchased();
            Console.WriteLine(quantityOfItems);
            Assert.AreEqual(2, quantityOfItems,"Quantity of items does not match");

            //3. Verify sum of products purchased
            var firstProductPrice = pageOrderHistory.GetTotalPricesOfFirstItemPurchased();
            var secondProductPrice = pageOrderHistory.GetTotalPricesOfSecondItemPurchased();
          
            firstProductPrice = string.Join("", firstProductPrice.Split('¤')); //to delete a character
            secondProductPrice = string.Join("", secondProductPrice.Split('¤'));       

            double number1 = Convert.ToDouble(firstProductPrice); //To convert string to double
            double number2 = Convert.ToDouble(secondProductPrice);

            double sum = number1 + number2;
            double precision = 1e-6;
            Console.WriteLine(sum);
            Assert.AreEqual(2.88, sum, precision, "Total price does not match");          
        }

        [TestCleanup]
        public void TestCleanUp()
        {
            //To take Screenshot
            string testImage = "Test.jpeg";
            Screenshot ss = ((ITakesScreenshot)driver).GetScreenshot();
            ss.SaveAsFile(testImage, ScreenshotImageFormat.Jpeg);
            TestContext.AddResultFile(testImage);
            driver.Quit();
        }
    }
}
