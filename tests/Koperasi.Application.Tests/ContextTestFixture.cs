using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Linq;

namespace Koperasi.Application.Tests
{
    public class DbConfigSetting
    {
        public bool UseInMemoryDataBase { get; set; }
    }

    public class ContextTestFixture<TContext> where TContext : DbContext
    {
        protected TContext GetInMemoryContext() => GetInMemoryContext<TContext>();

        protected TInMemoryContext GetInMemoryContext<TInMemoryContext>() where TInMemoryContext : DbContext
        {
            var options = GetOptions<TInMemoryContext>();

            return (TInMemoryContext)Activator.CreateInstance(typeof(TInMemoryContext), options.Options);
        }

        protected TContext GetContext(DbConfigSetting setting = null, bool createNew = false)
        {
            return GetInMemoryContext();
        }

        protected TContext GetInMemoryContext(params object[] args)
        {
            var optionsList = args.ToList();
            var options = GetOptions<TContext>().Options;
            optionsList.Insert(0, options);
            return (TContext)Activator.CreateInstance(typeof(TContext), optionsList.ToArray());
        }

        private DbContextOptionsBuilder<TInMemoryContext> GetOptions<TInMemoryContext>() where TInMemoryContext : DbContext
        {
            return new DbContextOptionsBuilder<TInMemoryContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .ConfigureWarnings(cw => cw.Ignore(InMemoryEventId.TransactionIgnoredWarning));
        }
    }
}
