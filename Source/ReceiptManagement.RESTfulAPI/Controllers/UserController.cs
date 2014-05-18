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
    public class UserController : ApiController
    {
        // GET api/user
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/user/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/user
        public HttpResponseMessage Post(Models.UserInfo userinfo)
        {
            try
            {
                // Mark user InActive at creation, It would be activated later by email notification
                userinfo.IsActive = false;
                Entities.User user = userinfo;
                new Managers.UserManager().Insert(Context.GetContext(), user);
                return Request.CreateResponse(HttpStatusCode.OK, "User Added Successfully");
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }
        }

        // PUT api/user/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/user/5
        public void Delete(int id)
        {
        }
    }
}
