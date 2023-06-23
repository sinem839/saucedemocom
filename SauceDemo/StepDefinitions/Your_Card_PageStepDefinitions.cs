using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Website;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;

namespace SauceDemo.StepDefinitions
{
    [Binding]
    public class Your_Card_PageStepDefinitions
    {
        private IWebDriver driver;

        private Website<ChromeDriver> Website = new Website<ChromeDriver>();
        private string _productName;

        [BeforeScenario]
        public void SetUp()
        {
            Website = new Website<ChromeDriver>();
        }

        [Given(@"User need to log into the system")]
        public void GivenUserNeedToLogIntoTheSystem()
        {
            Website.Login_Page.NavigateToSignInPage();
            Website.Login_Page.EnterUsernameAndPassword("problem_user", "secret_sauce");
            Website.Login_Page.ClickLoginButton();
        }

        [Given(@"User clicks to add to cart button of ""([^""]*)"" item")]
        public void GivenUserClicksToAddToCartButtonOfItems(string productName)
        {
            Website.Products_Page.GoToProductsPage();
            Website.Products_Page.AddItemToCart();
        }

        [Given(@"User switches to cart page")]
        public void GivenUserSwitchesToCartPage() 
        {
            Website.Products_Page.GoToCartPage();
        }

        [When(@"User clicks continue shopping button")]
        public void WhenUserClicksContinueShoppingButton()
        {
            Website.Your_Cart_Page.ClickContinueShoppingButton();
        }


        [When(@"User clicks remove button of ""([^""]*)"" item")]
        public void WhenUserClicksRemoveButtonOfItem(string productName)
        {
            _productName = productName;
            Website.Your_Cart_Page.ClickProductRemove(productName);
        }

        [When(@"User clicks the checkout button")]
        public void WhenUserClicksTheCheckoutButton()
        {
            Website.Your_Cart_Page.ClickCheckoutButton();
        }

        [Then(@"User should be directed to the products page")]
        public void ThenUserShouldBeDirectedToTheProductsPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/inventory.html"));
        }

        [Then(@"The product should be removed from the card")]
        public void ThenTheProductShouldBeRemovedFromTheCard()
        {
            Assert.That(Website.Your_Cart_Page.GetCardItemByName(_productName), Is.Null);
        }

        [Then(@"User should be on the checkout page")]
        public void ThenUserShouldBeOnTheCheckoutPage()
        {
            Assert.That(Website.SeleniumDriver.Url, Is.EqualTo("https://www.saucedemo.com/checkout-step-one.html"));
        }

        [AfterScenario]
        public void TearDown()
        {
            Website.SeleniumDriver.Dispose();
            Website.SeleniumDriver.Quit();
        }
    }
}
