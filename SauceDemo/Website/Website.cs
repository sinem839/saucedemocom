using OpenQA.Selenium;
using SauceDemo.pages;
using SeleniumPOM.Drivers;

namespace SauceDemo.Website
{
    public class Website<T> where T : IWebDriver, new()
    {
        public IWebDriver SeleniumDriver { get; internal set; }
        public _Login_Page Login_Page { get; set; }
        public _Products_Page Products_Page { get; set; }
        public _Your_Cart_Page Your_Cart_Page { get; set; }
        public _Checkout_Page Checkout_Page { get; set; }
        public _Checkout_Overview_Page Checkout_Overview_Page { get; set; }

        public Website(int pageLoadWaitInSecs = 5, int implicitWaitInSecs = 5)
        {
            SeleniumDriver = new SeleniumDriverConfig<T>(pageLoadWaitInSecs, implicitWaitInSecs).Driver;

            Login_Page = new _Login_Page(SeleniumDriver);
            Products_Page = new _Products_Page(SeleniumDriver);
            Your_Cart_Page = new _Your_Cart_Page(SeleniumDriver);
            Checkout_Page = new _Checkout_Page(SeleniumDriver);
            Checkout_Overview_Page = new _Checkout_Overview_Page(SeleniumDriver);
        }

        public void DeleteCookies()
        {
            SeleniumDriver.Manage().Cookies.DeleteAllCookies();
        }
    }
}
