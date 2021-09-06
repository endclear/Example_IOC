using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class CT_PhieuXuatModel
    {
        public int id { get; set; }
        public string Tenphieunhap { get; set; }
        public string Tenmathang { get; set; }
        public DateTime Ngayxuat { get; set; }
        public int Soluong { get; set; }
        public decimal Giaban{ get; set; }
        public decimal TongTienBan { get; set; }
        public string Ghichu { get; set; }
    }
}