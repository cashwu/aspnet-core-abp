using Abp.AspNetCore.Mvc.Controllers;
using Abp.IdentityFramework;
using Microsoft.AspNetCore.Identity;

namespace CashTest.Controllers
{
    public abstract class CashTestControllerBase: AbpController
    {
        protected CashTestControllerBase()
        {
            LocalizationSourceName = CashTestConsts.LocalizationSourceName;
        }

        protected void CheckErrors(IdentityResult identityResult)
        {
            identityResult.CheckErrors(LocalizationManager);
        }
    }
}
