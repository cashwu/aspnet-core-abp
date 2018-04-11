using System;
using System.Collections.Generic;
using System.Text;
using Abp.Configuration.Startup;

namespace CashTest.Extensions
{
    public static class MyModuleConfigurationExtension
    {
        public static MyModuleConfig MyModule(this IModuleConfigurations moduleConfigurations)
        {
            return moduleConfigurations.AbpConfiguration
                .GetOrCreate("MyModuleConfig", () => moduleConfigurations.AbpConfiguration.IocManager.Resolve<MyModuleConfig>());
        }
    
    }
}
