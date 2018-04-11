using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Abp.Modules;

namespace CashTest
{
    [DependsOn(typeof(MyModule1))]
    public class MyModule2 : AbpModule
    {
        private readonly MyModule1 _module1;

        public MyModule2(MyModule1 module1)
        {
            _module1 = module1;
        }

        public override void PreInitialize()
        {
            _module1.MyModuleMethod();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
