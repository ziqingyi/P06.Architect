using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.TestProject
{
    public class NavigationTest
    {
        public static void Show()
        {
            using (advanced7ContextNew context = new advanced7ContextNew())
            {
                {

                    var company = new Company()
                    {
                        Name = "c1",
                        CreateTime = DateTime.Now,
                        CreatorId = 1,
                       
                        LastModifyTime = DateTime.Now,
                        LastModifierId = 1,
                        User = new List<User>() {
                            new User() {
                                Name = "Rrrrr",
                                Mobile = "666666666666",
                                CreateTime = DateTime.Now,
                                Password="123456789"
                            },
                            new User() {
                                Name = "Eeeee",
                                Mobile = "6666666666",
                                CreateTime = DateTime.Now,
                                Password="123456789"
                            },
                            new User() {
                                Name = "App",
                                Mobile = "6666666666",
                                CreateTime = DateTime.Now,
                                Password="123456789"
                            }
                        }
                    };
                    context.Company.Add(company);
                    context.SaveChanges();
                }
                {

                    List<Company> companyList = context.Company.Include(c => c.User).ToList();
                    // Include 
                    //List<Company> companyList1 = context.Conmpany.Include(c => c.SysUser).ToList(); 
                    foreach (Company company in companyList)
                    {
                        var userList = company.User;
                        foreach (var user in userList)
                        {
                            var cmpy = user.Company;
                            //foreach (var item in cmpy.User) 
                            {

                            }
                        }
                    }
                }
                {
                    //context.SysLog.Add(new SysLog()
                    //{
                    //    LogType = new byte(),
                    //    UserName = "R",
                    //    SysLogDetail = new SysLogDetail()
                    //    {
                    //        CreateTime = DateTime.Now,
                    //        Introduction = "test",
                    //        CreatorId = 1,
                    //        LastModifierId = 1,
                    //        LastModifyTime = DateTime.Now
                    //    }
                    //});
                    //context.SaveChanges();
                    //SysLog sysLog = context.SysLog.FirstOrDefault();
                    //SysLogDetail sysLogDetail = context.SysLogDetail.FirstOrDefault();
                }

                {

                    ////Include
                    ////ThenInclude
                    //Company company = context.Conmpany.Include(c => c.SysUser).FirstOrDefault();
                    //foreach (SysUser user in company.SysUser)
                    //{
                    //    Company company1 = user.Company;
                    //    foreach (var item in company1.SysUser)
                    //    {

                    //    }
                    //}
                }
                
              
            }


        }



    }
}
