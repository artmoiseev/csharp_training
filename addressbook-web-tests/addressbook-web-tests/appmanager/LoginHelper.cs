using System;
using OpenQA.Selenium;

namespace WebAddressBookTests
{
    public class LoginHelper : BaseHelper
    {
        public LoginHelper(IWebDriver driver) : base(driver)
        {
        }

        public void Login(AccountData account)
        {
            if (IsLoggedIn())
            {
                if (IsLoggedIn(account))
                {
                    return;
                }

                Logout();
            }

            Type(By.Name("user"), account.Username);
            Type(By.Name("pass"), account.Password);
            driver.FindElement(By.XPath("//input[@type='submit']")).Click();
        }

        public void Logout()
        {
            driver.FindElement(By.LinkText("Logout")).Click();
        }

        public bool IsLoggedIn(AccountData account)
        {
            return IsLoggedIn() && IsElementPresent(By.XPath($"//b[contains(text(),\'({account.Username})\')]"));
        }

        public bool IsLoggedIn()
        {
            return IsElementPresent(By.LinkText("Logout"));
        }
    }
}