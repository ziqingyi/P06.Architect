using P02.ORMExplore.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.IDAL
{
    public interface IBaseDAL
    {
        T FindT<T>(int id) where T : BaseModel;

        List<T> FindAll<T>() where T : BaseModel;

        bool Add<T>(T t) where T : BaseModel;

        bool Update<T>(T t) where T : BaseModel;

        bool Delete<T>(T t) where T : BaseModel;

    }
}
