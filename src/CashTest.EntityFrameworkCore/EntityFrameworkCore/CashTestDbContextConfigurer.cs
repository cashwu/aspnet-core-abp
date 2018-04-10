using System.Data.Common;
using Microsoft.EntityFrameworkCore;

namespace CashTest.EntityFrameworkCore
{
    public static class CashTestDbContextConfigurer
    {
        public static void Configure(DbContextOptionsBuilder<CashTestDbContext> builder, string connectionString)
        {
            builder.UseSqlServer(connectionString);
        }

        public static void Configure(DbContextOptionsBuilder<CashTestDbContext> builder, DbConnection connection)
        {
            builder.UseSqlServer(connection);
        }
    }
}
