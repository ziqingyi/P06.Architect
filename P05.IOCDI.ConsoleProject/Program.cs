
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

        //2 create by factory, but user need to know the params for each obj, relationship --> container find ctors and params
        {
            IContainer container = new CustomContainer();
            container.Register<ITestServiceA, TestServiceA>();
            ITestServiceA serviceA = container.Resolve<ITestServiceA>();

            //if has multi ctors, choose one by number of ctors or attribute label.
            container.Register<ITestServiceB, TestServiceB>();
            ITestServiceB serviceB = container.Resolve<ITestServiceB>();



        }
        //3  parameters's initialization   ==>  Iteration 
        //   some properties need initializaiton  ==> parameter injection
        {
            Console.WriteLine("***************3 Iteration******************************");
            IContainer container = new CustomContainer();
            //iteration of creating instance and parameters
            container.Register<ITestServiceA, TestServiceA>();
            container.Register<ITestServiceB, TestServiceB>();
            container.Register<ITestServiceC, TestServiceC>();
            ITestServiceC testServiceC = container.Resolve<ITestServiceC>();

        }

        {
            //4 add life time type to instance when initialize
            Console.WriteLine("***************4 life time type******************************");
            CustomContainer container = new CustomContainer();
            container.Register<ITestServiceA, TestServiceA>(RegisterLifeTimeType.Singleton);
            container.Register<ITestServiceB, TestServiceB>(RegisterLifeTimeType.Singleton);
            container.Register<ITestServiceC, TestServiceC>();
            //resolve 2 instances and compare
            ITestServiceA testServiceA = container.Resolve<ITestServiceA>();
            ITestServiceA testServiceA2 = container.Resolve<ITestServiceA>();
            Console.WriteLine($"testServiceA.Equals(testServiceA2) ?  {testServiceA.Equals(testServiceA2)}");

        }



        #endregion













        Console.ReadKey();

    }

}












