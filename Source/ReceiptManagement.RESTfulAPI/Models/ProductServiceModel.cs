using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReceiptManagement.Common.Entities;
using ReceiptManagement.Common.Helpers.Common;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class ProductServiceModel
    {
        #region Primitive Properties

        public long Id
        {
            get;
            set;
        }

        public string Name
        {
            get;
            set;
        }

        public string Description
        {
            get;
            set;
        }

        public Nullable<int> CategoryId
        {
            get;
            set;
        }

        public Nullable<int> SubCategoryId
        {
            get; 
            set;
        }

        public Nullable<long> UserId
        {
            get;
            set;

        }

        public Nullable<System.DateTime> CreatedOn
        {
            get;
            set;
        }

        public Nullable<bool> IsDeleted
        {
            get;
            set;
        }

        #endregion

        public static implicit operator ProductServiceModel(Products_Services productService)
        {
            ProductServiceModel model = new ProductServiceModel();

            model.Id = productService.Id;
            model.IsDeleted = productService.IsDeleted;
            model.Name = productService.Name;
            model.Description = productService.Description;
            model.CreatedOn = productService.CreatedOn;
            model.UserId = productService.UserId;
            model.CategoryId = productService.CategoryId;
            model.SubCategoryId = productService.SubCategoryId;

            return model;
        }

        public static implicit operator Products_Services(ProductServiceModel model)
        {
            Products_Services prodService = new Products_Services();

            prodService.Id = model.Id;
            prodService.IsDeleted = model.IsDeleted;
            prodService.Name = model.Name;
            prodService.Description = model.Description;
            prodService.CreatedOn = model.CreatedOn;
            prodService.UserId = model.UserId;
            prodService.CategoryId = model.CategoryId;
            prodService.SubCategoryId = model.SubCategoryId;

            return prodService;
        }
    }
}