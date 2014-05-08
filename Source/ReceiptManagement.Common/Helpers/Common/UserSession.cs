using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ReceiptManagement.Common.Helpers
{
    public class UserSession
    {
        public Guid UserId { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public Guid UserRoleId { get; set; }
        public Guid UserBusinessId { get; set; }
        public string UserBusinessName { get; set; }
    }
}
