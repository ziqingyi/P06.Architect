using System;
using System.Collections.Generic;
using System.Text;
using System.Transactions;

namespace P02.ORMExplore.Framework.SqlTransactionInConns
{
    public class UnitOfWork : IUnitOfWork
    {

        //provide transactions between different sql Connections
        public void Invoke(Action action)
        {
            using (TransactionScope trans = new TransactionScope())
            {
                action.Invoke();
                trans.Complete();
            }
        }


        public void Dispose()
        {

        }
    }
}
