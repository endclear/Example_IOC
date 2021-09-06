using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class PhieuNhapService : BaseService<PhieuNhap, int>,IPhieuNhap
    {
        public PhieuNhapService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }
        public bool CreatePhieunhap(PhieuNhap c)
        {
            try
            {
                Save(c);
                CommitChanges();
                return true;
            }
            catch (Exception Ex)
            {
                return false;
            }
        }

        public IList<PhieuNhap> getPhieuNhap(string tenphieunhap,int congtyid)
        {
            IQueryable<PhieuNhap> phieunhap = from c in Query where c.Tenphieunhap.Contains(tenphieunhap) && c.Congtyid == congtyid select c;
            return phieunhap.ToList();
        }
    }
}
