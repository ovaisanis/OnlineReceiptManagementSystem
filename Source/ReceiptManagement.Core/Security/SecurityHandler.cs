using System.Linq;
using Collections = System.Collections.Generic;
using Entities = ReceiptManagement.Common.Entities;
using Helpers = ReceiptManagement.Common.Helpers;
using System.Collections.Generic;

namespace ReceiptManagement.Core.Security
{
    /// <summary>
    /// SecurityHandler used to login, logout and authorize user into Core API
    /// </summary>
    public class SecurityHandler
    {
        #region Authorization

      
        public static void SetApiContext(Helpers.ApiContext apiContext)
        {
            if (!apiContext.IsContextInitialized)
                apiContext.CurrentContext = new Model.OrmsContext(apiContext.ConnectionString);
        }

        #endregion
    }
}
