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

        public BaseHelper AcceptAlertMessage()
        {
            driver.SwitchTo().Alert().Accept();
            return this;
        }

        public BaseHelper SubmitModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        protected void Type(By by, string data)
        {
            if (data == null) return;
            driver.FindElement(by).Clear();
            driver.FindElement(by).SendKeys(data);
        }

        public bool IsElementPresent(By by)
        {
            try
            {
                driver.FindElement(by);
                return true;
            }
            catch (NoSuchElementException)
            {
                return false;
            }
        }
    }
}