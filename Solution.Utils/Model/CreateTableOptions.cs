using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using Solution.Utils.Infrastracture;

namespace Solution.Utils.Model
{
    public class CreateTableOptions<TSource> : ICreateTableOptions<TSource>
    {
        public CreateTableOptions()
        {
            
        }

        public CreateTableOptions(DbConnection conn)
        {
            Connection = conn;
        }
        public string tableName { get; set; }
        public bool dropIfExists { get; set; } = false;
        public Expression<Func<TSource, object>> primaryKey { get; set; } = null;
        public Expression<Func<TSource, object>> includeColumns { get; set; } = null;
        public Expression<Func<TSource, object>> excludeColumns { get; set; } = null;
        public Expression<Func<TSource, object>> excludePrimaryKeyColumns { get; set; }
        public bool createTableIfNotExist { get; set; }
        public bool primaryKeyAutoIncrement { get; set; }
        public DbConnection Connection { get; set; } = null;
        public DbTransaction Transaction { get; set; } = null;
        public int ConnectionTimeout { get; set; } = 500000;
    }
}
