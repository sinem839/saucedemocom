using OpenQA.Selenium;

namespace SauceDemo.pages
{
    public class _Login_Page
    {
        private IWebDriver _seleniumDriver;

        private string _signInPageURL = "https://www.saucedemo.com/";

        private IWebElement _username => _seleniumDriver.FindElement(By.Id("user-name"));
        private IWebElement _password => _seleniumDriver.FindElement(By.Id("password"));
        private IWebElement _loginButton => _seleniumDriver.FindElement(By.Id("login-button"));

        public _Login_Page(IWebDriver seleniumDriver)
        {
            _seleniumDriver = seleniumDriver;
        }
        public void NavigateToSignInPage() => _seleniumDriver.Navigate().GoToUrl(_signInPageURL);

        public void EnterUsernameAndPassword(string username, string password)
        {
            _username.SendKeys(username);
            _password.SendKeys(password);
        }

        public void ClickLoginButton() => _loginButton.Click();

        public string RetrieveErrorMessage()
        {
            try
            {
                return _seleniumDriver.FindElement(By.CssSelector("*[data-test=\"error\"]")).Text;
            }
            catch (NoSuchElementException e)
            {
                return "";
            }
        }
        public void ClickErrorMessageButton() => _seleniumDriver.FindElement(By.ClassName("error-button")).Click();
    }
}

