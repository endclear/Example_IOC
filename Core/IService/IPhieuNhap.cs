using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface IPhieuNhap:FX.Data.IBaseService<PhieuNhap,int>
    {
        bool CreatePhieunhap(PhieuNhap _phieunhap);
        IList<PhieuNhap> getPhieuNhap(string tenphieunhap, int congtyid);
    }
}
