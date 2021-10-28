using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;
using System.Text;
using Solution.Utils.Infrastracture;

namespace Solution.Utils.Net4
{
    public class Database<TContext> : IDatabase<TContext> where TContext : DbContext, new()
    {
        private TContext _context = null;
        public DbConnection Connection
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }

                return _context.Database.Connection;
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }
    }
}
