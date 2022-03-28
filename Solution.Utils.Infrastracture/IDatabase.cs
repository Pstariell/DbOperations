using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;

namespace Solution.Utils.Infrastracture
{
    public interface  IDatabase<TContext>: IDisposable
    {
        IDbConnection Connection { get; }
    }
}
