using System;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace Un.EntityFramework.ReadWriteContext.Tests
{
    public abstract class TestWithSqlite : IDisposable
    {
        private const string _inMemoryConnectionString = "DataSource=:memory:";
        private readonly SqliteConnection _connection;

        protected readonly TestDbContext DbContext;

        protected TestWithSqlite()
        {
            _connection = new SqliteConnection(_inMemoryConnectionString);
            _connection.Open();

            var options = new DbContextOptionsBuilder<TestDbContext>()
                         .UseSqlite(_connection)
                         .Options;

            DbContext = new TestDbContext(options);
            DbContext.Database.EnsureCreated();
        }

        public void Dispose()
        {
            _connection.Close();
        }
    }
}
