using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptManagement.Common.Helpers;
using ReceiptManagement.Common.Entities;
using ReceiptManagement.Core;
using ReceiptManagement.Bll.Managers;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public static System.String connectionString = "Data Source=.\\SQL2008;Initial Catalog=ORMS;User Id=sa;Password=click123;";
        public static ReceiptManagement.Common.Helpers.ApiContext apiContext = ReceiptManagement.Common.Helpers.ApiContext.Factory(connectionString);

        [TestMethod]
        public void TestMethod1()
        {           
             new UserManager().GetUsers(apiContext,3);
        }
    }
}
