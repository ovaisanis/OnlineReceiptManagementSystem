using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReceiptManagement.Common.Helpers;
using ReceiptManagement.RESTfulAPI.Models;

namespace ReceiptManagement.RESTfulAPI.Common
{
    public class Context
    {
        private static List<UserInfo> userList = new List<UserInfo>();

        private Context() 
        {
           // userList = new List<UserInfo>();
        }
        

        private static System.String connectionString = "Data Source=.\\SQL2008;Initial Catalog=ORMS;User Id=sa;Password=click123;";
       // private static ReceiptManagement.Common.Helpers.ApiContext apiContext = ReceiptManagement.Common.Helpers.ApiContext.Factory(connectionString);

        private static ApiContext sharedContext;
      
        public static ApiContext GetContext() 
        {
            if(sharedContext == null) 
            {
                sharedContext = ApiContext.Factory(connectionString);
            }

            return sharedContext;
        }

        public static void AddUser(UserInfo userInfo)
        {            
            userList.Add(userInfo);
        }

        public static string GeneratePublicApiKey()
        {
            return Guid.NewGuid().ToString();
        }
    }
}