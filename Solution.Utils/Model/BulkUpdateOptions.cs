﻿using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq.Expressions;
using System.Text;
using Solution.Utils.Infrastracture;

namespace Solution.Utils.Model
{
    public class BulkUpdateOptions<TSource> : IBulkUpdateOptions<TSource>
    {
        public DbConnection Connection { get; set; }
        public DbTransaction Transaction { get; set; }
        public int ConnectionTimeout { get; set; } = 500000;
        public string tableName { get; set; }
        public Expression<Func<TSource, object>> primaryKeys { get; set; }
        public Expression<Func<TSource, object>> excludeprimaryKeys { get; set; }
        public Expression<Func<TSource, object>> includeColumns { get; set; }
        public Expression<Func<TSource, object>> excludeColumns { get; set; }
        public Expression<Func<TSource, object>> fieldsToUpdate { get; set; }
        public Expression<Func<TSource, object>> joinColumns { get; set; }
        public bool dropTableIfExist { get; set; }
        public bool createTableIfNotExist { get; set; }
        public string otherSqlWhereCondition { get; set; }
        public string joinSql { get; set; }
    }
}