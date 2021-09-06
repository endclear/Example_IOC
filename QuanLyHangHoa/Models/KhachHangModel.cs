using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class KhachHangModel
    {
        public int id { get; set; }
        
        public string Hoten { get; set; }
        public string Gioitinh { get; set; }
        public DateTime Ngaysinh { get; set; }
        public string Dienthoai { get; set; }
        public string Email { get; set; }
        public string Diachi { get; set; }
        public string Tencongty { get; set; }
        public int Socmt { get; set; }
        public DateTime Ngaycap { get; set; }
        public string Noicap { get; set; }
    }
}