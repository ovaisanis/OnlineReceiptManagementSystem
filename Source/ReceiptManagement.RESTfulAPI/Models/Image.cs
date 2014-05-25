using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Entities = ReceiptManagement.Common.Entities;
using ReceiptManagement.Common.Helpers.Common;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class Image
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        public static implicit operator Entities.Image(Image model)
        {
            Entities.Image image = new Entities.Image();

            image.Id = model.Id;

            return image;
        }
    }
}