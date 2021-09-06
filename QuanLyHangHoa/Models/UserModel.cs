using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class UserModel
    {
        public int id { get; set; }
        public string Username { get; set; }
        public string Password { get; set; }
        public bool Rememberme { get; set; }
    }
}