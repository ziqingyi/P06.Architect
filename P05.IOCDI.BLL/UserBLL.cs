﻿using P05.IOCDI.IBLL;
using P05.IOCDI.IDAL;
using P05.IOCDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.BLL
{
    public class UserBLL:IUserBLL
    {
        private IUserDAL _iUserDAL = null;

        public UserBLL(IUserDAL userDAL)
        {
            this._iUserDAL = userDAL;
            Console.WriteLine($"This is {this.GetType().Name}");
        }

        public void LastLogin(UserModel user)
        {
            Console.WriteLine($"This is {this.GetType().Name} LastLogin");
            user.LoginTime = DateTime.Now;
            this._iUserDAL!.Update(user);
        }

        public UserModel Login(string account)
        {
            Console.WriteLine($"This is {this.GetType().Name} Login");
            return this._iUserDAL!.Find(u => u.Account.Equals(account));
        }


    }
}
