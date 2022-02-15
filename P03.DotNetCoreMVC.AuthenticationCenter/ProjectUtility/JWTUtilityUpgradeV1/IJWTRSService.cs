using P03.DotNetCoreMVC.Utility.Models;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtilityUpgradeV1
{
    public interface IJWTRSService
    {
        string GetToken(CurrentUserCore currentUserInfo);
    }
}
