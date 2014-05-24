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
    public class WarrantyCardController : ApiController
    {
        // POST api/receipt
        public HttpResponseMessage Post(Models.WarrantyCardModel warrantyCardModel)
        {
            try
            {
                Entities.WarrantyCard warrantyCard = warrantyCardModel;

                new Managers.WarrantyCardManager().Insert(Context.GetContext(), warrantyCard);

                return Request.CreateResponse(HttpStatusCode.OK, "Receipt Added Successfully");
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
