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
    public class ReceiptController : ApiController
    {
        // POST api/user
        public HttpResponseMessage Post(Models.ReceiptModel receiptModel)
        {
            try
            {
                Entities.Receipt receipt = receiptModel;

                new Managers.ReceiptManager().Insert(Context.GetContext(), receipt);

                return Request.CreateResponse(HttpStatusCode.OK, "Receipt Added Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }
    }
}
