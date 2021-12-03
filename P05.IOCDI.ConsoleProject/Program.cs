
using P05.IOCDI.BLL;
using P05.IOCDI.DAL;
using P05.IOCDI.Framework;
using P05.IOCDI.Framework.CustomAOP;
using P05.IOCDI.Framework.CustomContainerFolder;
using P05.IOCDI.IBLL;
using P05.IOCDI.IDAL;
using P05.IOCDI.Service;
using P05.IOCDI.ServiceInterface;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

public class Program
{

    public static void Main(string[] args)
    {

        //high level rely(dependent) on lower level,
        //lower level update will lead to changes in higher level.

        #region factory 1 : tightly coupled with class 
        {
        //1 dependent on class name ---> use interface
        //2 code contains new object(), need to update everywhere when class name change. --> use factory create with new()

        //    UserDAL userDAL = new UserDAL();
        //    UserBLL userBLL = new UserBLL(userDAL);
        //    userBLL.Login("Administrator");
        }
        #endregion

        #region  factory 2: read config

        {
            //1 factory use Class Name  --> factory create obj by reflection, using config files.       
            IUserDAL userDAL = CustomFactory.Create<IUserDAL>();
            IUserBLL userBLL = CustomFactory.Create<IUserBLL>(userDAL);

            var user = userBLL.Login("Administrator");
        }
        #endregion

        #region  factory 3: IOC (register and resolve)

        {
            Console.WriteLine("***************3.1 create by factory******************************");
            //3.1 create by factory, but user need to know the params for each obj, relationship --> container find ctors and params        
            IContainer container = new CustomContainer();

            //Register for TestServiceB
            container.Register<ITestServiceA, TestServiceA>();//method injection need this
            container.Register<ITestServiceA, TestServiceA>(shortName:"a1");//use for TestServiceB ctor parameter
            container.Register<ITestServiceA, TestServiceA>(shortName: "a2");//use for TestServiceB ctor parameter
            object[] ServiceBparameterList = new object[] { "six",5 };
            //ITestServiceA serviceA = container.Resolve<ITestServiceA>(shortName: "a1");
            //ITestServiceA serviceA2 = container.Resolve<ITestServiceA>(shortName: "a2");


            //if has multi ctors, choose one by number of ctors or attribute label.
            //register and resolve TestServiceB
            container.Register<ITestServiceB, TestServiceB>(paraList: ServiceBparameterList);
            ITestServiceB serviceB = container.Resolve<ITestServiceB>();



        }
        {
            //3.2  parameters's initialization   ==>  Iteration       
            //   some properties need initializaiton  ==> parameter injection
            Console.WriteLine("***************3.2  parameters's initialization******************************");
            IContainer container = new CustomContainer();

            //Register for TestServiceB
            container.Register<ITestServiceA, TestServiceA>();//method injection need this
            container.Register<ITestServiceA, TestServiceA>(shortName: "a1");//use for TestServiceB ctor parameter
            container.Register<ITestServiceA, TestServiceA>(shortName: "a2");//use for TestServiceB ctor parameter
            object[] ServiceBparameterList = new object[] { "six", 5 };

            //iteration of creating instance and parameters
            container.Register<ITestServiceA, TestServiceA>();
            container.Register<ITestServiceB, TestServiceB>(paraList: ServiceBparameterList);
            container.Register<ITestServiceC, TestServiceC>();


            //resolve TestServiceC
            ITestServiceC testServiceC = container.Resolve<ITestServiceC>();

        }

        {     
            //3.3 add life time type to instance when initialize
            Console.WriteLine("***************3.3 add life time type: Singleton***********");
            CustomContainer container = new CustomContainer();

            //Register for TestServiceB
            container.Register<ITestServiceA, TestServiceA>();//method injection need this
            container.Register<ITestServiceA, TestServiceA>(shortName: "a1");//use for TestServiceB ctor parameter
            container.Register<ITestServiceA, TestServiceA>(shortName: "a2");//use for TestServiceB ctor parameter
            object[] ServiceBparameterList = new object[] { "six", 5 };


            container.Register<ITestServiceA, TestServiceA>(lifeTimeType: RegisterLifeTimeType.Singleton);
            container.Register<ITestServiceB, TestServiceB>(paraList: ServiceBparameterList, lifeTimeType: RegisterLifeTimeType.Singleton);
            container.Register<ITestServiceC, TestServiceC>();


            //resolve 2 instances and compare
            ITestServiceA testServiceA = container.Resolve<ITestServiceA>();
            ITestServiceA testServiceA2 = container.Resolve<ITestServiceA>();
            Console.WriteLine($"testServiceA.Equals(testServiceA2) ?  {testServiceA.Equals(testServiceA2)}");

            //everytime create A MUST search in dic and use existing instance if singleton
            ITestServiceB testServiceB = container.Resolve<ITestServiceB>();
            Console.WriteLine($"testServiceA.Equals(testServiceB._ITestServiceA) ?  {testServiceA.Equals(testServiceB._ITestServiceA)}");
            Console.WriteLine($"testService2A.Equals(testServiceB._ITestServiceA) ?  {testServiceA2.Equals(testServiceB._ITestServiceA)}");
        }
        {
            //3.4  Scope
            Console.WriteLine("***************3.4  life time type: Scope******************************");
            CustomContainer container1 = new CustomContainer();

            //Register for TestServiceB
            container1.Register<ITestServiceA, TestServiceA>();//method injection need this
            container1.Register<ITestServiceA, TestServiceA>(shortName: "a1");//use for TestServiceB ctor parameter
            container1.Register<ITestServiceA, TestServiceA>(shortName: "a2");//use for TestServiceB ctor parameter
            object[] ServiceBparameterList = new object[] { "six", 5 };


            container1.Register<ITestServiceA, TestServiceA>(lifeTimeType: RegisterLifeTimeType.Singleton);
            container1.Register<ITestServiceB, TestServiceB>(paraList: ServiceBparameterList, lifeTimeType: RegisterLifeTimeType.Scope);
            container1.Register<ITestServiceC, TestServiceC>();

            CustomContainer container2 = (CustomContainer)container1.CreateChildContainer();
            ITestServiceB testServiceB21 = container2.Resolve<ITestServiceB>();
            ITestServiceB testServiceB22 = container2.Resolve<ITestServiceB>();
            Console.WriteLine($"testServiceB21.Equals(testServiceB22._ITestServiceA) ?  {testServiceB21.Equals(testServiceB22)}");

            CustomContainer container3 = (CustomContainer)container1.CreateChildContainer();
            ITestServiceB testServiceB31 = container3.Resolve<ITestServiceB>();
            ITestServiceB testServiceB32 = container3.Resolve<ITestServiceB>();
            Console.WriteLine($"testServiceB31.Equals(testServiceB._ITestServiceA) ?  {testServiceB31.Equals(testServiceB32)}");

            Console.WriteLine($"testServiceB21.Equals(testServiceB31._ITestServiceA) ?  {testServiceB21.Equals(testServiceB31)}");

        }


        #endregion


        #region  AOP with Castle.Core
        {
            Console.Clear();
            Console.WriteLine("***************AOP with Castle.Core******************************");

            CustomAOPtest.Show();

        }
        #endregion



        #region  AOP with Custom Container
        {
            Console.Clear();
            Console.WriteLine("***************AOP with Castle.Core******************************");
            CustomContainer container = new CustomContainer();
            container.Register<ITestServiceA, TestServiceA>();

            ITestServiceA testServiceA = container.Resolve<ITestServiceA>();

            testServiceA.Show();
        }
        #endregion






        Console.ReadKey();

    }

}












