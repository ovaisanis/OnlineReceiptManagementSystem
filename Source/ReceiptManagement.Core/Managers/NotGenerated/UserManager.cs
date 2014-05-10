using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Entities = ReceiptManagement.Common.Entities;
using Helpers = ReceiptManagement.Common.Helpers;

namespace ReceiptManagement.Core.Managers
{
    public partial class UserManager
    {
        static partial void OnAdding(Helpers.ApiContext apiContext, Entities.User user)
        {
            user.CreatedOn = DateTime.Now;
            user.LastLogin = DateTime.Now;
        }
    }
}
