using System;

namespace P03.DotNetCoreMVC.AuthenticationDemo.JWT_RS.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
