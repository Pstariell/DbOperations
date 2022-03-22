using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
                //db.Connection.CreateTable<entityToCreate>(opt =>
                // {
                //     opt.primaryKey = c => new {c.id};
                //     opt.tableName = "tblTest";
                //     //opt.excludeColumns = c => new {c.data};
                //     opt.dropIfExists = true;
                //     opt.primaryKeyAutoIncrement = true;
                // });

                var listToBulk = new List<entityToCreate>();

                for (int i = 0; i < 100000; i++)
                {
                    listToBulk.Add(new entityToCreate() { data = "aaa" + i, data2 = "bbb" + i });
                }


                db.Connection.BulkInsertWithReturn(listToBulk, opt =>
                    {
                        opt.tableName = "tblTest";
                        opt.createTableIfNotExist = true;
                        opt.primaryKeys = c => new { c.id };
                    }).ToList()
                    .ForEach(s => System.Console.WriteLine(s.id));
            }
        }
    }
}
