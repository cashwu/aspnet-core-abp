using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;
using CashTest.Configuration;
using CashTest.Web;

namespace CashTest.EntityFrameworkCore
{
    /* This class is needed to run "dotnet ef ..." commands from command line on development. Not used anywhere else */
    public class CashTestDbContextFactory : IDesignTimeDbContextFactory<CashTestDbContext>
    {
        public CashTestDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<CashTestDbContext>();
            var configuration = AppConfigurations.Get(WebContentDirectoryFinder.CalculateContentRootFolder());

            CashTestDbContextConfigurer.Configure(builder, configuration.GetConnectionString(CashTestConsts.ConnectionStringName));

            return new CashTestDbContext(builder.Options);
        }
    }
}
