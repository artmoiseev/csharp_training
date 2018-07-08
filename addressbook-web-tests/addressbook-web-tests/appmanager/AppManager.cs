using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;

namespace WebAddressBookTests
{
    public class AppManager
    {
        private IWebDriver driver;

        private string baseURL;

        protected LoginHelper loginHelper;
        protected ContactHelper contactHelper;
        protected NavigationHelper navigationHelper;
        protected GroupHelper groupHelper;

        public AppManager()
        {
            FirefoxOptions firefoxOptions = new FirefoxOptions
            {
                UseLegacyImplementation = true,
                BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe"
            };
            driver = new FirefoxDriver(firefoxOptions);
            baseURL = "http://localhost/";

            this.LoginHelper = new LoginHelper(driver);
            this.ContactHelper = new ContactHelper(driver);
            this.NavigationHelper = new NavigationHelper(driver, baseURL);
            this.GroupHelper = new GroupHelper(driver);
        }

        public LoginHelper LoginHelper
        {
            get { return loginHelper; }
            set { loginHelper = value; }
        }

        public ContactHelper ContactHelper
        {
            get { return contactHelper; }
            set { contactHelper = value; }
        }

        public NavigationHelper NavigationHelper
        {
            get { return navigationHelper; }
            set { navigationHelper = value; }
        }

        public GroupHelper GroupHelper
        {
            get { return groupHelper; }
            set { groupHelper = value; }
        }

        public void Stop()
        {
            {
                try
                {
                    driver.Quit();
                }
                catch (Exception)
                {
                    // Ignore errors if unable to close the browser
                }
            }
        }
    }
}