using Abp.Application.Services;
using Abp.Application.Services.Dto;
using CashTest.MultiTenancy.Dto;

namespace CashTest.MultiTenancy
{
    public interface ITenantAppService : IAsyncCrudAppService<TenantDto, int, PagedResultRequestDto, CreateTenantDto, TenantDto>
    {
    }
}
