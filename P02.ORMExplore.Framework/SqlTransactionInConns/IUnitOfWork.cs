using System;
using System.Collections.Generic;
using System.Text;

namespace P02.ORMExplore.Framework.SqlTransactionInConns
{
    public interface IUnitOfWork:IDisposable
    {
        void Invoke(Action action);
    }
}
