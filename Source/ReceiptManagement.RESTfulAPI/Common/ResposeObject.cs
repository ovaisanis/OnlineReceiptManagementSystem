using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceiptManagement.RESTfulAPI.Common
{
    public enum ResponseType
    {
        OK,
        ERROR
    }

    public class ResposeObject
    {
        #region Preperties
        
        public ResponseType response_type { get; set; }

        public object response_object { get; set; } 
        
        #endregion

        #region Contructors
        
        public ResposeObject(object responseObject)
        {
            this.response_type = ResponseType.OK;
            this.response_object = responseObject;
        }

        public ResposeObject(string error)
        {
            this.response_type = ResponseType.ERROR;
            this.response_object = error;
        }

        #endregion
    }

    
}