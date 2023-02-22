using Solution.Utils.Net4;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Solution.Utils.DbOperations;

namespace Solution.Utils.ConsoleNet461
{
    class Program
    {
        public class entityToCreate
        {
            public int id { get; set; }
            public string data { get; set; }

        }

        public class entityTable
        {
            public int id { get; set; }
            public string data { get; set; }
            public string data2 { get; set; }

        }

        static void Main(string[] args)
        {
            using (var db = new Database<TestContext>())
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

                for (int i = 0; i < 400000; i++)
                {
                    listToBulk.Add(new entityToCreate() { id = i, data = (i + 100).ToString() });
                }

                //db.Connection.BulkUpdateWithResult<entityToCreate, entityTable>(listToBulk, opt =>
                //{
                //    opt.tableName = "tblTest";
                //    opt.primaryKeys = c => new { c.id };
                //    opt.joinColumns = c => new { c.id };
                //    opt.fieldsToUpdate = c => new { c.data };
                //}).ToList()
                //    .ForEach(s => System.Console.WriteLine(JsonConvert.SerializeObject(s)));

                db.Connection.BulkInsertWithResult(listToBulk, opt =>
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
