using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using SauceDemo.Website;
using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using Microsoft.VisualBasic.FileIO;

namespace SauceDemo.StepDefinitions
{
    [Binding]
    public class Products_PageStepDefinitions
    {
        private IWebDriver driver;

        private Website<ChromeDriver> Website = new Website<ChromeDriver>();

        public Products_PageStepDefinitions(IWebDriver driver)
        {
            this.driver = driver;
        }

        [Given(@"User is on the products page")]
        public void GivenUserIsOnTheProductsPage()
        {
            Website.Products_Page.GoToProductsPage();
            Website.Login_Page.NavigateToSignInPage();
            Website.Login_Page.EnterUsernameAndPassword("problem_user", "secret_sauce");
            Website.Login_Page.ClickLoginButton();
        }

        [When(@"User clicks to add to cart button")]
        public void WhenUserClicksToAddToCartButton()
        {
            Website.Products_Page.AddItemToCart();
        }

        [Then(@"The cart number must increase by one")]
        public void ThenTheCartNumberMustIncreaseByOne()
        {
            Assert.That(Website.Products_Page.GetCartItemCount(), Is.EqualTo(1));
        }

        [Then(@"The button for adding cart should change to ""([^""]*)""")]
        public void ThenTheButtonForAddingCartShouldChangeTo(string remove)
        {
            Assert.That(Website.Products_Page.GetRemoveButtonText(), Is.EqualTo(remove));
        }

        [When(@"User clicks to add to cart button of ""([^""]*)"" item")]
        public void WhenUserClicksToAddToCartButtonOfItem(string product)
        {
            Website.Products_Page.ClickProductName(product);
        }

        [Then(@"The cart number must increase by two")]
        public void ThenTheCartNumberMustIncreaseByTwo()
        {
            Assert.That(Website.Products_Page.GetCartItemCount(), Is.EqualTo(1));
        }

        [Then(@"The button for adding cart of ""([^""]*)"" item should change to ""([^""]*)""")]
        public void ThenTheButtonForAddingCartOfItemShouldChangeTo(string product, string remove)
        {
            Website.Products_Page.ClickProductName(product);
            Assert.That(Website.Products_Page.GetRemoveButtonText(), Is.EqualTo(remove));
        }

        [When(@"He/she clicks to remove button")]
        public void WhenHeSheClicksToRemoveButton()
        {
            Website.Products_Page.RemoveItemFromCart();
        }

        [Then(@"The card number must be one less")]
        public void ThenTheCardNumberMustBeOneLess()
        {
            Assert.That(Website.Products_Page.GetCartItemCount(), Is.EqualTo(0));
        }

        [Then(@"The button for removing item should change to ""([^""]*)""")]
        public void ThenTheButtonForRemovingItemShouldChangeTo(string button)
        {
            Assert.That(Website.Products_Page.GetRemoveButtonText(), Is.EqualTo(button));
        }

        [When(@"User clicks to item description in order to display added item")]
        public void WhenUserClicksToItemDescriptionInOrderToDisplayAddedItem()
        {
            Website.Products_Page.ClickProductName("Sauce Labs Onesie");
        }

        [Then(@"User can remove that item from cart")]
        public void ThenUserCanRemoveThatItemFromCart()
        {
            Assert.That(Website.Products_Page.GetAddOrRemoveButtonText().ToLower(), Is.EqualTo("remove"));
        }

        [When(@"User selects Name \(A to Z\) ""([^""]*)"" option")]
        public void WhenUserSelectsNameAToZOption(string option)
        {
            Website.Products_Page.FilterProducts(option);
        }

        [Then(@"The products are filtered alphabetically")]
        public void ThenTheProductsAreFilteredAlphabetically()
        {
            Assert.That(Website.Products_Page.CheckProductsSortedAlphabetically(true), Is.True);
        }

        [When(@"User selects Name \(Z to A\) ""([^""]*)"" option")]
        public void WhenUserSelectsNameZToAOption(string option)
        {
            Website.Products_Page.FilterProducts(option);
        }

        [Then(@"The products are filtered in reverse alphabetical order")]
        public void ThenTheProductsAreFilteredInReverseAlphabeticalOrder()
        {
            Assert.That(Website.Products_Page.CheckProductsSortedAlphabetically(false), Is.True);
        }

        [When(@"User selects Price \(low to high\) ""([^""]*)"" option")]
        public void WhenUserSelectsPriceLowToHighOption(string option)
        {
            Website.Products_Page.FilterProducts(option);
        }

        [Then(@"The products are filtered in ascending price")]
        public void ThenTheProductsAreFilteredInAscendingPrice()
        {
            Assert.That(Website.Products_Page.GetListOfProductsPrices(), Is.Ordered.Ascending);
        }

        [When(@"User selects Price \(high to low\) ""([^""]*)"" option")]
        public void WhenUserSelectsPriceHighToLowOption(string option)
        {
            Website.Products_Page.FilterProducts(option);
        }

        [Then(@"The products are filtered in descending price")]
        public void ThenTheProductsAreFilteredInDescendingPrice()
        {
            Assert.That(Website.Products_Page.GetListOfProductsPrices(), Is.Ordered.Descending);
        }
    }
}
