using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CashTest.Configuration;

namespace CashTest.Web.Host.Startup
{
    [DependsOn(
       typeof(CashTestWebCoreModule))]
    public class CashTestWebHostModule: AbpModule
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfigurationRoot _appConfiguration;

        public CashTestWebHostModule(IHostingEnvironment env)
        {
            _env = env;
            _appConfiguration = env.GetAppConfiguration();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CashTestWebHostModule).GetAssembly());
        }
    }
}
