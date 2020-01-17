using MySql.Data.MySqlClient;
using System.Collections.Generic;
using Xunit;
using Z.Dapper.Plus;

namespace DapperPlusTests
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var items = new List<Animal>
            {
                new Animal
                {
                    Name = "Doggo",
                    Age = 4,
                }
            };

            InsertMany(items);
        }

        public class Animal
        {
            public string Name { get; set; }
            public int Age { get; set; }
        }

        public void InsertMany(IEnumerable<Animal> items)
        {
            var connString = "Server=localhost; Port=3306; Database=dapper; Uid=test; Pwd=test; SslMode=none; Max Pool Size=1000";
            using (var connection = new MySqlConnection(connString))
            {
                connection.Open();
                connection.BulkInsert(items);
            }
        }
    }
}
