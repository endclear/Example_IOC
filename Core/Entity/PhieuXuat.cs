using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class PhieuXuat
    {
        private int _id;
        private string _maphieuxuat;
        private string _tenphieuxuat;
        private string _mota;
        private int _khachhangid;

        public virtual int Khachhangid
        {
            get { return _khachhangid; }
            set { _khachhangid = value; }
        }

        public virtual string Mota
        {
            get { return _mota; }
            set { _mota = value; }
        }

        public virtual string Tenphieuxuat
        {
            get { return _tenphieuxuat; }
            set { _tenphieuxuat = value; }
        }

        public virtual string Maphieuxuat
        {
            get { return _maphieuxuat; }
            set { _maphieuxuat = value; }
        }

        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
