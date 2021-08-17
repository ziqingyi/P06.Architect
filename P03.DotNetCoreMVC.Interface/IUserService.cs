



using P03.DotNetCoreMVC.EntityFrameworkModels.Models;

namespace P03.DotNetCoreMVC.Interface
{
    public interface IUserService :IBaseService
    {
        //add some extra methods required for User Service
        void UpdateLastLogin(User user);
    }
}
