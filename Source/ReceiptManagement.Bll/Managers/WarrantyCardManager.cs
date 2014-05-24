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
    public class WarrantyCardManager
    {
        #region List

        public List<Entities.WarrantyCard> Get(ApiContext apiContext,int userId)
        {
            var list = new List<Entities.WarrantyCard>();

            try
            {
                var querySettings = QuerySettings<Entities.WarrantyCard>.Factory();

                //Include Entities             

                //Filter records
                querySettings.WhereExpression = rc => rc.UserId == userId;

                CoreManagers.WarrantycardManager.Get(apiContext, querySettings, out list);               

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
        public bool Insert(ApiContext apiContext, Common.Entities.WarrantyCard warrantyCard)
        {
            try
            {
                var result = CoreManagers.WarrantycardManager.Add(apiContext, new List<Common.Entities.WarrantyCard> { warrantyCard });

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
