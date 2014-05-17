using ReceiptManagement.Common.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class UserInfo
    {
        public string Username { get; set; }        

        public string Token { get; set; }

        public string RoleId { get; set; }

        public string Email { get; set; }

        public static implicit operator UserInfo(User user)
        {
            UserInfo userInFo = new UserInfo();
            userInFo.Username = user.FirstName + user.LastName;
            userInFo.Email  =  user.Email;
            userInFo.RoleId = Convert.ToString( user.RoleId);
            return userInFo;
        }
    }
}