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
        public long Id
        {
            get;
            set;
        }
    
        public Nullable<System.DateTime> ReceiptDate
        {
            get;
            set;
        }
    
        public string SerialNumber
        {
            get;
            set;
        }
    
        public string Title
        {
            get;
            set;
        }
    
        public string Description
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

        public  Nullable<bool> IsDeleted
        {
            get;
            set;
        }

        public static implicit operator ReceiptModel(Receipt receipt)
        {
            ReceiptModel model = new ReceiptModel();

            model.Id = receipt.Id;
            model.ReceiptDate = receipt.ReceiptDate;
            model.IsDeleted = receipt.IsDeleted;
            model.SerialNumber = receipt.SerialNumber;
            model.Title = receipt.Title;
            model.Description = receipt.Description;
            model.CreatedOn = receipt.CreatedOn;
            model.UserId = receipt.UserId;
          
            return model;
        }

        public static implicit operator Receipt(ReceiptModel model)
        {
            Receipt receipt = new Receipt();

            receipt.Id = model.Id;
            receipt.ReceiptDate = model.ReceiptDate;
            receipt.IsDeleted = model.IsDeleted;
            receipt.SerialNumber = model.SerialNumber;
            receipt.Title = model.Title;
            receipt.Description = model.Description;
            receipt.CreatedOn = model.CreatedOn;
            receipt.UserId = model.UserId;
          
            return receipt;
        }
    
    }
}