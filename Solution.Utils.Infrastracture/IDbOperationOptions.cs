using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Solution.Utils.Infrastracture
{
    public interface IDbOperationOptions
    {
         DbConnection Connection { get; set; }
         DbTransaction Transaction { get; set; }
        int ConnectionTimeout { get; set; }
    }
}
