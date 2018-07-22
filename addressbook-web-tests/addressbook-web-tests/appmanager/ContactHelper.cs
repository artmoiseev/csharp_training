using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
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
            driver.FindElement(By.XPath($"(//td[@class]//input[@id])[position()={contactId + 1}]")).Click();
            return this;
        }

        public ContactHelper RemoveContact(int contactId)
        {
            By by = By.XPath("//form[@accept-charset='utf-8']//div[2]//input[1]");
            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(by));

            SelectContact(contactId);
            driver.FindElement(by).Click();
            AcceptAlertMessage();
            return this;
        }

        public ContactHelper EditContact(int contactId, ContactData contactData)
        {
            var by = By.XPath($"(//img[@title=\"Edit\"])[position()={contactId + 1}]");

            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(by));

            driver.FindElement(by).Click();
            FillContactData(contactData);
            return this;
        }

        public void CreateNewContact(ContactData contactData)
        {
            AppManager.GetInstaneAppManager().NavigationHelper.GoToAddNewContactMenu();
            FillContactData(contactData);
            SubmitCreation();
        }

        public bool IsContactListEmpty()
        {
            return Convert.ToInt32(driver.FindElement(By.XPath("//span[@id='search_count']")).Text) == 0;
        }

        public void CreateContactIfContactListEmpty()
        {
            {
                if (IsContactListEmpty())
                {
                    CreateNewContact(new ContactData(
                        $"username{Guid.NewGuid()}",
                        $"userlastName{Guid.NewGuid()}"));
                }
            }
        }

        public List<ContactData> GetContactList()
        {
            AppManager.GetInstaneAppManager().NavigationHelper.OpenHomePage();
            List<ContactData> contactList = new List<ContactData>();
            ICollection<IWebElement> webElements = driver.FindElements(By.XPath("//tr[@name='entry']"));

            foreach (var webElement in webElements)
            {
                var firstName = webElement.FindElement(By.XPath(".//td[3]")).Text;
                var lastName = webElement.FindElement(By.XPath(".//td[2]")).Text;
                
                contactList.Add(new ContactData(
                    firstName, lastName)
                );
            }
            return contactList;
        }
    }
}