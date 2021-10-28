using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;
using Solution.Utils.Infrastracture;

namespace Solution.Utils.Model
{
    public class DropTableOptions<TSource> : IDropTableOptions<TSource>
    {
        public DbConnection Connection { get; set; } = null;
        public DbTransaction Transaction { get; set; } = null;
        public int ConnectionTimeout { get; set; } = 500000;
        public string tableName { get; set; }
        public bool useIfExist { get; set; } = false;
    }
}
