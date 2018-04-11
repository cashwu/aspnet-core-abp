using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Abp.Domain.Repositories;
using Abp.UI;
using AutoMapper;
using CashTest.IRepositories;
using CashTest.Player.Dto;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CashTest.Player
{
    public class PlayerAppService : CashTestAppServiceBase, IPlayerAppService
    {
        private readonly IPlayerRepository _playeRepository;

        public PlayerAppService(IPlayerRepository playeRepository)
        {
            _playeRepository = playeRepository;
        }

        public GetPlayersOutput GetPlayers(GetPlayerInput input)
        {
            Logger.Info($" get player input :: {JsonConvert.SerializeObject(input)}");
            Logger.Info($" get player input :: {input}");


            if (!string.IsNullOrEmpty(input.PlayerName))
            {
                var playerEntityList = _playeRepository.GetAllList(a => a.PlayerName.Contains(input.PlayerName));
                return new GetPlayersOutput
                {
                    Players = playerEntityList.Select(a => new PlayerDto
                    {
                        PlayerID = a.Id,
                        PlayerName = a.PlayerName
                    })
                };
            }

            if (input.MapID > 0)
            {
                var playerEntityList = _playeRepository.GetPlayersWithMap(input.MapID);

                return new GetPlayersOutput
                {
                    Players = playerEntityList.Select(a => new PlayerDto
                    {
                        PlayerID = a.Id,
                        PlayerName = a.PlayerName
                    })
                };
            }

            throw new UserFriendlyException("input error");
        }

        public void UpdatePlayer(PlayerInput input)
        {
            Logger.Info($" update a playe for input {input}");

            var playerEntity = _playeRepository.Get(input.PlayerID);
            if (playerEntity == null)
            {
                throw new UserFriendlyException("player not exist");
            }

            if (!string.IsNullOrEmpty(input.PlayerName))
            {
                playerEntity.PlayerName = input.PlayerName;
            }

            if (input.MapID > 0)
            {
                playerEntity.MapID = input.MapID;
            }

            //_playeRepository.Update(playerEntity);
        }

        public void CreatePlayer(PlayerInput input)
        {
            var playerEntity = _playeRepository.FirstOrDefault(a => a.PlayerName.Contains(input.PlayerName));
            if (playerEntity != null)
            {
                throw new UserFriendlyException("player exist");
            }

            playerEntity = new Entities.Player
            {
                PlayerName = input.PlayerName,
                MapID = 1
            };
            _playeRepository.Insert(playerEntity);
        }
    }
}