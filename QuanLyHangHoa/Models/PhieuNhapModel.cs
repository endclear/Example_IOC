using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class PhieuNhapModel
    {
        
        public int id { get; set; }
        public string Maphieunhap { get; set; }
        [Required]
        public string Tenphieunhap { get; set; }
        public string Mota { get; set; }
        public string Tencongty { get; set; }
    }
}