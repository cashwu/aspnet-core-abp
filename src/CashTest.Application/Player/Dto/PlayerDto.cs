using System;
using System.Collections.Generic;
using System.Text;
using Abp.Application.Services.Dto;

namespace CashTest.Player.Dto
{
    public class PlayerDto : EntityDto<long>
    {
        public PlayerDto()
        {
        }

        public long PlayerID { get; set; }
        public string PlayerName { get; set; }
        public long MapID { get; set; }
    }
}