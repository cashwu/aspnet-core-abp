using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Abp.Runtime.Validation;

namespace CashTest.Player.Dto
{
    public class PlayerInput
    {
        public long PlayerID { get; set; }
        public string PlayerName { get; set; }
        public long MapID { get; set; }
    }

    public class GetPlayerInput
    {
        public string PlayerName { get; set; }
        public long MapID { get; set; }
    }

    public class CreatePlayerInput : IShouldNormalize
    {
        [Required] public string PlayerName { get; set; }

        public long MapID { get; set; }

        public void Normalize()
        {
            if (MapID == 0)
            {
                MapID = 1;
            }
        }
    }
}