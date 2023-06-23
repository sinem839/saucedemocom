using OpenQA.Selenium;

namespace SeleniumPOM.Drivers
{
    public class SeleniumDriverConfig<T> where T : IWebDriver, new()
    {
        private IWebDriver driver;

        public T Driver { get; set; }

        public SeleniumDriverConfig(int pageLoadInSecs, int implicitWaitInSecs)
        {
            DriverSetUp(pageLoadInSecs, implicitWaitInSecs);
        }

        public void DriverSetUp(int pageLoadInSecs, int implicitWaitInSecs)
        {
            SetDriver();
            SetDriverConfiguration(pageLoadInSecs, implicitWaitInSecs);
        }

        public void SetDriver()
        {
            Driver = new T();
        }

        public void SetDriverConfiguration(int pageLoadInSecs, int implicitWaitInSecs)
        {
            Driver.Manage().Timeouts().PageLoad = TimeSpan.FromSeconds(pageLoadInSecs);
            Driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(implicitWaitInSecs);
        }
    }
}