using System;
using System.Collections.Generic;
using System.Text;
using P03.DotNetCoreMVC.Interface.ServiceInterfaceUpgrade;
using P03.DotNetCoreMVC.Utility.DbContextExtension;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;
using P03.DotNetCoreMVC.Utility.Models;
using System.Linq;
using System.Linq.Expressions;

namespace P03.DotNetCoreMVC.Services.ServicesUpgrade
{
    public class BaseServiceUpgrade : IBaseServiceUpgrade
    {
        //use base service to do all the service for different objects(tables), use T
        protected ICustomDbContextFactory dbContextFactory = null;

        #region Identity
        //protected: only sub class can use. private: only base can set context value
        protected DbContext Context { get; private set; }
        /// <summary>
        /// share DbContext in one request, use one in a BaseService instance to curd.
        /// </summary>
        /// <param name="context"></param>
        public BaseServiceUpgrade(ICustomDbContextFactory dbContextFactory)//use super class: DbContext
        {
            this.dbContextFactory = dbContextFactory;
        }
        #endregion

        #region Query

        public T Find<T>(int id, WriteAndReadEnum writeAndReadEnum = WriteAndReadEnum.Read) where T : class
        {

            return this.Context.Set<T>().Find(id);
        }

        [Obsolete("avoid using this,better to use query with Expression tree, using(...)")]
        public IQueryable<T> Set<T>() where T : class
        {
            return this.Context.Set<T>();
        }

        public IQueryable<T> Query<T>(Expression<Func<T, bool>> funcWhere) where T : class
        {
            if (funcWhere == null)
            {
                return this.Context.Set<T>();
            }
            return this.Context.Set<T>().Where<T>(funcWhere);
        }

        public PageResult<T> QueryPage<T, S>(Expression<Func<T, bool>> funcWhere, int pageSize, int pageIndex,
            Expression<Func<T, S>> funcOrderby, bool isAsc = true) where T : class
        {
            var list = this.Set<T>();
            if (funcWhere != null)
            {
                list = list.Where<T>(funcWhere);
            }

            if (isAsc)
            {
                list = list.OrderBy(funcOrderby);
            }
            else
            {
                list = list.OrderByDescending(funcOrderby);
            }
            PageResult<T> result = new PageResult<T>()
            {
                DataList = list.Skip((pageIndex - 1) * pageSize).Take(pageSize).ToList(),
                PageIndex = pageIndex,
                PageSize = pageSize,
                TotalCount = list.Count()  // this.Context.Set<T>().Count(funcWhere)
            };
            return result;
        }
        #endregion

        #region Insert

        public T Insert<T>(T t) where T : class
        {
            this.Context.Set<T>().Add(t);
            //commit here, otherwise commit manually
            this.Commit();
            return t;
        }

        public IEnumerable<T> Insert<T>(IEnumerable<T> tList) where T : class
        {
            this.Context.Set<T>().AddRange(tList);
            //commit multiple sql
            this.Commit();
            return tList;
        }

        #endregion

        #region Update

        public void Update<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");

            //t is placed into the context in the unchanged state, like reading from db. 
            this.Context.Set<T>().Attach(t);
            //change state
            this.Context.Entry<T>(t).State = EntityState.Modified;
            this.Commit();
        }

        public void Update<T>(IEnumerable<T> tList) where T : class
        {
            foreach (T t in tList)
            {
                this.Context.Set<T>().Attach(t);
                this.Context.Entry<T>(t).State = EntityState.Modified;
            }
            this.Commit();//save and state changed to UnChanged
        }

        #endregion

        #region Delete

        //attach first, then remove
        public void Delete<T>(T t) where T : class
        {
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Attach(t);
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(int Id) where T : class
        {
            T t = this.Find<T>(Id);//can attach as well
            if (t == null) throw new Exception("t is null");
            this.Context.Set<T>().Remove(t);
            this.Commit();
        }

        public void Delete<T>(IEnumerable<T> tList) where T : class
        {
            foreach (T t in tList)
            {
                this.Context.Set<T>().Attach(t);
            }

            this.Context.Set<T>().RemoveRange(tList);
            this.Commit();
        }



        #endregion


        #region other

        public void Commit()
        {
            this.Context.SaveChanges();
        }

        public IQueryable<T> ExecuteQuery<T>(string sql, SqlParameter[] parameters) where T : class
        {
            ////Entity Framework Version
            //return this.Context.Database.SqlQuery<T>(sql, parameters).AsQueryable();


            //Entity Framework Core Version
            return this.Context.Set<T>().FromSqlRaw<T>(sql, parameters);


        }

        public void Execute<T>(string sql, SqlParameter[] parameters) where T : class
        {
            IDbContextTransaction trans = null;
            try
            {
                trans = this.Context.Database.BeginTransaction();
                this.Context.Database.ExecuteSqlRaw(sql, parameters);
                trans.Commit();
            }
            catch (Exception ex)
            {
                if (trans != null)
                {
                    trans.Rollback();
                }
                throw ex;
            }
        }

        //use virtual for sub class overriding. because other services may dispose other objects
        public virtual void Dispose()
        {
            if (this.Context != null)
            {
                this.Context.Dispose();
            }
        }
        #endregion

    }
}
