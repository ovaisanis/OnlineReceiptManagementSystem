using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class Image
    {
        public long Id { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }
    }
}