using System.Threading.Tasks;
using Abp.Application.Services;
using CashTest.Sessions.Dto;

namespace CashTest.Sessions
{
    public interface ISessionAppService : IApplicationService
    {
        Task<GetCurrentLoginInformationsOutput> GetCurrentLoginInformations();
    }
}
