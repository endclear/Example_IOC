using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class CongTyModel
    {
        public int id { get; set; }
        [Required]
        public string TenCongTy { get; set; }
        public string DienThoai { get; set; }
        public string Website { get; set; }
        public string Email { get; set; }
        public string MaSoThue { get; set; }
        public string DiaChi { get; set; }
        public int OrderNumber { get; set; }
    }
}