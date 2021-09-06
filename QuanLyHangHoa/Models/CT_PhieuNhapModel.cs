using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class CT_PhieuNhapModel
    {
        public int id { get; set; }
        public string Tenphieunhap { get; set; }
        public string TenMatHang { get; set; }
        public DateTime Ngaynhap { get; set; }
        public int Soluong { get; set; }
        [Required]
        public decimal Gianhap { get; set; }
        public decimal TongTienNhap { get; set; }
        public string Ghichu { get; set; }
    }
}