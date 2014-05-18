using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ReceiptManagement.Common.Helpers;
using Entities = ReceiptManagement.Common.Entities;
using CoreManagers = ReceiptManagement.Core.Managers;

namespace ReceiptManagement.Bll.Managers
{
    public class UserManager
    {
        public Entities.User GetUsers(ApiContext apiContext, int id)
        {
            Entities.User user = new Entities.User();

            CoreManagers.UserManager.Get(apiContext, id, out user);

            return user;
            
        }

        public Entities.User IsExists(ApiContext apiContext, string email, string password)
        {
            Entities.User user = null;

            var querySettings = QuerySettings<Entities.User>.Factory();
            querySettings.WhereExpression = e => e.Email == email && e.Password == password;

            CoreManagers.UserManager.IsExists(apiContext,querySettings.WhereExpression,out user);

            //Check if user is active or not
            if (user != null && !user.IsActive)
                user = null;
            
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
