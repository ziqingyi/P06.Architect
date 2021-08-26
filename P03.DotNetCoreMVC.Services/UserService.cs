using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.Interface;

namespace P03.DotNetCoreMVC
{
    public class UserService : BaseService,IUserService
    {
        public UserService(DbContext context) : base(context)
        {

        }

        public void UpdateLastLogin(User user)
        {
            User userDB = base.Find<User>(user.Id);
            userDB.LastLoginTime = DateTime.Now;
            this.Commit();
        }

    }
}
