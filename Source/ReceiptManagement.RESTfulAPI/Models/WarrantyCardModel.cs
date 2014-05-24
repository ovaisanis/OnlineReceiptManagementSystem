using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using ReceiptManagement.Common.Entities;
using ReceiptManagement.Common.Helpers.Common;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class WarrantyCardModel
    {
        #region Primitive Properties

        public long Id
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

        public Nullable<System.DateTime> WarrantyExpireOn
        {
            get;
            set;
        }

        public Nullable<System.DateTime> CreatedOn
        {
            get;
            set;
        }

        public Nullable<long> UserId
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

        public static implicit operator WarrantyCardModel(WarrantyCard warrantyCard)
        {
            WarrantyCardModel model = new WarrantyCardModel();

            model.Id = warrantyCard.Id;
            model.IsDeleted = warrantyCard.IsDeleted;
            model.Title = warrantyCard.Title;
            model.Description = warrantyCard.Description;
            model.CreatedOn = warrantyCard.CreatedOn;
            model.UserId = warrantyCard.UserId;
            warrantyCard.WarrantyExpireOn = model.WarrantyExpireOn;

            return model;
        }

        public static implicit operator WarrantyCard(WarrantyCardModel model)
        {
            WarrantyCard warrantyCard = new WarrantyCard();

            warrantyCard.Id = model.Id;
            warrantyCard.IsDeleted = model.IsDeleted;
            warrantyCard.Title = model.Title;
            warrantyCard.Description = model.Description;
            warrantyCard.CreatedOn = model.CreatedOn;
            warrantyCard.UserId = model.UserId;
            warrantyCard.WarrantyExpireOn = model.WarrantyExpireOn;

            return warrantyCard;
        }
    }
}