using System.Collections.Generic;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class NavigationHelper : BaseHelper
    {
        private string baseUrl;

        public NavigationHelper(IWebDriver driver, string baseUrl) : base(driver)
        {
            this.baseUrl = baseUrl;
        }

        public void GoToGroupsPage()
        {
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void OpenHomePage()
        {
            driver.Navigate().GoToUrl(baseUrl + "addressbook/");
        }

        public void GoToAddNewContactMenu()
        {
            driver.FindElement(By.LinkText("add new")).Click();
        }

        public void ReturnToGroupsPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
        }
    }
}