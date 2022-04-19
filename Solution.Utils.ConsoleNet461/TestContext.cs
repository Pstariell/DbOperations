using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Solution.Utils.ConsoleNet461
{
    public class TestContext : DbContext
    {


        public TestContext(string connectionString)
        {
            _connectionString = connectionString;
            this.Database.CommandTimeout = 500000;
        }

        //public TextContext(DbContextOptions<TextContext> options)
        //    : base(options)
        //{
        //}

        public TestContext()
        {
        }

        private string _connectionString { get; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }


    }
}
