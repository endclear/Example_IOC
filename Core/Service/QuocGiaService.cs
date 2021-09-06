using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FX.Data;
using Core.Entity;
using Core.IService;

namespace Core.Service
{
    public class QuocGiaService : BaseService<QuocGia, int>, IQuocGia
    {
        public QuocGiaService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }
        public bool CreateQuocGia(QuocGia qg) {
            try
            {
                Save(qg);
                CommitChanges();
                return true;
            }
            catch(Exception ex) {
                return false;
            }
        }
    }
}
