using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface ICongTy:FX.Data.IBaseService<CongTy,int>
    {
        bool CreateCongTy(CongTy c);
    }
}
