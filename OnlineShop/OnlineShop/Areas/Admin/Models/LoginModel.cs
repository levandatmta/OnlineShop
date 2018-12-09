using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OnlineShop.Areas.Admin.Models
{
    public class LoginModel
    {
        //[Required(ErrorMessage = "Mời nhập tên đăng nhập")]
        public string Username { get; set; }
        //[Required(ErrorMessage = "Mời nhập PassWord")]
        public string Password { get; set; }
        public string Name { get; set; }
    }
}