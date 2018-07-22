using System;
using System.Collections.Generic;
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

            driver.FindElement(By.XPath($"//form[@method='post']//span[{groupId + 1}]//input[1]")).Click();
            return this;
        }

        public GroupHelper InitGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper EditGroup(int groupId, GroupData data)
        {
            SelectGroup(groupId);
            driver.FindElement(By.Name("edit")).Click();
            FillGroupForm(data).SubmitModification();
            return this;
        }

        public GroupHelper RemoveGroup(int groupId)
        {
            SelectGroup(groupId);
            driver.FindElement(By.Name("delete")).Click();
            return this;
        }

        public void CreateGroupIfGroupListEmpty()
        {
            if (IsGroupListEmpty())
            {
                CreateNewGroup(new GroupData(
                    $"groupName{Guid.NewGuid()}",
                    $"groupHeader{Guid.NewGuid()}",
                    $"groupFooter{Guid.NewGuid()}"));
            }
        }

        public bool IsGroupListEmpty()
        {
            return driver.FindElements(By.XPath("//input[@type='checkbox']")).Count == 0;
        }

        public void CreateNewGroup(GroupData data)
        {
            InitGroupCreation().FillGroupForm(data).SubmitCreation();
        }

        public List<GroupData> GetGroupsList()
        {
            AppManager.GetInstaneAppManager().NavigationHelper.GoToGroupsPage();
            List<GroupData> groupList = new List<GroupData>();
            ICollection<IWebElement> elements = driver.FindElements(By.XPath("//span[@class='group']"));
            foreach (var webElement in elements)
            {
                groupList.Add(new GroupData(webElement.Text));
            }

            return groupList;
        }
    }
}