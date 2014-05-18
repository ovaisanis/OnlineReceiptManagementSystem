using ReceiptManagement.Common.Entities;
using ReceiptManagement.Common.Helpers.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ReceiptManagement.RESTfulAPI.Models
{
    public class UserInfo
    {
        public long Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string UserFullName 
        { 
            get
            {
                return (this.FirstName + " " + this.LastName);
            }
        }

        public string Password { get; set; }

        public string Token { get; set; }

        public string RoleId { get; set; }

        public string Email { get; set; }

        public bool IsActive { get; set; }

        public static implicit operator UserInfo(User user)
        {
            UserInfo userInfo = new UserInfo();
            userInfo.Id = user.Id;
            userInfo.FirstName = user.FirstName;
            userInfo.FirstName = user.LastName;
            userInfo.Email  =  user.Email;
            userInfo.RoleId = Convert.ToString(user.RoleId);
            return userInfo;
        }

        public static implicit operator User(UserInfo userInfo)
        {
            User user = new User();
            user.FirstName = userInfo.FirstName.Trim();
            user.LastName = userInfo.LastName.Trim();
            user.Password = userInfo.Password.Trim();
            user.Email = userInfo.Password.Trim();
            user.RoleId = Roles.User;
            user.IsActive = userInfo.IsActive;
            return user;
        }
    }
}