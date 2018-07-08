using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class BaseHelper
    {
        protected IWebDriver driver;

        public BaseHelper(IWebDriver driver)
        {
            this.driver = driver;
        }

        public BaseHelper SubmitCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            return this;
        }
    }
}