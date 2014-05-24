using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ReceiptManagement.RESTfulAPI.Filters
{
    public class ValidateRequestFilter : ActionFilterAttribute
    {
        public const string API_TOKEN_KEY = "API-TOKEN";

        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            if (actionContext.Request.Headers.Contains(API_TOKEN_KEY))
            {
                var values = actionContext.Request.Headers.GetValues(API_TOKEN_KEY);
            }
            else
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
           

            //if (!actionContext.Request.Content.IsMimeMultipartContent())
            //{
            //    throw new HttpResponseException(HttpStatusCode.BadRequest);
            //}
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {

        }
 
    }
}