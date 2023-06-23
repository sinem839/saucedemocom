using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SauceDemo.Website;
using System;
using TechTalk.SpecFlow;

namespace SauceDemo.StepDefinitions
{
    [Binding]
    public class Login_PageStepDefinitions
    {
        private IWebDriver driver;

        private Website<ChromeDriver> Website = new Website<ChromeDriver>();

        public Login_PageStepDefinitions(IWebDriver driver) 
        {
             this.driver = driver;
        }

        [Given(@"User is on the login page")]
        public void GivenUserIsOnTheLoginPage()
        {
            Website.Login_Page.NavigateToSignInPage();
        }

        [When(@"User enters a username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenUserEntersAUsernameStandard_UserAndPasswordSecret_Sauce(string username, string password)
        {
            Website.Login_Page.EnterUsernameAndPassword(username, password);
        }

        [When(@"User enters an invalid username ""([^""]*)"" and password ""([^""]*)""")]
        public void WhenUserEntersAnInvalidUsernameAndPassword(string username, string password)
        {
            Website.Login_Page.EnterUsernameAndPassword(username, password);
        }

        [When(@"User enters an username ""([^""]*)"" and invalid password ""([^""]*)""")]
        public void WhenUserEntersAnUsernameAndInvalidPassword(string username, string password)
        {
            Website.Login_Page.EnterUsernameAndPassword(username, password);
        }

        [When(@"User enters a password ""([^""]*)"" without username")]
        public void WhenUserEntersAPasswordWithoutUsername(string password)
        {
            Website.Login_Page.EnterUsernameAndPassword("", password);
        }

        [When(@"User enters a username ""([^""]*)"" without password")]
        public void WhenUserEntersAUsernameWithoutPassword(string username)
        {
            Website.Login_Page.EnterUsernameAndPassword(username, "");
        }

        [When(@"User doesn't enter any information")]
        public void WhenUserDoesntEnterAnyInformation()
        {
            Website.Login_Page.EnterUsernameAndPassword("", "");
        }

        [When(@"User clicks the login button")]
        public void WhenUserClicksTheLoginButton()
        {
            Website.Login_Page.ClickLoginButton();
        }

        [Then(@"User should receive an error message as ""([^""]*)""")]
        public void ThenUserShouldReceiveAnErrorMessageAs(string error)
        {
            Assert.That(Website.Login_Page.RetrieveErrorMessage(), Does.Contain(error));
        }

        [Then(@"User should be redirected to the products page")]
        public void ThenUserShouldBeRedirectedToThePage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        } 

        /*[AfterScenario]
        public void TearDown()
        {
            driver.Dispose();
            driver.Quit();
        }*/
    }
}

