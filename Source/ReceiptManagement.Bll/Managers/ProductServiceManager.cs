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
    public class ProductServiceManager
    {
        #region List

        public List<Entities.Products_Services> Get(ApiContext apiContext,int userId)
        {
            var list = new List<Entities.Products_Services>();

            try
            {
                var querySettings = QuerySettings<Entities.Products_Services>.Factory();

                //Include Entities             

                //Filter records
                querySettings.WhereExpression = rc => rc.UserId == userId;

                CoreManagers.ProductsServicesManager.Get(apiContext, querySettings, out list);               

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
        public bool Insert(ApiContext apiContext, Common.Entities.Products_Services product)
        {
            try
            {
                var result = CoreManagers.ProductsServicesManager.Add(apiContext, new List<Common.Entities.Products_Services> { product });

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
