using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface IPhieuXuat:FX.Data.IBaseService<PhieuXuat,int>
    {
        bool CreatePhieuXuat(PhieuXuat _phieuxuat);
    }
}
