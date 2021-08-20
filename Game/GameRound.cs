using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutomationTest_Code.BL;
using AutomationTest_Code.Entities;
using AutomationTest_Code.Game;

namespace AutomationTest_Code
{
    public class GameRound : IGameRound
    {
        /// this is the prize table for all game rounds 
        /// key - prize factor
        /// value - count out of 100
        private Dictionary<double, int> prizeTableAppearances = new Dictionary<double, int>();

        #region CTOR
        public GameRound()
        {
            prizeTableAppearances.Add(0, 80);
            prizeTableAppearances.Add(5, 5);
            prizeTableAppearances.Add(1, 15);
        }

        /// <summary>
        /// CTR support DI
        /// </summary>
        /// <param name="prizeTableAppearances"></param>
        public GameRound(Dictionary<double, int> prizeTableAppearances)
        {
            this.prizeTableAppearances = prizeTableAppearances;
        }
        #endregion



        public GameRoundResult GenerateRound(Player player)
        {

            GameRoundResult result = new GameRoundResult();
            // Pick a random prize //
            PrizeTableGenerator generator = new PrizeTableGenerator(prizeTableAppearances);
            PrizeTablePicker picker = new PrizeTablePicker();
            double prize = picker.PickPrize(generator.Prizes);

            if (prize > 0)
                result.IsWin = true;
            result.WinAmount = prize;

            return result;
        }





    }
}
