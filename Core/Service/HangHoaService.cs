using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class HangHoaService : BaseService<HangHoa, int>, IHangHoa
    {
        public HangHoaService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }
        public bool CreateHangHoa(HangHoa _hh)
        {
            try
            {
                Save(_hh);
                CommitChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

    }
}
