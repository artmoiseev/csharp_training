using System;
using System.ComponentModel;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public ContactHelper FillContactData(ContactData contactData)
        {
            Type(By.Name("firstname"), contactData.Firstname);
            Type(By.Name("lastname"), contactData.LastName);
            return this;
        }

        public ContactHelper SelectContact(int contactId)
        {
            driver.FindElement(By.XPath($"(//td[@class]//input[@id])[position()={contactId}]")).Click();
            return this;
        }

        public ContactHelper RemoveContact(int contactId)
        {
            if (IsContactListEmpty())
            {
                CreateNewContact();
            }

            By by = By.XPath("//form[@accept-charset='utf-8']//div[2]//input[1]");
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(by));

            SelectContact(contactId);
            driver.FindElement(by).Click();
            AcceptAlertMessage();
            return this;
        }

        public ContactHelper EditContact(int contactId, ContactData contactData)
        {
            if (IsContactListEmpty())
            {
                CreateNewContact();
            }

            var by = By.XPath($"(//img[@title=\"Edit\"])[position()={contactId}]");

            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(by));

            driver.FindElement(by).Click();
            FillContactData(contactData);
            return this;
        }

        public void CreateNewContact()
        {
            AppManager.GetInstaneAppManager().NavigationHelper.GoToAddNewContactMenu();
            FillContactData(new ContactData(
                $"username{Guid.NewGuid()}",
                $"userlastName{Guid.NewGuid()}"));
            SubmitCreation();
        }

        private bool IsContactListEmpty()
        {
            return Convert.ToInt32(driver.FindElement(By.XPath("//span[@id='search_count']")).Text) == 0;
        }
    }
}