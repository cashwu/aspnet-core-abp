using Microsoft.AspNetCore.Antiforgery;
using CashTest.Controllers;

namespace CashTest.Web.Host.Controllers
{
    public class AntiForgeryController : CashTestControllerBase
    {
        private readonly IAntiforgery _antiforgery;

        public AntiForgeryController(IAntiforgery antiforgery)
        {
            _antiforgery = antiforgery;
        }

        public void GetToken()
        {
            _antiforgery.SetCookieTokenAndHeader(HttpContext);
        }
    }
}
