using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using ReceiptManagement.RESTfulAPI.Common;
using Models = ReceiptManagement.RESTfulAPI.Models;
using Managers = ReceiptManagement.Bll.Managers;
using ReceiptManagement.RESTfulAPI.Models;

namespace ReceiptManagement.RESTfulAPI.Controllers
{
    public class LoginController : ApiController
    {
        public HttpResponseMessage Post(Models.Login loginData)
        {
            try
            {

                // Write login authentication code here
                UserInfo userInfo;
                if (AuthenticateUser(loginData, out userInfo))
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new ResposeObject(userInfo));
                }
                else
                {
                    return Request.CreateResponse(HttpStatusCode.OK, new ResposeObject("User not found"));
                }
            }
            catch (Exception ex)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError, ex.Message);
            }

            
        }

        public string Get()
        {
            return "Can you hear me Major Tom?";
        }

        private bool AuthenticateUser(Models.Login loginData,out UserInfo userInfo)
        {
            userInfo = new UserInfo();
            
            Managers.UserManager userManager = new Managers.UserManager();
            
            var objUser= userManager.IsExists(Context.GetContext(), loginData.Username,loginData.Password);
           if (objUser != null)
           {
               userInfo = objUser;
               userInfo.Token = Context.GeneratePublicApiKey();
               Context.AddUser(userInfo);
               return true;
           }           

            return false;
        }
    }
}
