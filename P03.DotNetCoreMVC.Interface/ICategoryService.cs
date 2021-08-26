
using P03.DotNetCoreMVC.EntityFrameworkModels.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace P03.DotNetCoreMVC.Interface
{
    public interface ICategoryService:IBaseService
    {
        void Show();

        #region Query
        /// <summary>
        /// get all id in current category and descendant category
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<int> GetDescendantsIdList(string code);

        /// <summary>
        /// get child list, default is root
        /// </summary>
        /// <param name="code"></param>
        /// <returns></returns>
        IEnumerable<Category> GetChildList(string code = "root");


        /// <summary>
        /// catch all categories, no change in most cases.
        /// </summary>
        /// <returns></returns>
        List<Category> CacheAllCategory();

        #endregion



    }
}
