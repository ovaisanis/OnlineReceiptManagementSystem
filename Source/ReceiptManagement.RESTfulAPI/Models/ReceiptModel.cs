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

        public string Sub_Category  {get;set;}

        public string Product_Service_Name {get;set;}

        bool Receipt_Available {get;set;}

        bool Warranty_Card_Available {get;set;}

        public static implicit operator ReceiptModel(My_Products_Services service)
        {
            ReceiptModel model = new ReceiptModel();

            model.DateCreated = service.CreatedOn;

            if(service.Products_Services != null)
            {
                model.DatePurchased = service.Products_Services.PurchaseDate;
                model.Product_Service_Name = service.Products_Services.Name;

                if (service.Products_Services.Product_Service_Categories != null)
                {
                    model.Category = service.Products_Services.Product_Service_Categories.CategoryTitle;
                }

                if (service.Products_Services.Product_Service_SubCategories != null)
                {
                    model.Category = service.Products_Services.Product_Service_SubCategories.SubCategoryTitle;
                }
            }

            model.Receipt_Available = service.Receipt != null ? true : false;

            model.Warranty_Card_Available = service.WarrantyCard != null ? true : false;

            return model;
        }
           
    }
}