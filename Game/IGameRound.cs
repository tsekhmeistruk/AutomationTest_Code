using AutomationTest_Code.Entities;
using AutomationTest_Code.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code
{
    public interface IGameRound
    {
        GameRoundResult GenerateRound(Player player);
    }
}
