using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Entity;

namespace Core.IService
{
    public interface IUser:FX.Data.IBaseService<User,int>
    {
        bool GetUser(string username, string password);
    }
}
