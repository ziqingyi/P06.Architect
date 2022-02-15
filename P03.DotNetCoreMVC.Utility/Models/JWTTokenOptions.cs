using System;
using System.Collections.Generic;
using System.Text;

namespace P03.DotNetCoreMVC.Utility.Models
{
    public class JWTTokenOptions
    {
        public string Audience
        {
            get;
            set;
        }

        public string SecurityKey
        {
            get;
            set;
        }

        //public SigningCredentials Credentials
        //{
        //    get;
        //    set;
        //}

        public string Issuer
        {
            get;
            set;
        }



    }

}
