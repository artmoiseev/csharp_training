using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class ContactHelper : BaseHelper
    {
        public ContactHelper(IWebDriver driver) : base(driver)
        {
        }

        public ContactHelper FillContactData(ContactData contactData)
        {
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contactData.Firstname);
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contactData.LastName);
            return this;
        }

        public ContactHelper SelectContact(int contactId)
        {
            driver.FindElement(By.XPath($"//input[@id='{contactId}']")).Click();
            return this;
        }

        public ContactHelper RemoveContact()
        {
            driver.FindElement(By.XPath("//form[@accept-charset='utf-8']//div[2]//input[1]")).Click();
            AcceptAlertMessage();
            return this;
        }

        public ContactHelper EditContact(int contactId)
        {
            driver.FindElement(By.XPath($"(//img[@title=\"Edit\"])[position()={contactId}]")).Click();
            return this;
        }
    }
}