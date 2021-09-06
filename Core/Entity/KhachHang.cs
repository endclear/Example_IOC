using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class KhachHang
    {
        private int _id;
        private string _hoten;
        private string _gioitinh;
        private DateTime _ngaysinh;
        private string _dienthoai;
        private string _email;
        private string _diachi;
        private int _congtyid;
        private int _socmt;
        private DateTime _Ngaycap;
        private string _noicap;

        public virtual string Noicap
        {
            get { return _noicap; }
            set { _noicap = value; }
        }


        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }
        [Required]
        public virtual string Hoten
        {
            get { return _hoten; }
            set { _hoten = value; }
        }

        public virtual string Gioitinh
        {
            get { return _gioitinh; }
            set { _gioitinh = value; }
        }

        public virtual DateTime Ngaysinh
        {
            get { return _ngaysinh; }
            set { _ngaysinh = value; }
        }

        public virtual string Dienthoai
        {
            get { return _dienthoai; }
            set { _dienthoai = value; }
        }

        public virtual string Email
        {
            get { return _email; }
            set { _email = value; }
        }

        public virtual string Diachi
        {
            get { return _diachi; }
            set { _diachi = value; }
        }


        public virtual int Congtyid
        {
            get { return _congtyid; }
            set { _congtyid = value; }
        }

        public virtual int Socmt
        {
            get { return _socmt; }
            set { _socmt = value; }
        }


        public virtual DateTime Ngaycap
        {
            get { return _Ngaycap; }
            set { _Ngaycap = value; }
        }
    }
}
