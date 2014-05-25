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
    public class ImageManager
    {
        #region List

        public List<Entities.Image> Get(ApiContext apiContext,int userId)
        {
            var list = new List<Entities.Image>();

            try
            {
                var querySettings = QuerySettings<Entities.Image>.Factory();

                //Include Entities             

                //Filter records
                querySettings.WhereExpression = rc => rc.UserId == userId;

                CoreManagers.ImageManager.Get(apiContext, querySettings, out list);               

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
        public bool Insert(ApiContext apiContext, Common.Entities.Image image,out long id)
        {
            try
            {

                var result = CoreManagers.ImageManager.Add(apiContext, image, out id);

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
