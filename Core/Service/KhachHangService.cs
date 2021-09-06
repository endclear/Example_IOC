using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class KhachHangService:BaseService<KhachHang,int>,IKhachHang
    {
        public KhachHangService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }
        public bool CreateKhachHang(KhachHang _kh)
        {
            try
            {
                Save(_kh);
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
