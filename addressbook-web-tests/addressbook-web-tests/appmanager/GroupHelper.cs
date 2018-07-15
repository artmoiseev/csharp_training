using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;

namespace WebAddressBookTests
{
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(IWebDriver driver) : base(driver)
        {
        }

        public GroupHelper FillGroupForm(GroupData groupData)
        {
            Type(By.Name("group_name"), groupData.GroupName);
            Type(By.Name("group_header"), groupData.GroupHeader);
            Type(By.Name("group_footer"), groupData.GroupFooter);
            return this;
        }

        public GroupHelper SelectGroup(int groupId)
        {
            if (!(driver.Url.Contains("group.php") && IsElementPresent(By.XPath("//input[@value='New group']"))))
            {
                AppManager.GetInstaneAppManager().NavigationHelper.GoToGroupsPage();
            }

            driver.FindElement(By.XPath($"//form[@method='post']//span[{groupId}]//input[1]")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper EditGroup(int groupId, GroupData data)
        {
            if (IsGroupListEmpty())
            {
                CreateNewGroup(new GroupData(
                    $"groupName{Guid.NewGuid()}",
                    $"groupHeader{Guid.NewGuid()}",
                    $"groupFooter{Guid.NewGuid()}"));
            }

            SelectGroup(groupId);
            driver.FindElement(By.Name("edit")).Click();
            FillGroupForm(data).SubmitModification();
            return this;
        }

        public GroupHelper RemoveGroup(int groupId)
        {
            if (IsGroupListEmpty())
            {
                CreateNewGroup(new GroupData(
                    $"groupName{Guid.NewGuid()}",
                    $"groupHeader{Guid.NewGuid()}",
                    $"groupFooter{Guid.NewGuid()}"));
            }

            SelectGroup(groupId);
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        private bool IsGroupListEmpty()
        {
            return driver.FindElements(By.XPath("//input[@type='checkbox']")).Count == 0;
        }

        public void CreateNewGroup(GroupData data)
        {
            InitGroupCreation().FillGroupForm(data).SubmitCreation();
        }
    }
}