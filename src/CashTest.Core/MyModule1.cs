using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Abp.Modules;
using Abp.Zero.Configuration;

namespace CashTest
{
    public class MyModule1 : AbpModule
    {
        public override void PreInitialize()
        {
            IocManager.Register<MyModuleConfig>();
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public void MyModuleMethod()
        {

        }
    }
}
