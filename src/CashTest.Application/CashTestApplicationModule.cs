using System;
using Abp.AutoMapper;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CashTest.Authorization;

namespace CashTest
{
    [DependsOn(
        typeof(CashTestCoreModule),
        typeof(AbpAutoMapperModule))]
    public class CashTestApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.Authorization.Providers.Add<CashTestAuthorizationProvider>();
        }

        public override void Initialize()
        {
            var thisAssembly = typeof(CashTestApplicationModule).GetAssembly();

            IocManager.RegisterAssemblyByConvention(thisAssembly);

            Configuration.Modules.AbpAutoMapper().Configurators.Add(
                // Scan the assembly for classes which inherit from AutoMapper.Profile
                cfg => cfg.AddProfiles(thisAssembly)
            );

            Configuration.Caching.ConfigureAll(cache => { cache.DefaultSlidingExpireTime = TimeSpan.FromHours(1); });

            Configuration.Caching.Configure("Test",
                cache => { cache.DefaultSlidingExpireTime = TimeSpan.FromHours(2); });
        }
    }
}