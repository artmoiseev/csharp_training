using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Threading;
using System.Windows.Automation;
using addressbook_tests_white.models;
using NUnit.Framework;
using TestStack.White.InputDevices;
using TestStack.White.UIItems;
using TestStack.White.UIItems.Finders;
using TestStack.White.UIItems.TreeItems;
using TestStack.White.UIItems.WindowItems;
using TestStack.White.WindowsAPI;

namespace addressbook_tests_white
{
    public class GroupHelper : BaseHelper
    {
        public GroupHelper(AppManager manager) : base(manager)
        {
        }

        public List<GroupData> GetGroupsList()
        {
            var list = new List<GroupData>();
            var dialogue = OpenGroupsDialogue();
            var tree = dialogue.Get<Tree>("uxAddressTreeView");
            var root = tree.Nodes[0];
            foreach (var item in root.Nodes)
            {
                list.Add(new GroupData
                {
                    GroupName = item.Text
                });
            }

            CloseGroupsDialogue(dialogue);
            return list;
        }

        public void Add(GroupData newGroup)
        {
            var dialogue = OpenGroupsDialogue();
            dialogue.Get<Button>("uxNewAddressButton").Click();
            TextBox textBox = (TextBox) dialogue.Get(SearchCriteria.ByControlType(ControlType.Edit));
            textBox.Enter(newGroup.GroupName);
            Keyboard.Instance.PressSpecialKey(KeyboardInput.SpecialKeys.RETURN);
            CloseGroupsDialogue(dialogue);
        }

        private Window OpenGroupsDialogue()
        {
            manager.MainWindow.Get<Button>("groupButton").Click();
            return manager.MainWindow.ModalWindow(GroupWinTitle);
        }

        private void CloseGroupsDialogue(Window dialogue)
        {
            dialogue.Get<Button>("uxCloseAddressButton").Click();
        }

        public static string GroupWinTitle = "Group editor";

        public void RemoveGroup(int indexOfGroupToDelete)
        {
            var dialogue = OpenGroupsDialogue();
            var tree = dialogue.Get<Tree>("uxAddressTreeView");
            var root = tree.Nodes[0];
            root.Nodes[indexOfGroupToDelete].Click();
            Window removeGroupDialogue = ClickDeleteButton(dialogue);
            removeGroupDialogue.Get<Button>("uxOKAddressButton").Click(); //uxOKAddressButton
            CloseGroupsDialogue(dialogue);
        }

        private Window ClickDeleteButton(Window dialogue)
        {
            dialogue.Get<Button>("uxDeleteAddressButton").Click();
            return dialogue.ModalWindow("Delete group");
        }
    }
}