using System;
using System.Collections.Generic;
using System.Text;

namespace Solution.Utils.Infrastracture
{
    public interface IDropTableOptions<TSource> : IDbOperationOptions
    {
        string tableName { get; set; }
        bool useIfExist { get; set; }
    }
}
