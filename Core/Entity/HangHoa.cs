using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class HangHoa
    {
        private int _id;
        private string _mahang;
        private string _tenhang;
        private string _mota;
        private int _xuatxuid;
        private int _ordernumber;

        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }


        public virtual string Mahang
        {
            get { return _mahang; }
            set { _mahang = value; }
        }


        public virtual string Tenhang
        {
            get { return _tenhang; }
            set { _tenhang = value; }
        }


        public virtual string Mota
        {
            get { return _mota; }
            set { _mota = value; }
        }


        public virtual int Xuatxuid
        {
            get { return _xuatxuid; }
            set { _xuatxuid = value; }
        }


        public virtual int Ordernumber
        {
            get { return _ordernumber; }
            set { _ordernumber = value; }
        }
    }
}
