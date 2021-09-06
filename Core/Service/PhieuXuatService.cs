using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class PhieuXuatService:BaseService<PhieuXuat,int>,IPhieuXuat
    {
        public PhieuXuatService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }
        public bool CreatePhieuXuat(PhieuXuat _phieuxuat) {
            try {
                Save(_phieuxuat);
                CommitChanges();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }
    }
}
