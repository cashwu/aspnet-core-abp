using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Repositories;
using CashTest.Entities;

namespace CashTest.IRepositories
{
    public interface IPlayerRepository : IRepository<Player, long>
    {
        List<Player> GetPlayersWithMap(long mapId);
    }
}
