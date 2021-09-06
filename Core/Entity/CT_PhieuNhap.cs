using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class CT_PhieuNhap
    {
        private int _id;
        private int _phieunhapId;
        private int _hanghoaId;
        private DateTime _ngaynhap;
        private int _soluong;
        private decimal _gianhap;
        private string _ghichu;

        public virtual string Ghichu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }


        public virtual decimal Gianhap
        {
            get { return _gianhap; }
            set { _gianhap = value; }
        }

        public virtual int Soluong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }

        public virtual DateTime Ngaynhap
        {
            get { return _ngaynhap; }
            set { _ngaynhap = value; }
        }
        public virtual int HanghoaId
        {
            get { return _hanghoaId; }
            set { _hanghoaId = value; }
        }


        public virtual int PhieunhapId
        {
            get { return _phieunhapId; }
            set { _phieunhapId = value; }
        }

        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }
        
    }
}
