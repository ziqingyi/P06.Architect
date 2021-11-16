using P05.IOCDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.IBLL
{
    public interface IUserBLL
    {
        UserModel Login(string account);

        void LastLogin(UserModel user);
    }
}
