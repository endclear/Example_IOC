using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class CT_PhieuXuat
    {
        private int _id;
        private int _phieuxuatId;
        private int _hanghoaId;
        private DateTime _ngayxuat;
        private int _soluong;
        private decimal _giaban;
        private string _ghichu;


        public virtual int PhieuxuatId
        {
            get { return _phieuxuatId; }
            set { _phieuxuatId = value; }
        }

        public virtual string Ghichu
        {
            get { return _ghichu; }
            set { _ghichu = value; }
        }

        public virtual decimal Giaban
        {
            get { return _giaban; }
            set { _giaban = value; }
        }

        public virtual int Soluong
        {
            get { return _soluong; }
            set { _soluong = value; }
        }

        public virtual DateTime Ngayxuat
        {
            get { return _ngayxuat; }
            set { _ngayxuat = value; }
        }


        public virtual int HanghoaId
        {
            get { return _hanghoaId; }
            set { _hanghoaId = value; }
        }

        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
