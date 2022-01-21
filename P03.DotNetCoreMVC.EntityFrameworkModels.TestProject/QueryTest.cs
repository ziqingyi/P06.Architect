using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using P03.DotNetCoreMVC.EntityFrameworkModelsDBFirst.ModelsFromDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace P03.DotNetCoreMVC.EntityFrameworkModels.TestProject
{
    public class QueryTest
    {

        public static void Show()
        {
            using (advanced7Context dbContext = new advanced7Context())
            {
                {
                    var list = dbContext.SysUser.Where(u => 1 == 1 && !(new int[] { 1, 2, 3 }.Contains(u.Id)));
                    foreach (var user in list)
                    {
                        System.Console.WriteLine(user.Name);
                    }

                }

                {
                    var list = from u in dbContext.SysUser
                               where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                               select u;

                    foreach (var user in list)
                    {
                        System.Console.WriteLine(user.Name);
                    }
                }
                {
                    var list = dbContext.SysUser.Where(u => new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id))
                                              .OrderBy(u => u.Id) 
                                              .Select(u => new 
                                              {
                                                  Name = u.Name,
                                                  Pwd = u.Password
                                              }).Skip(3).Take(5); 
                    foreach (var user in list)
                    {
                        System.Console.WriteLine(user.Name);
                    }
                }
                {
                    var list = dbContext.SysUser.Where(u => u.Name.StartsWith("e") && u.Name.EndsWith("n"))
                      .Where(u => u.Name.EndsWith("n"))
                      .Where(u => u.Name.Contains("e"))
                      .Where(u => u.Name.Length < 10)
                      .OrderBy(u => u.Id);

                    foreach (var user in list)
                    {
                        System.Console.WriteLine(user.Name);
                    }
                }
                {
                    var list = from u in dbContext.SysUser
                               join c in dbContext.SysUserRoleMapping on u.Id equals c.SysUserId
                               where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                               select new
                               {
                                   Name = u.Name,
                                   Pwd = u.Password,
                                   RoleId = c.SysRoleId
                               };
                    foreach (var user in list)
                    {
                        System.Console.WriteLine("{0} {1}", user.Name, user.Pwd);
                    }
                }
                {
                    var list = from u in dbContext.SysUser
                               join m in dbContext.SysUserRoleMapping on u.Id equals m.SysUserId
                               join r in dbContext.SysRole on m.SysRoleId equals r.Id
                               where new int[] { 1, 2, 3, 5, 7, 8, 9, 10, 11, 12, 14, 17 }.Contains(u.Id)
                               select new
                               {
                                   Name = u.Name,
                                   Pwd = u.Password,
                                   RoleId = m.SysRoleId,
                                   RoleName = r.Text
                               };
                    foreach (var user in list)
                    {
                        System.Console.WriteLine("{0} {1} {2}", user.Name, user.Pwd, user.RoleName);
                    }
                }

            }


            using (advanced7Context dbContext = new advanced7Context())
            {
                {
                    try
                    {
                        string sql = "Update dbo.SysUser Set Password='asdfasfaezacdafd' WHERE Id=@Id";
                        SqlParameter parameter = new SqlParameter("@Id", 1);
                        int flag = dbContext.Database.ExecuteSqlRaw(sql, parameter);
                    }
                    catch (Exception ex)
                    {
                        throw ex;
                    }
                }
            }

            using (advanced7Context dbContext = new advanced7Context())
            {
                {
                    IDbContextTransaction trans = null;
                    try
                    {
                        trans = dbContext.Database.BeginTransaction();
                        string sql = "Update dbo.SysUser Set Password='asfdsafasfasfdas123123' WHERE Id=@Id";
                        SqlParameter parameter = new SqlParameter("@Id", 10);
                        dbContext.Database.ExecuteSqlRaw(sql, parameter);
                        trans.Commit();
                    }
                    catch (Exception ex)
                    {
                        if (trans != null)
                            trans.Rollback();
                        throw ex;
                    }
                    finally
                    {
                        trans.Dispose();
                    }
                }
            }


        }

    }
}
