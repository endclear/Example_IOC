using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class CongTyService : BaseService<CongTy,int>,ICongTy
    {
        public CongTyService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }

        public bool CreateCongTy(CongTy c) {
            try {
                Save(c);
                CommitChanges();
                return true;
            }
            catch(Exception Ex) {
                return false;
            }
        }
        
    }
}
