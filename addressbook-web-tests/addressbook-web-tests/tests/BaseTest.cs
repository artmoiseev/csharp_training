using System;
using System.Collections.Generic;
using System.Text;
using NUnit.Framework;

namespace WebAddressBookTests
{
    public class BaseTest
    {
        protected AppManager appManager;

        [SetUp]
        public void SetupAppManager()
        {
            appManager = AppManager.GetInstaneAppManager();
        }

        public static Random rnd = new Random();

        public static string GenerateRandomString(int maxSymbols)
        {
            int l = Convert.ToInt32(rnd.NextDouble() * maxSymbols);
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < l; i++)
            {
                builder.Append(Convert.ToChar(Convert.ToInt32(rnd.NextDouble() * 65)));
            }

            return builder.ToString();
        }
    }
}