using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface IQuocGia : FX.Data.IBaseService<QuocGia, int>
    {
        bool CreateQuocGia(QuocGia qg);
    }
}
