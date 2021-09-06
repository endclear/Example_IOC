using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface ICT_PhieuXuat:FX.Data.IBaseService<CT_PhieuXuat,int>
    {
        bool CreateCT_PhieuXuat(CT_PhieuXuat ct_phieuxuat);
        bool UpdateCT_PhieuXuat(CT_PhieuXuat ct_phieuxuat);
    }
}
