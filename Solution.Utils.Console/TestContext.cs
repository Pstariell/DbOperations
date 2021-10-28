using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;

namespace Solution.Utils.Console
{
    public class TextContext : DbContext
    {


        public TextContext(string connectionString)
        {
            _connectionString = connectionString;
            this.Database.SetCommandTimeout(500000);
        }

        public TextContext(DbContextOptions<TextContext> options)
            : base(options)
        {
        }

        public TextContext() 
        {
        }

        private string _connectionString { get; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!string.IsNullOrEmpty(_connectionString)) optionsBuilder.UseSqlServer(_connectionString);
            if (!optionsBuilder.IsConfigured && string.IsNullOrEmpty(_connectionString))
                optionsBuilder.UseSqlServer(
                    "Server=MI-MEMORY20-PRE\\CRM;Database=integration;User Id=crmdb_user;Password=C0nverse$$9");

        }

    }
}
