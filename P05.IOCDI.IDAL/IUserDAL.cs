using P05.IOCDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.IDAL
{
    public interface IUserDAL
    {
        UserModel Find(Expression<Func<UserModel, bool>> expression);

        void Update(UserModel userModel);
    }
}
