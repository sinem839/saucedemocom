using OpenQA.Selenium;

namespace SauceDemo.pages
{
    public class _Checkout_Overview_Page
    {
        private IWebDriver _seleniumDriver;

        private string checkoutTwoUrl = "https://www.saucedemo.com/checkout-step-two.html";
        private IWebElement _item => _seleniumDriver.FindElement(By.ClassName("inventory_item_name"));
        private IWebElement _finish => _seleniumDriver.FindElement(By.ClassName("cart_button"));
        private IWebElement _cancel => _seleniumDriver.FindElement(By.ClassName("cart_cancel_link"));

        public _Checkout_Overview_Page(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }

        public void OnTheCheckoutTwoPage()
        {
            _seleniumDriver.Navigate().GoToUrl(checkoutTwoUrl);
        }

        public void ClickOnItem()
        {
            _item.Click();
        }
        public void PressButton(string button)
        {
            if (button == "Finish")
            {
                _finish.Click();
            }
            else
            {
                _cancel.Click();
            }
        }
    }
}
