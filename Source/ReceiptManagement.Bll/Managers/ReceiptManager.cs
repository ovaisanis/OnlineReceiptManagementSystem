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
    public class ReceiptManager
    {
        #region List

        public List<Entities.Receipt> Get(ApiContext apiContext,int userId)
        {
            var list = new List<Entities.Receipt>();

            try
            {
                var querySettings = QuerySettings<Entities.Receipt>.Factory();

                //Include Entities             

                //Filter records
                querySettings.WhereExpression = rc => rc.UserId == userId;

                CoreManagers.ReceiptManager.Get(apiContext, querySettings, out list);               

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region Insert

        /// <summary>
        ///     Insert
        /// </summary>
        /// <param name = "apiContext"></param>
        /// <param name = "info"></param>
        /// <returns></returns>
        public bool Insert(ApiContext apiContext, Common.Entities.Receipt receipt)
        {
            try
            {
                var result = CoreManagers.ReceiptManager.Add(apiContext, new List<Common.Entities.Receipt> { receipt });

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
