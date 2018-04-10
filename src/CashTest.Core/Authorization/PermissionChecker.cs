using Abp.Authorization;
using CashTest.Authorization.Roles;
using CashTest.Authorization.Users;

namespace CashTest.Authorization
{
    public class PermissionChecker : PermissionChecker<Role, User>
    {
        public PermissionChecker(UserManager userManager)
            : base(userManager)
        {
        }
    }
}
