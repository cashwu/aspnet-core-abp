using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashTest.Entities;

namespace CashTest.EntityFrameworkCore.Seed.Host
{
    class DefaultPlayersCreator
    {
        private readonly CashTestDbContext _context;

        public DefaultPlayersCreator(CashTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            var defaultPlayer = _context.Players.FirstOrDefault(t => t.PlayerName == Player.DefaultPlayerName);
            if (defaultPlayer == null)
            {
                _context.Players.Add(new Player { PlayerName = Player.DefaultPlayerName });
                _context.SaveChanges();
            }
        }
    }
}
