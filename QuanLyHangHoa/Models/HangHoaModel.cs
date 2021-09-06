using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace QuanLyHangHoa.Models
{
    public class HangHoaModel
    {
        public int id{get;set;}
        public string Mahang{get;set;}
        public string Tenhang{get;set;}
        public string Mota{get;set;}
        public string Tenquocgia{get;set;}
        public int Ordernumber { get; set; }
    }
}