using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Website;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using System.Threading.Channels;

namespace SauceDemo.StepDefinitions
{
    [Binding]
    public class Checkout_Overview_PageStepDefinitions
    {
        private IWebDriver driver;

        private Website<ChromeDriver> Website = new Website<ChromeDriver>();

        public Checkout_Overview_PageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User has logged into the system")]
        public void GivenUserHasLoggedIntoTheSystem()          
        {
            Website.Login_Page.NavigateToSignInPage();
            Website.Login_Page.EnterUsernameAndPassword("standard_user", "secret_sauce");
            Website.Login_Page.ClickLoginButton();
        }

        [Given(@"User is on the checkout overview page")]
        public void GivenUserIsOnTheCheckoutOverviewPage()
        {
            Website.Checkout_Overview_Page.OnTheCheckoutTwoPage();
        }

        [When(@"User clicks to ""([^""]*)"" button")]
        public void WhenUserClicksToButton(string button)
        {
            Website.Checkout_Overview_Page.PressButton(button);
        }

        [Then(@"User should be directed to the Products Page")]
        public void ThenUserShouldBeDirectedToTheProductsPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Then(@"Order operation should be completed")]
        public void ThenOrderOperationShouldBeCompleted()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-complete.html"));
        }
    }
}
