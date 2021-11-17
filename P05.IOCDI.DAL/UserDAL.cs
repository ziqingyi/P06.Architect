using P05.IOCDI.IDAL;
using P05.IOCDI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace P05.IOCDI.DAL
{
    public class UserDAL:IUserDAL
    {
        public UserModel Find(Expression<Func<UserModel, bool>> expression)
        {
            Console.WriteLine($"This is {this.GetType().Name}");
            return new UserModel()
            {
                Id = 7,
                Name = "Test",
                Account = "Administrator",
                Email = "test@gmail.com",
                Password = "123456677",
                Role = "Admin",
                LoginTime = DateTime.Now
            };
        }

        public void Update(UserModel userModel)
        {
            Console.WriteLine($"This is {this.GetType().Name}");
            Console.WriteLine("database update");
        }

    }
}
