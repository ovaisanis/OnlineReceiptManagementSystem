using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using ReceiptManagement.Common.Helpers;
using ReceiptManagement.Common.Entities;
using ReceiptManagement.Core;
using ReceiptManagement.Bll.Managers;
using ReceiptManagement.Common.Helpers.Common;

namespace UnitTestProject
{
    [TestClass]
    public class UnitTest1
    {
        public static System.String connectionString = "Data Source=.\\SQL2008;Initial Catalog=ORMS;User Id=sa;Password=click123;";
        public static ReceiptManagement.Common.Helpers.ApiContext apiContext = ReceiptManagement.Common.Helpers.ApiContext.Factory(connectionString);

        [TestMethod]
        public void GetUser()
        {           
             new UserManager().GetUsers(apiContext,3);
        }

        [TestMethod]
        public void InsertUser()
        {
            ReceiptManagement.Common.Entities.User user = new ReceiptManagement.Common.Entities.User();

            user.FirstName = "Faisal";
            user.LastName = "Nasir";
            user.Password = "123";
            user.Email = "mfaisal.nasir@hotmail.com";
            user.RoleId = Roles.User;
            user.IsActive = true;
            new UserManager().Insert(apiContext, user);
        }

        [TestMethod]
        public void IsUserExists()
        {
             string email = "mfaisal.nasir@hotmail.com";
             string password = "123";
             var user = new UserManager().IsExists(apiContext, email, password);

            
        }

        [TestMethod]
        public void InsertImage()
        {
            ReceiptManagement.Common.Entities.Image image = new ReceiptManagement.Common.Entities.Image();

            image.CreatedOn = DateTime.Now;
            image.FileSize = 1000;
            image.Title = "Faisal";
            image.Path = "C:\\";
            image.FileFormat = "jpg";
            image.IsDeleted = false;

            long id = 0;

            new ImageManager().Insert(apiContext, image,out id);
        }
    }
}

