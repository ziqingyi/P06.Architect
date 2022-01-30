using Microsoft.Data.SqlClient;
using P03.DotNetCoreMVC.Utility.DbContextExtension;
using P03.DotNetCoreMVC.Utility.Interface;
using P03.DotNetCoreMVC.Utility.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace P03.DotNetCoreMVC.Interface.ServiceInterfaceUpgrade
{
    //use this interface to call upgrade service.. for simplicity, the old IBaseService can be deleted. 
    public interface IBaseServiceUpgrade:IDisposable
    {
        #region Query
        //can search from both read and write database
        public T Find<T>(int id, WriteAndReadEnum writeAndReadEnum = WriteAndReadEnum.Read) where T : class;


        public IQueryable<T> Set<T>() where T : class;

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex,
            Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class;
        #endregion

        #region Insert

        public T Insert<T>(T t) where T : class;
        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Update

        public void Update<T>(T t) where T : class;

        public void Update<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region Delete

        //attach first, then remove
        public void Delete<T>(T t) where T : class;

        public void Delete<T>(int Id) where T : class;

        public void Delete<T>(IEnumerable<T> tList) where T : class;

        #endregion


        #region other

        public void Commit();
        public IQueryable<T> ExecuteQuery<T>(string sql, SqlParameter[] parameters) where T : class;

        public void Execute<T>(string sql, SqlParameter[] parameters) where T : class;

        #endregion
    }
}
