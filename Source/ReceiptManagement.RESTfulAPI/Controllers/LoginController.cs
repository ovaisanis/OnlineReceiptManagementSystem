using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ReceiptManagement.RESTfulAPI.Controllers
{
    public class LoginController : ApiController
    {
        public void Post(string username)
        {

        }

        public string Get(string username, string password)
        {
            if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password))
                return Boolean.TrueString.ToLower();
            else
                return Boolean.FalseString.ToLower();
        }

        // GET api/values/5
        public string Get(string username)
        {
            return "this is your value="+username;
        }
    }
}
