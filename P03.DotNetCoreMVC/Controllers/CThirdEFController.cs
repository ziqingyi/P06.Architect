﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using P03.DotNetCoreMVC.Interface.ServiceInterfaceUpgrade;
using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst2.ModelsFromDB;

namespace P03.DotNetCoreMVC.Controllers
{
    public class CThirdEFController : Controller
    {
        private ICompanyServiceUpgrade _companyServiceUpdate= null;

        public CThirdEFController(ILogger<CThirdEFController> logger, ICompanyServiceUpgrade companyServiceUpdate)
        {
            _companyServiceUpdate= companyServiceUpdate;
        }



        public IActionResult Index()
        {
            Conmpany c1 = _companyServiceUpdate.Find<Conmpany>(1);

            var c3 = _companyServiceUpdate.FindAsync<Conmpany>(1);

            Conmpany c2 = _companyServiceUpdate.Find<Conmpany>(3, Utility.DbContextExtension.WriteAndReadEnum.Write);



            return View();
        }
    }
}
