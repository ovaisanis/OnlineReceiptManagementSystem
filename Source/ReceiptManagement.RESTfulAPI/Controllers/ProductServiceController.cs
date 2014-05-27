using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models = ReceiptManagement.RESTfulAPI.Models;
using Entities = ReceiptManagement.Common.Entities;
using Managers = ReceiptManagement.Bll.Managers;
using ReceiptManagement.RESTfulAPI.Common;

namespace ReceiptManagement.RESTfulAPI.Controllers
{
    public class ProductServiceController : ApiController
    {
        // POST api/receipt
        public HttpResponseMessage Post(Models.ProductServiceModel prodServiceModel)
        {
            try
            {
                SaveReceipts(prodServiceModel);

                return Request.CreateResponse(HttpStatusCode.OK, "Product or Service Added Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/receipt
        public HttpResponseMessage Get()
        {
            try
            {
                var lst = new Managers.MyProductServiceManager().Get(Context.GetContext());

                List<Models.ReceiptModel> receiptList = new List<Models.ReceiptModel>();

                foreach (var service in lst)
                {
                    var model = new Models.ReceiptModel();
                    model = service;

                    receiptList.Add(model);
                }

                return Request.CreateResponse(HttpStatusCode.OK, new ResposeObject(receiptList));
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        #region Private Functions

        private void SaveReceipts(Models.ProductServiceModel prodServiceModel)
        {
            Entities.Products_Services prodService = new Entities.Products_Services();

            //TODO: Hack: Fix it later. Allow null value in Name field
            prodService.Name = string.IsNullOrEmpty(prodServiceModel.ServiceName) ? string.Empty : prodServiceModel.ServiceName;

            prodService.Description = prodServiceModel.ServiceDescription;
            prodService.PurchaseDate = prodServiceModel.ServicePurchaseDate;
            prodService.Tags = prodServiceModel.ServiceTags;
            prodService.CreatedOn = DateTime.Now;
            prodService.CategoryId =1; //prodServiceModel.ServiceCategoryId;
            prodService.SubCategoryId = 1; //prodServiceModel.ServiceSubCategoryId;

            Entities.Receipt receipt = new Entities.Receipt();

            receipt.Title = prodServiceModel.ReceiptTitle;
            receipt.SerialNumber = prodServiceModel.ReceiptSerialNumber;
            receipt.Description = prodServiceModel.ReceiptDescription;
            receipt.ReceiptDate = prodServiceModel.ReceiptDate;

            List<Entities.Image> receiptImageList = new List<Entities.Image>();
            if (prodServiceModel.ReceiptUploadedFiles != null)
            {              
                foreach (Models.Image imageModel in prodServiceModel.ReceiptUploadedFiles)
                {
                    Entities.Image image = imageModel;
                    receiptImageList.Add(image);
                }
            }

            Entities.WarrantyCard warrantyCard = new Entities.WarrantyCard();

            warrantyCard.Description = prodServiceModel.ReceiptDescription;
            warrantyCard.Title = prodServiceModel.WarrantyTitle;
            warrantyCard.WarrantyExpireOn = prodServiceModel.WarrantyExpireOn;
            warrantyCard.CardNumber = prodServiceModel.WarrantyCardNumber;

            List<Entities.Image> warranyCardImageList = new List<Entities.Image>();
            if (prodServiceModel.WarrantyCardUploadedFiles != null)
            {
                foreach (Models.Image imageModel in prodServiceModel.WarrantyCardUploadedFiles)
                {
                    Entities.Image image = imageModel;
                    warranyCardImageList.Add(image);
                }
            }

            Managers.MyProductServiceManager manager = new Managers.MyProductServiceManager();
            manager.Insert(Context.GetContext(), prodService, receipt, warrantyCard, receiptImageList, warranyCardImageList);
        }

        #endregion
    }
}
