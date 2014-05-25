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
        public string ServiceName { get; set; }

        public string ServiceDescription{ get; set; }

        public int ServiceCategoryId { get; set; }

        public int ServiceSubCategoryId { get; set; }

        public Nullable<DateTime> ServicePurchaseDate { get; set; }

        public int UserId{ get; set; }

        public string ServiceTags{ get; set; }

        public Nullable<DateTime> ReceiptDate{ get; set; }

        public string  ReceiptSerialNumber{ get; set; }

        public string  ReceiptTitle{ get; set; }

        public string ReceiptDescription{ get; set; }

        public List<Image> ReceiptUploadedFiles { get; set; }

        public string WarrantyTitle{ get; set; }

        public string WarrantyDescription{ get; set; }

        public string WarrantyCardNumber { get; set; }

        public Nullable<DateTime> WarrantyExpireOn { get; set; }

        public List<Image> WarrantyCardUploadedFiles { get; set; }
    }
}