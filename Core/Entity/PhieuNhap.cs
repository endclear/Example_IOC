using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class PhieuNhap
    {
        private int _id;
        private string _maphieunhap;
        private string _tenphieunhap;
        private string _mota;
        private int _congtyid;

        public virtual int Congtyid
        {
            get { return _congtyid; }
            set { _congtyid = value; }
        }
        
        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }


        public virtual string Maphieunhap
        {
            get { return _maphieunhap; }
            set { _maphieunhap = value; }
        }

        public virtual string Tenphieunhap
        {
            get { return _tenphieunhap; }
            set { _tenphieunhap = value; }
        }

        public virtual string Mota
        {
            get { return _mota; }
            set { _mota = value; }
        }
    }
}
