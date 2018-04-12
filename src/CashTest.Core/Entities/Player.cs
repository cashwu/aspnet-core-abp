using System;
using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;

namespace CashTest.Entities
{
    public class Player : CreationAuditedEntity<long>, ISoftDelete, IDeletionAudited
    {
        public const string DefaultPlayerName = "DefaultPlayer";

        //public DateTime CreationTime { get; set; }

        public virtual string PlayerName { get; set; }

        public virtual long MapID { get; set; }

        public virtual Map Map { get; set; }

        public Player()
        {
            //CreationTime = DateTime.Now;
            MapID = 1;
        }

        public bool IsDeleted { get; set; }
        public DateTime? DeletionTime { get; set; }
        public long? DeleterUserId { get; set; }
    }

    public class Player1 : AuditedEntity<long>
    {

    }

    public class Player2 : FullAuditedEntity
    {

    }

}