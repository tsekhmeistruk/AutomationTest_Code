using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code.BL
{
    public class PrizeTableGenerator
    {
        /// this is the prize table for all game rounds 
        /// key - prize factor
        /// value - count out of 100
        private Dictionary<double, int> prizeTableAppearances = new Dictionary<double, int>();
        private List<double> prizesToPickfrom = null;
        
        /// <summary>
        /// The list of prizes for the game
        /// </summary>
        public List<double> Prizes
        {
            get { return prizesToPickfrom; }
            private set { }
        }

        /// <summary>
        /// Generte the prize table according to the appeances count
        /// </summary>
        /// <param name="prizeTable">You can inject your own appearances table</param>
        public PrizeTableGenerator(Dictionary<double, int> prizeTableAppearances)
        {
            this.prizeTableAppearances = prizeTableAppearances;
            CreatePrizesToPickFrom();
        }

        /// <summary>
        /// Create the prize table according to the the prize appearances table definition
        /// </summary>
        private void CreatePrizesToPickFrom()
        {
            prizesToPickfrom = new List<double>();

            // validate prize table is value - it should have 100 instances
            if (prizeTableAppearances.Select(item => item.Value).Sum() != 100)
                throw new Exception("Prizes instances should sum to 100");

            // create the prizes according to their appearances in the prizeTableAppearances
            foreach (double prizeFactor in prizeTableAppearances.Keys)
            {
                prizesToPickfrom.AddRange(Enumerable.Repeat(prizeFactor, prizeTableAppearances[prizeFactor]));
            }
        }
    }
}
