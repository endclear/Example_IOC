using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface ICT_PhieuNhap:FX.Data.IBaseService<CT_PhieuNhap,int>
    {
        bool CreateCT_PhieuNhap(CT_PhieuNhap ct_phieunhap);
        bool UpdateCT_PhieuNhap(CT_PhieuNhap ct_phieunhap);
    }
}
