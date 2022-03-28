using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Text;
using Microsoft.EntityFrameworkCore;
using Solution.Utils.Infrastracture;

namespace Solution.Utils.Net5
{
    public class Database<TContext> : IDatabase<TContext> where TContext : DbContext, new()
    {
        private DbContext _context = null;

        public IDbConnection Connection
        {
            get
            {
                if (_context == null)
                {
                    _context = new TContext();
                }
                return _context.Database.GetDbConnection();
            }
        }

        public void Dispose()
        {
            _context.Dispose();
            _context = null;
        }
    }
}
