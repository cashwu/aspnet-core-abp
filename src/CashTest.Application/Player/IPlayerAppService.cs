using Abp.Application.Services;
using CashTest.Player.Dto;

namespace CashTest.Player
{
    public interface IPlayerAppService : IApplicationService
    {
        GetPlayersOutput GetPlayers(GetPlayerInput input);
        void UpdatePlayer(PlayerInput input);
        void CreatePlayer(PlayerInput input);
    }
}