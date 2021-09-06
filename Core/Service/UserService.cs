using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;
using Core.IService;
using FX.Data;

namespace Core.Service
{
    public class UserService:BaseService<User,int>,IUser
    {
        public UserService(string sessionFactoryConfigPath)
            : base(sessionFactoryConfigPath)
        {
        }

        public bool GetUser(string username, string password) {
            try {
                IQueryable<User> qr = from u in Query where (u.Username == username && u.Password == password) select u;
                if (qr.Count() < 1)
                {
                    return false;
                }
                else { 
                    return true;
                }
            }
            catch (Exception ex) {
                return false;
            }
        }
    }
}
