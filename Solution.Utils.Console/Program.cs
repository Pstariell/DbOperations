using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;
using Solution.Utils.Net5;

namespace Solution.Utils.Console
{
 

    public class entityToCreate
    {
        public int id { get; set; }
        public string data { get; set; }
        public string data2 { get; set; }

    }

    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new Database<TextContext>())
            {
                db.Connection.CreateTable<entityToCreate>(opt =>
                {
                    opt.primaryKey = c => new {c.id};
                    opt.tableName = "tblTest";
                    opt.excludeColumns = c => new {c.data};
                    opt.dropIfExists = true;
                }).BulkInsert(new List<entityToCreate>(), opt =>
                {
                    opt.tableName = "dsds";
                    opt.
                });
            }
        }
    }
}
