using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code.Game
{
    /// <summary>
    /// This class represents a game round result
    /// </summary>
    public class GameRoundResult
    {
        /// <summary>
        /// Is the game won by the player, 
        /// i.e. is there a prize > 0?
        /// </summary>
        public bool IsWin { get; set; }
        
        /// <summary>
        /// The win amount
        /// </summary>
        public double WinAmount { get; set; }

        /// <summary>
        /// Did the player get a bonus during this round?
        /// </summary>
        public bool HasBonus { get; set; }
    }
}
