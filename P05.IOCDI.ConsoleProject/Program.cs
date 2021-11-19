
using P05.IOCDI.BLL;
using P05.IOCDI.DAL;
using P05.IOCDI.Framework;
using P05.IOCDI.Framework.CustomContainerFolder;
using P05.IOCDI.IBLL;
using P05.IOCDI.IDAL;
using P05.IOCDI.Service;
using P05.IOCDI.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Projgram
{

    public static void Main(string[] args)
    {

        //high level rely(dependent) on lower level,
        //lower level update will lead to changes in higher level.

        #region factory 1 : tightly coupled with class 
        //{
        //1 dependent on class name ---> use interface
        //2 code contains new object(), need to update everywhere when class name change. --> use factory create with new()

        //    UserDAL userDAL = new UserDAL();
        //    UserBLL userBLL = new UserBLL(userDAL);
        //    userBLL.Login("Administrator");
        //}
        #endregion

        #region  factory 2: read config

        //1 factory use Class Name  --> factory create obj by reflection, using config files. 
        {
            IUserDAL userDAL = CustomFactory.Create<IUserDAL>();
            IUserBLL userBLL = CustomFactory.Create<IUserBLL>(userDAL);

            var user = userBLL.Login("Administrator");
        }
        #endregion

        #region  factory 3: IOC (register and resolve)

        //1 create by factory, but user need to know the params for each obj, relationship --> 
        {
            IContainer container = new CustomContainer();
            container.Register<ITestServiceA, TestServiceA>();
            ITestServiceA service = container.Resolve<ITestServiceA>();


        }

        #endregion













        Console.ReadKey();

    }

}












