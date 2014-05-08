using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptManagement.Common.Helpers;
using Common = ReceiptManagement.Common;

namespace ReceiptManagement.Bll.Managers
{
    public class UserManager
    {
        public Common.Entities.User GetUsers(ApiContext apiContext, int id)
        {
            Common.Entities.User user = new Common.Entities.User();

            ReceiptManagement.Core.Managers.UserManager.Get(apiContext,id,out user);

            return user;
            
        }
    }
}
