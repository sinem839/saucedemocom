using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Website;
using System.Collections.Generic;
using System.Xml.Linq;
using TechTalk.SpecFlow;

namespace SauceDemo.StepDefinitions
{
    [Binding]
    public class Checkout_PageStepDefinitions
    {
        private IWebDriver driver;

        private Website<ChromeDriver> Website = new Website<ChromeDriver>();

        public Checkout_PageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }


        [BeforeScenario]
        public void SetUp()
        {
            Website = new Website<ChromeDriver>();
        }

        [Given(@"User has logged into the system as ""([^""]*)"" with the password ""([^""]*)""")]
        public void GivenUserHasLoggedIntoTheSystemAsWithThePassword(string username, string password)
        {
            Website.Login_Page.NavigateToSignInPage();
            Website.Login_Page.EnterUsernameAndPassword("standard_user", "secret_sauce");
            Website.Login_Page.ClickLoginButton();
        }

        [Given(@"User is in the checkout page")]
        public void GivenUserIsInTheCheckoutPage()
        {
            Website.Checkout_Page.OnTheCheckoutPage();
        }

        [When(@"User fills out ""([^""]*)"", ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserFillsOutAnd(string firstname, string lastname, string postalcode)
        {
            Website.Checkout_Page.EnterFirstName(firstname);
            Website.Checkout_Page.EnterLastName(lastname);
            Website.Checkout_Page.EnterPostCode(postalcode);
        }

        [When(@"User fills out ""([^""]*)"" and ""([^""]*)""")]
        public void WhenUserFillsOutAnd(string _input1, string _input2)
        {
            if (_input1 == "firstname" && _input2 == "lastname")
            { 
                Website.Checkout_Page.EnterFirstName(_input1);
                Website.Checkout_Page.EnterLastName(_input2); 
            }
            if (_input1 == "lastname" && _input2 == "postcode")
            { 
                Website.Checkout_Page.EnterLastName(_input1);
                Website.Checkout_Page.EnterPostCode(_input2);
            }
            if (_input1 == "firstname" && _input2 == "postcode")
            {
                Website.Checkout_Page.EnterFirstName(_input1);
                Website.Checkout_Page.EnterPostCode(_input2);               
            }
        } 

        [When(@"User enter to ""([^""]*)"" button")]
        public void WhenUserEnterToButton(string button)
        {
            Website.Checkout_Page.PressButton(button);
        }

        [When(@"User clicks to ""([^""]*)"" button without entering any information")]
        public void WhenUserClicksToButtonWithoutEnteringAnyInformation(string button)
        {
            Website.Checkout_Page.PressButton(button);
            Assert.That(Website.Login_Page.RetrieveErrorMessage(), Does.Contain("First Name is required"));
        }

        [Then(@"User should be directed to the checkout overview page")]
        public void ThenUserShouldBeDirectedToTheCheckoutOverviewPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-two.html"));
        }

        [Then(@"User should receive the error message as ""([^""]*)""")]
        public void ThenUserShouldReceiveTheErrorMessageAsError(string error)
        {
            Assert.That(Website.Checkout_Page.RetrieveErrorMessage(), Does.Contain(error));
        }

        [Then(@"User should be directed to the your cart page")]
        public void ThenUserShouldBeDirectedToTheYourCartPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/cart.html"));
        }

        [AfterScenario]
        public void TearDown()
        {
            Website.SeleniumDriver.Dispose();
            Website.SeleniumDriver.Quit();
        }
    }
}
