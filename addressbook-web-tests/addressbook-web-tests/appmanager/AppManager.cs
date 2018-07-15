using System;
using System.Threading;
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
        private static ThreadLocal<AppManager> app = new ThreadLocal<AppManager>();

        private AppManager()
        {
            var firefoxOptions = new FirefoxOptions
            {
                UseLegacyImplementation = true,
                BrowserExecutableLocation = @"C:\Program Files\Mozilla Firefox\firefox.exe"
                
            };
            driver = new FirefoxDriver(firefoxOptions);
            baseURL = "http://localhost/";

            LoginHelper = new LoginHelper(driver);
            ContactHelper = new ContactHelper(driver);
            NavigationHelper = new NavigationHelper(driver, baseURL);
            GroupHelper = new GroupHelper(driver);
        }

        ~AppManager()
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

        public static AppManager GetInstaneAppManager()
        {
            if (!app.IsValueCreated)
            {
                app.Value = new AppManager();
            }

            app.Value.navigationHelper.OpenHomePage();
            return app.Value;
        }
    }
}