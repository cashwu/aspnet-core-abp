using Abp.AutoMapper;
using Microsoft.Extensions.Configuration;
using Castle.MicroKernel.Registration;
using Abp.Events.Bus;
using Abp.Modules;
using Abp.Reflection.Extensions;
using CashTest.Configuration;
using CashTest.EntityFrameworkCore;
using CashTest.Extensions;
using CashTest.Migrator.DependencyInjection;

namespace CashTest.Migrator
{
    [DependsOn(typeof(CashTestEntityFrameworkModule))]
    public class CashTestMigratorModule : AbpModule
    {
        private readonly IConfigurationRoot _appConfiguration;

        public CashTestMigratorModule(CashTestEntityFrameworkModule abpProjectNameEntityFrameworkModule)
        {
            abpProjectNameEntityFrameworkModule.SkipDbSeed = true;

            _appConfiguration = AppConfigurations.Get(
                typeof(CashTestMigratorModule).GetAssembly().GetDirectoryPathOrNull()
            );

            Configuration.Modules.MyModule().SampleConfig1 = false;
            Configuration.Modules.MyModule().SampleConfig2 = "cash";
        }

        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = _appConfiguration.GetConnectionString(
                CashTestConsts.ConnectionStringName
            );

            Configuration.BackgroundJobs.IsJobExecutionEnabled = false;
            Configuration.ReplaceService(
                typeof(IEventBus), 
                () => IocManager.IocContainer.Register(
                    Component.For<IEventBus>().Instance(NullEventBus.Instance)
                )
            );
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(typeof(CashTestMigratorModule).GetAssembly());
            ServiceCollectionRegistrar.Register(IocManager);
        }
    }
}
