using Microsoft.AspNetCore.Mvc;

namespace P06.DotNetCoreMVC.WebApiDemo.Models
{
    public class ProductRequest
    {
        [FromQuery(Name = "limit")]
        public int Limit { get; set; } = 50;

        [FromQuery(Name = "offset")]
        public int Offset { get; set; }
    }
}
