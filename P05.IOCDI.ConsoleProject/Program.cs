
using P05.IOCDI.Framework;
using P05.IOCDI.IDAL;
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

        #region tightly coupled with class 
        //{
        //1 dependent on class name ---> use interface
        //2 code contains new object(), need to update everywhere when class name change. --> use factory create with new()

        //    UserDAL userDAL = new UserDAL();
        //    UserBLL userBLL = new UserBLL(userDAL);
        //    userBLL.Login("Administrator");
        //}
        #endregion

        #region  factory

        //1 factory use Class Name  --> factory create obj by reflection, using config files. 

        IUserDAL userDAL = CustomFactory.Create<IUserDAL>();



        #endregion


















    }

}












