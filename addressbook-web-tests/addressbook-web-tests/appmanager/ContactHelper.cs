using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
            contactList = null;
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
            contactList = null;
            return this;
        }

        public ContactHelper EditContact(int contactId, ContactData contactData)
        {
            InitContactModification(contactId);
            FillContactData(contactData);
            return this;
        }

        public void InitContactModification(int contactId)
        {
            var by = By.XPath($"(//img[@title=\"Edit\"])[position()={contactId + 1}]");

            new WebDriverWait(driver, TimeSpan.FromSeconds(30)).Until(ExpectedConditions.ElementExists(by));

            driver.FindElement(@by).Click();
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

        private List<ContactData> contactList;

        public List<ContactData> GetContactList()
        {
            if (contactList == null)
            {
                AppManager.GetInstaneAppManager().NavigationHelper.OpenHomePage();
                contactList = new List<ContactData>();
                ICollection<IWebElement> webElements = driver.FindElements(By.XPath("//tr[@name='entry']"));

                foreach (var webElement in webElements)
                {
                    var firstName = webElement.FindElement(By.XPath(".//td[3]")).Text;
                    var lastName = webElement.FindElement(By.XPath(".//td[2]")).Text;

                    contactList.Add(new ContactData(
                        firstName, lastName)
                    );
                }
            }

            return new List<ContactData>(contactList);
        }


        public int GetContactCount()
        {
            AppManager.GetInstaneAppManager().NavigationHelper.OpenHomePage();
            return driver.FindElements(By.XPath("//tr[@name='entry']")).Count;
        }

        public ContactData GetContactInfoFromHomePage(int index)
        {
            AppManager.GetInstaneAppManager().NavigationHelper.OpenHomePage();
            IList<IWebElement> cells = driver.FindElements(By.XPath("//tr[@name = \"entry\"]"))[index]
                .FindElements(By.TagName("td"));
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;
            return new ContactData(firstName, lastName)
            {
                Address = address,
                AllPhones = allPhones,
                AllEmails = allEmails
            };
        }

        public ContactData GetContactsFromEditForm(int index)
        {
            AppManager.GetInstaneAppManager().NavigationHelper.OpenHomePage();
            InitContactModification(index);
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");
            string homePhone = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobilePhone = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workPhone = driver.FindElement(By.Name("work")).GetAttribute("value");
            string email1 = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");
            return new ContactData(firstName, lastName)
            {
                Address = address,
                HomePhone = homePhone,
                MobilePhone = mobilePhone,
                WorkPhone = workPhone,
                Email1 = email1,
                Email2 = email2,
                Email3 = email3
            };
        }

        public ContactData GetContactsFromDetailsForm(int index)
        {
            AppManager.GetInstaneAppManager().NavigationHelper.OpenHomePage();
            driver.FindElement(By.XPath($"//img[@alt=\"Details\"][{index + 1}]")).Click();
            return new ContactData {AllData = driver.FindElement(By.Id("content")).Text};
        }
    }
}