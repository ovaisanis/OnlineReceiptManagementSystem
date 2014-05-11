using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using Models = ReceiptManagement.RESTfulAPI.Models;

namespace ReceiptManagement.RESTfulAPI.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Post(Models.Login loginData)
        {
            try
            {
                // Write login authentication code here
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            return Request.CreateResponse(HttpStatusCode.OK, new { Name = "Wahaj", Age="27" });
        }


    }
}
