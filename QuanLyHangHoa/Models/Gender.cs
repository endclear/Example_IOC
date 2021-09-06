using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuanLyHangHoa.Models
{
    public class Gender
    {
        public string iValue { get; set; }
        public string sText { get; set; }
        public SelectList List_gender { get; set; }
    }
}