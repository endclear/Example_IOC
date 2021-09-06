using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class QuocGia
    {
        private int _id;
        private string _MaQuocGia;
        private string _TenQuocGia;

        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }
        

        public virtual string MaQuocGia
        {
            get { return _MaQuocGia; }
            set { _MaQuocGia = value; }
        }
        

        public virtual string TenQuocGia
        {
            get { return _TenQuocGia; }
            set { _TenQuocGia = value; }
        }


    }
}
