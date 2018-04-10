using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CashTest.Entities;

namespace CashTest.EntityFrameworkCore.Seed.Host
{
    class DefaultMapsCreator
    {
        private readonly CashTestDbContext _context;

        public DefaultMapsCreator(CashTestDbContext context)
        {
            _context = context;
        }

        public void Create()
        {
            CreateMaps();
        }

        private void CreateMaps()
        {
            var defaultMap = _context.Maps.FirstOrDefault(t => t.MapName == Map.DefaultMapName);
            if (defaultMap == null)
            {
                _context.Maps.Add(new Map { MapName = Map.DefaultMapName });
                _context.SaveChanges();
            }
        }
    }
}
