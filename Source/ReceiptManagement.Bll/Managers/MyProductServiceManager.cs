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
    public class MyProductServiceManager
    {
        #region Insert

        /// <summary>
        ///     Insert
        /// </summary>
        /// <param name = "apiContext"></param>
        /// <param name = "info"></param>
        /// <returns></returns>
        public bool Insert(ApiContext apiContext, Common.Entities.My_Products_Services product)
        {
            try
            {
                var result = CoreManagers.MyProductsServicesManager.Add(apiContext, new List<Common.Entities.My_Products_Services> { product });

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

        /// <summary>
        ///     Insert
        /// </summary>
        /// <param name = "apiContext"></param>
        /// <param name = "info"></param>
        /// <returns></returns>
        public bool Insert(ApiContext apiContext, Common.Entities.My_Products_Services product,out long id)
        {
            try
            {
                var result = CoreManagers.MyProductsServicesManager.Add(apiContext, product,out id);

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

        public bool Insert(ApiContext apiContext, 
                                                Entities.Products_Services productService, 
                                                Entities.Receipt receipt,
                                                Entities.WarrantyCard warrantyCard,
                                                List<Entities.Image> receiptImageList,
                                                List<Entities.Image> warranyCardImageList)
        {
            try
            {


                //Save Product Service
                long serviceId = 0;
                var result = CoreManagers.ProductsServicesManager.Add(apiContext, productService, out serviceId);
               
                //Save receipt
                long receiptId = 0;
                result = CoreManagers.ReceiptManager.Add(apiContext, receipt, out receiptId);

                //Save receipt images

                if (receiptImageList.Count > 0)
                {
                    List<Entities.ReceiptImage> receiptImages = new List<Entities.ReceiptImage>();
                    foreach (Entities.Image image in receiptImageList)
                    {
                        Entities.ReceiptImage receiptImage = new Entities.ReceiptImage();

                        receiptImage.ImageId = image.Id;
                        receiptImage.ReceiptId = receiptId;

                        receiptImages.Add(receiptImage);
                    }

                    result = CoreManagers.ReceiptimageManager.Add(apiContext, receiptImages);
                }

                //Save receipt
                long warrantyCardId = 0;
                result = CoreManagers.WarrantycardManager.Add(apiContext, warrantyCard, out warrantyCardId);

                //Save warranty card images
                if (warranyCardImageList.Count > 0)
                {
                    List<Entities.WarrantyCardImage> warranyCardImages = new List<Entities.WarrantyCardImage>();
                    foreach (Entities.Image image in warranyCardImageList)
                    {
                        Entities.WarrantyCardImage warrantyCardImage = new Entities.WarrantyCardImage();

                        warrantyCardImage.ImageId = image.Id;
                        warrantyCardImage.WarrantyCardId = warrantyCardId;

                        warranyCardImages.Add(warrantyCardImage);
                    }

                    result = CoreManagers.WarrantycardimageManager.Add(apiContext, warranyCardImages);
                }

                //Save My Product Service
                Entities.My_Products_Services myProdService = new Entities.My_Products_Services();

                myProdService.Product_Service_Id = serviceId;
                myProdService.ReceiptId = receiptId;
                myProdService.WarrantyCardId = warrantyCardId;
                myProdService.CreatedOn = DateTime.Now;

                result = CoreManagers.MyProductsServicesManager.Add(apiContext, new List<Entities.My_Products_Services> { myProdService });

                return result.WasSuccessful;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion

        #region List

        public List<Entities.My_Products_Services> Get(ApiContext apiContext)
        {
            var list = new List<Entities.My_Products_Services>();

            try
            {
                var querySettings = QuerySettings<Entities.My_Products_Services>.Factory();

                //Include Entities             
                querySettings.IncludedEntities.Add("Receipt");
                querySettings.IncludedEntities.Add("WarrantyCard");
                querySettings.IncludedEntities.Add("Products_Services");
                querySettings.IncludedEntities.Add("Products_Services.Product_Service_Categories");
                querySettings.IncludedEntities.Add("Products_Services.Product_Service_SubCategories");

                //Filter records
                //querySettings.WhereExpression = rc => rc.UserId == userId;

                CoreManagers.MyProductsServicesManager.Get(apiContext, querySettings, out list);

                return list;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        #endregion
    }
}
