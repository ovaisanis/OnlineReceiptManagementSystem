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
                //Entities.Products_Services prodService = prodServiceModel;

                //new Managers.ProductServiceManager().Insert(Context.GetContext(), prodService);

                return Request.CreateResponse(HttpStatusCode.OK, "Product Added Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // GET api/receipt/5
        public string Get(int id)
        {
            return "value";
        }
    }
}
