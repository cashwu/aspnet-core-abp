using System;
using System.Collections.Generic;
using System.Diagnostics.Tracing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.Domain.Repositories;
using Abp.Domain.Uow;
using Abp.Events.Bus;
using Abp.Events.Bus.Handlers;
using Abp.Runtime.Caching;
using Abp.Runtime.Session;
using Abp.UI;
using AutoMapper;
using CashTest.Authorization.Users;
using CashTest.IRepositories;
using CashTest.Player.Dto;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;

namespace CashTest.Player
{
    public class PlayerAppService : CashTestAppServiceBase, IPlayerAppService, IEventHandler<TaskCompletedEventData>
    {
        private readonly IPlayerRepository _playeRepository;
        private readonly IUnitOfWorkManager _unitOfWorkManager;

        public IAbpSession Session { get; set; }

        public ICacheManager CacheManager { get; set; }

        public IEventBus EventBus { get; set; }

        public PlayerAppService(IPlayerRepository playeRepository, IUnitOfWorkManager unitOfWorkManager)
        {
            _playeRepository = playeRepository;
            _unitOfWorkManager = unitOfWorkManager;
            Session = NullAbpSession.Instance;

            EventBus = NullEventBus.Instance;
        }

        public GetPlayersOutput GetPlayer()
        {
            var result = _playeRepository.GetPlayersWithMap(0);

            using (var unitOfWork = _unitOfWorkManager.Begin())
            {
                //XXX
                unitOfWork.Complete();
                _unitOfWorkManager.Current.Completed += (sender, args) => { /* TODO: 給派發的人發送郵件*/ };
            }

            var ev =EventBus.Register<TaskCompletedEventData>(e =>
            {
               // XXXX 
            });
            ev.Dispose();


            using (_unitOfWorkManager.Current.DisableFilter(AbpDataFilters.SoftDelete))
            {
                // disable filter 
            }

            using (CurrentUnitOfWork.DisableFilter(AbpDataFilters.SoftDelete))
            {
                
            }

            return new GetPlayersOutput();
        }

        [UnitOfWork(isTransactional: false, IsDisabled = false)]
        public GetPlayersOutput GetPlayers(GetPlayerInput input)
        {
            Logger.Info($" get player input :: {JsonConvert.SerializeObject(input)}");
            Logger.Info($" get player input :: {input}");
            Logger.Warn($"session :: {JsonConvert.SerializeObject(Session)}");

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

        private Entities.Player GetPlayerFromDb(long id)
        {
            return _playeRepository.Get(id);
        }

        public void UpdatePlayer(PlayerInput input)
        {
            Logger.Info($" update a playe for input {input}");

            var playerEntity = CacheManager.GetCache("player")
                .Get(input.PlayerID, () => GetPlayerFromDb(input.PlayerID));

            //var playerEntity = _playeRepository.Get(input.PlayerID);
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

        public void HandleEvent(TaskCompletedEventData eventData)
        {
            // eventData
        }
    }
    public class TaskEventData : EventData
    {
        public Task Task { get; set; }
    }

    public class TaskCreatedEventData : TaskEventData
    {
        public User CreatorUser { get; set; }
    }

    public class TaskCompletedEventData : TaskEventData
    {
        public User CompletorUser { get; set; }
    }
}