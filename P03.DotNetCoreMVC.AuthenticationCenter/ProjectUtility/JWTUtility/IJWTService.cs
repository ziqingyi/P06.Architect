using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace P03.DotNetCoreMVC.AuthenticationCenter.ProjectUtility.JWTUtility
{
    interface IJWTService
    {
        string GetToken(string userName);
    }
}
