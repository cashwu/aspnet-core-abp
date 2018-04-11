using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;
using Abp.Modules;

namespace CashTest
{
    public class MyModule1 : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }

        public void MyModuleMethod()
        {

        }
    }
}
