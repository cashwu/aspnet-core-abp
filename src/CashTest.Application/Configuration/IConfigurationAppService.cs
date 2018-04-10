using System.Threading.Tasks;
using CashTest.Configuration.Dto;

namespace CashTest.Configuration
{
    public interface IConfigurationAppService
    {
        Task ChangeUiTheme(ChangeUiThemeInput input);
    }
}
