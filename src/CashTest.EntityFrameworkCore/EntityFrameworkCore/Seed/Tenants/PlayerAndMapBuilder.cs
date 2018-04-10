using System;
using System.Collections.Generic;
using System.Text;
using CashTest.EntityFrameworkCore.Seed.Host;

namespace CashTest.EntityFrameworkCore.Seed.Tenants
{
    public class PlayerAndMapBuilder
    {
        private readonly CashTestDbContext _context;

        public PlayerAndMapBuilder(CashTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            new DefaultMapsCreator(_context).Create();
            new DefaultPlayersCreator(_context).Create(); 
        }
    }
}
