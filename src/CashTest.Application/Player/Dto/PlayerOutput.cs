using System;
using System.Collections.Generic;
using System.Text;

namespace CashTest.Player.Dto
{
    public class PlayerOutput
    {
        public long MapID { get; set; }
        public string PlayerName { get; set; }
    }

    public class GetPlayersOutput
    {
        public IEnumerable<PlayerDto> Players { get; set; }
    }
}
