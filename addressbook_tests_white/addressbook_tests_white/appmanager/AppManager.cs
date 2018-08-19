using TestStack.White;
using TestStack.White.UIItems;
using TestStack.White.UIItems.WindowItems;

namespace addressbook_tests_white
{
    public class AppManager
    {
        public static string WinTitle = "Free Address Book";
        private GroupHelper groupHelper;

        public GroupHelper GroupHelper
        {
            get => groupHelper;
            set => groupHelper = value;
        }

        public Window MainWindow { get; private set; }

        public AppManager()
        {
            Application app = Application.Launch(@"C:\FreeAddressBookPortable\AddressBook.exe");
            MainWindow = app.GetWindow(WinTitle);
            groupHelper = new GroupHelper(this);
        }

        public void Stop()
        {
            MainWindow.Get<Button>("uxExitAddressButton").Click();
        }
    }
}