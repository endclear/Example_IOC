using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class CongTy
    {
        private int _id;
        private string _TenCongTy;
        private string _DienThoai;
        private string _Website;
        private string _Email;
        private string _MaSoThue;
        private string _DiaChi;
        private int _OrderNumber;

        public virtual int OrderNumber
        {
            get { return _OrderNumber; }
            set { _OrderNumber = value; }
        }

        public virtual int id {
            get { return _id; }
            set { _id = value; }
        }
        
        public virtual string TenCongTy
        {
            get { return _TenCongTy; }
            set { _TenCongTy = value; }
        }

        public virtual string DienThoai
        {
            get { return _DienThoai; }
            set { _DienThoai = value; }
        }

        public virtual string Website
        {
            get { return _Website; }
            set { _Website = value; }
        }

        public virtual string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }

        public virtual string MaSoThue
        {
            get { return _MaSoThue; }
            set { _MaSoThue = value; }
        }

        public virtual string DiaChi
        {
            get { return _DiaChi; }
            set { _DiaChi = value; }
        }
    }
}
