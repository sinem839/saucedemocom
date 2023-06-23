using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SauceDemo.pages
{
    public class _Your_Cart_Page
    {
        private IWebDriver _seleniumDriver;

        private IWebElement _checkoutButton => _seleniumDriver.FindElement(By.XPath("//button[text()='Checkout']"));
        private IWebElement _continueShoppingButton => _seleniumDriver.FindElement(By.XPath("//button[text()='Continue Shopping']"));
        //   private IReadOnlyCollection<IWebElement> _removeButtonList => _seleniumDriver.FindElements(By.ClassName("cart_button"));
        private IReadOnlyCollection<IWebElement> _productCardList => _seleniumDriver.FindElements(By.ClassName("cart_item"));

        public _Your_Cart_Page(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
        public void ClickCheckoutButton() => _checkoutButton.Click();
        public void ClickContinueShoppingButton() => _continueShoppingButton.Click();
        public IWebElement GetCardItemByName(string productName) => _productCardList.Where(element => element.FindElement(By.ClassName("inventory_item_name")).Text.Contains(productName)).FirstOrDefault();
        public void ClickProductRemove(string productName) => GetCardItemByName(productName).FindElement(By.ClassName("cart_button")).Click();
    }
}

