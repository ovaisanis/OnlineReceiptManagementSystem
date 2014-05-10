using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptManagement.Common.Helpers;
using Common = ReceiptManagement.Common;
using CoreManagers = ReceiptManagement.Core.Managers;

namespace ReceiptManagement.Bll.Managers
{
    public class UserManager
    {
        public Common.Entities.User GetUsers(ApiContext apiContext, int id)
        {
            Common.Entities.User user = new Common.Entities.User();

            CoreManagers.UserManager.Get(apiContext, id, out user);

            return user;
            
        }

        #region Insert

        /// <summary>
        ///     Insert
        /// </summary>
        /// <param name = "apiContext"></param>
        /// <param name = "info"></param>
        /// <returns></returns>
        public bool Insert(ApiContext apiContext, Common.Entities.User user)
        {
            try
            {
                var result = CoreManagers.UserManager.Add(apiContext, new List<Common.Entities.User> { user });

                if (!result.WasSuccessful)
                {
                    return false;
                }

                return true;
            }           
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
