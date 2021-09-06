using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class CT_PhieuXuatService:BaseService<CT_PhieuXuat,int>,ICT_PhieuXuat
    {
        public CT_PhieuXuatService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }

        public bool CreateCT_PhieuXuat(CT_PhieuXuat ct_phieuxuat)
        {
            try
            {
                Save(ct_phieuxuat);
                CommitChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public bool UpdateCT_PhieuXuat(CT_PhieuXuat ct_phieuxuat) {
            try {
                Update(ct_phieuxuat);
                CommitChanges();
                return true;
            }
            catch(Exception Ex) {
                return false;
            }
        }
    }
}
