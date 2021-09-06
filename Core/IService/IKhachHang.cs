using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface IKhachHang:FX.Data.IBaseService<KhachHang,int>
    {
        bool CreateKhachHang(KhachHang _kh);
        //bool UpdateKhachHang(KhachHang _kh);
    }
}
