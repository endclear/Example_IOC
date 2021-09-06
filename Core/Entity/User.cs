using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Entity
{
    public class User
    {
        private int _id;
        private string _username;
        private string _password;

        public virtual string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public virtual string Username
        {
            get { return _username; }
            set { _username = value; }
        }

        public virtual int id
        {
            get { return _id; }
            set { _id = value; }
        }
    }
}
