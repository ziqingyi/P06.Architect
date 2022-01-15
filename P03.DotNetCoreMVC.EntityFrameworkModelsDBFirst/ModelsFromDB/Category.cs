using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB
{
    public partial class Category
    {
        public int Id { get; set; }
        public string Code { get; set; }
        public string ParentCode { get; set; }
        public int? CategoryLevel { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public int? State { get; set; }
    }
}
