using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using P03.DotNetCoreMVC.Utility.Models;


namespace P03.DotNetCoreMVC.Interface
{
    public interface IBaseService: IDisposable// for releasing Context
    {
        #region Query
        /// <summary>
        /// find T based on id (this project's id is int)
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="id"></param>
        /// <returns></returns>
        T Find<T>(int id) where T : class;


        /// <summary>
        /// will return whole table
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns>IQueryable type</returns>
        [Obsolete("avoid using this,better to use query with Expression tree, using(...)")]
        IQueryable<T> Set<T>() where T : class;

        /// <summary>
        /// query with Expression tree
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="funcWhere"></param>
        /// <returns></returns>
        IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class;

        /// <summary>
        /// paging
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <typeparam name="S"></typeparam>
        /// <param name="funcWhere"></param>
        /// <param name="pageSize"></param>
        /// <param name="pageIndex"></param>
        /// <param name="funcOrderby"></param>
        /// <param name="isAsc"></param>
        /// <returns></returns>
        PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex, Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class;

        #endregion

        #region Add

        /// <summary>
        /// add one and commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns>T with primary key</returns>
        T Insert<T>(T t) where T : class;

        /// <summary>
        /// insert multi values and commit in one connection
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        /// <returns></returns>
        IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class;

        #endregion

        #region Update
        /// <summary>
        /// update one and commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Update<T>(T t) where T : class;

        /// <summary>
        /// update a list of objects and commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Update<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region Delete
        /// <summary>
        /// delete T by key id, and commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Id"></param>
        void Delete<T>(int Id) where T : class;

        /// <summary>
        /// delete T by object, commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        void Delete<T>(T t) where T : class;

        /// <summary>
        /// delete list of T, commit
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="tList"></param>
        void Delete<T>(IEnumerable<T> tList) where T : class;
        #endregion

        #region other
        /// <summary>
        /// save all changes immediately
        /// add and delete will put changes here for transaction
        /// </summary>
        void Commit();

        /// <summary>
        /// execute sql and return result set
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        /// <returns></returns>
        IQueryable<T> ExecuteQuery<T>(string sql, SqlParameter[] parameters) where T : class;

        /// <summary>
        /// execute sql without return
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="sql"></param>
        /// <param name="parameters"></param>
        void Execute<T>(string sql, SqlParameter[] parameters) where T : class;

        #endregion




    }
}
