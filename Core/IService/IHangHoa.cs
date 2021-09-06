using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface IHangHoa : FX.Data.IBaseService<HangHoa, int>
    {
        bool CreateHangHoa(HangHoa _hh);
    }
}
