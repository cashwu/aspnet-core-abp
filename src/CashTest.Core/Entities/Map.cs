using System;
using System.Collections.Generic;
using System.Text;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CashTest.Entities
{
    public class Map : Entity<long>, IHasCreationTime
    {
        public const string DefaultMapName = "DefaultMap";

        public virtual string MapName { get; set; }

        public DateTime CreationTime { get; set; }

        public virtual ICollection<Player> Player { get; set; }

        public Map()
        {
            CreationTime = DateTime.Now;
        }
    }
}
