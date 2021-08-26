using System;
using System.Collections.Generic;

using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using P03.DotNetCoreMVC.Interface;
using P03.DotNetCoreMVC.Utility.Extensions;


namespace P03.DotNetCoreMVC
{
    public class CategoryService: BaseService, ICategoryService
    {
        public CategoryService(DbContext context):base(context)
        {

        }

        public void Show()
        {
            Console.WriteLine("CategoryService Show()");
            throw new Exception("This is CategoryService Exception");

        }

        public override void Dispose()
        {
            Console.WriteLine("dispose other objects");
            base.Dispose();
        }


        #region Query

        public List<Category> CacheAllCategory()
        {
            List<Category> cachedList = CacheManagerCore.Get<List<Category>>("AllCateogry",
                () => base.Set<Category>().ToList());
            return cachedList;
        }

        public IEnumerable<int> GetDescendantsIdList(string code)
        {
            return this.CacheAllCategory().Where(c => c.Code.StartsWith(code)).Select(c => c.Id);
        }

        public IEnumerable<Category> GetChildList(string code = "root")
        {
            return this.CacheAllCategory().Where(c => c.ParentCode.StartsWith(code));
        }

        #endregion
 





    }
}
