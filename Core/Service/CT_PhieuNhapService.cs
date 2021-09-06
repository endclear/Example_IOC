using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class CT_PhieuNhapService:BaseService<CT_PhieuNhap,int>,ICT_PhieuNhap
    {
        public CT_PhieuNhapService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }

        public bool CreateCT_PhieuNhap(CT_PhieuNhap ct_phieunhap)
        {
            try
            {
                Save(ct_phieunhap);
                CommitChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public bool UpdateCT_PhieuNhap(CT_PhieuNhap ct_phieunhap) {
            try {
                Update(ct_phieunhap);
                CommitChanges();
                return true;
            }
            catch(Exception Ex) {
                return false;
            }
        }
    }
}
