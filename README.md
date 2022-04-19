# DbOperations

- Bulk Insert

```
db.Connection.BulkInsert(listToBulk, opt =>
  {
      opt.primaryKeys = s => s.id;
  });
```

- Bulk Insert With Result 

```
IEnumerable<entityToCreate> result = db.Connection.BulkInsertWithResult(listToBulk, opt =>
{
    opt.primaryKeys = s => s.id;
    opt.excludeColumns = s=> {s.data2};
});
```
- Bulk Update

```
db.Connection.BulkUpdate(listToBulk, opt =>
{
    opt.tableName = "tblTest";
    opt.primaryKeys = c => new { c.id };
    opt.joinColumns = c => new { c.id };
    opt.fieldsToUpdate = c => new { c.data };
});
```
- Bulk Update With Result 
```
 db.Connection.BulkUpdateWithResult<entityToCreate, entityTable>(listToBulk, opt =>
{
    opt.tableName = "tblTest";
    opt.primaryKeys = c => new { c.id };
    opt.joinColumns = c => new { c.id };
    opt.fieldsToUpdate = c => new { c.data };
}).ToList()
    .ForEach(s => System.Console.WriteLine(JsonConvert.SerializeObject(s)));
```

## Utils 
- Create Table
 ```
db.Connection.CreateTable<entityToCreate>(opt =>
 {
     opt.primaryKey = c => new {c.id};
     opt.tableName = "tblTest";
     //opt.excludeColumns = c => new {c.data};
     opt.dropIfExists = true;
     opt.primaryKeyAutoIncrement = true;
 });
 ```
 - Drop Table
 ```
 db.DropTable(opt =>
{
    opt.tableName = "tblTest";
    opt.useIfExist = true;
});
 ```
