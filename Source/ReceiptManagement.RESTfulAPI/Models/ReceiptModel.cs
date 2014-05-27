using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReceiptManagement.Common.Entities;
using ReceiptManagement.Common.Helpers.Common;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class ReceiptModel
    {        
        public DateTime DateCreated {get;set;}

        public DateTime? DatePurchased  {get;set;}

        public string Category {get;set;}

        public string SubCategory  {get;set;}

        public string Product_Service_Name {get;set;}

        public string ReceiptAvailable {get;set;}

        public string WarrantyCardAvailable {get;set;}

        public static implicit operator ReceiptModel(My_Products_Services service)
        {
            ReceiptModel model = new ReceiptModel();

            model.DateCreated = service.CreatedOn.Date;

            if (service.Products_Services != null)
            {
                model.DatePurchased = service.Products_Services.PurchaseDate;
                model.Product_Service_Name = service.Products_Services.Name;

                if (service.Products_Services.Product_Service_Categories != null)
                {
                    model.Category = service.Products_Services.Product_Service_Categories.CategoryTitle;
                }

                if (service.Products_Services.Product_Service_SubCategories != null)
                {
                    model.SubCategory = service.Products_Services.Product_Service_SubCategories.SubCategoryTitle;
                }
            }

            model.ReceiptAvailable = service.Receipt != null ? "Yes" : "No";

            model.WarrantyCardAvailable = service.WarrantyCard != null ? "Yes" : "No";

            return model;
        }
           
    }
}