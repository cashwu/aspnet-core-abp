using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Abp.EntityFrameworkCore;
using CashTest.Entities;
using CashTest.IRepositories;

namespace CashTest.EntityFrameworkCore.Repositories
{
    public class PlayerRepository : CashTestRepositoryBase<Player, long> , IPlayerRepository
    {
        public PlayerRepository(IDbContextProvider<CashTestDbContext> dbContextProvider) : base(dbContextProvider)
        {
        }

        public List<Player> GetPlayersWithMap(long mapId)
        {
            var query = GetAll();

            if (mapId > 0)
            {
                query = query.Where(a => a.MapID == mapId);
            }

            return query.ToList();
        }

        public async Task<List<Player>> GetPlayersWithMapAsync(long mapId)
        {
            return await GetAllListAsync(a => a.MapID == mapId);
        }
    }
}
