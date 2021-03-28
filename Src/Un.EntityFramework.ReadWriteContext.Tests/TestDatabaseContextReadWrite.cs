using System;
using System.Linq;
using System.Threading.Tasks;
using Xunit;

namespace Un.EntityFramework.ReadWriteContext.Tests
{
    public sealed class TestDatabaseContextReadWrite : TestWithSqlite
    {
        [Fact]
        public async Task DatabaseIsAvailableAndCanBeConnectedTo()
        {
            Assert.True(await DbContext.Database.CanConnectAsync());
        }

        [Fact]
        public void VerifyDatabaseIsReadOnly()
        {
            DbContext.GetReadyOnlyAsNoTracking();
            DbContext.Quiz.Add(new Quiz { Title = "Hellow" });
            Assert.Throws<InvalidOperationException>(() => DbContext.SaveChanges());
            Assert.False(DbContext.Quiz.Any());
        }

        [Fact]
        public void VerifyDatabaseIsNotReadOnly()
        {
            DbContext.Quiz.Add(new Quiz { Title = "Hellow" });
            Assert.True(DbContext.SaveChanges() > 0);
        }
    }
}
