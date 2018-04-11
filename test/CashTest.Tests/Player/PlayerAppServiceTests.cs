using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashTest.Player;
using CashTest.Player.Dto;
using Shouldly;
using Xunit;

namespace CashTest.Tests.Player
{
    public class PlayerAppServiceTests : CashTestTestBase
    {
        private IPlayerAppService _playerAppService;

        public PlayerAppServiceTests()
        {
            _playerAppService = Resolve<IPlayerAppService>();
        }

        [Fact]
        public void CreatePlayer_Test()
        {
            _playerAppService.CreatePlayer(new PlayerInput
            {
                PlayerName = "cash"
            });

            UsingDbContext(context =>
            {
                var player = context.Players.FirstOrDefault(a => a.PlayerName == "cash");

                player.ShouldNotBeNull();
            });
        }
    }
}