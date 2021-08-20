using System;
using System.Collections.Generic;

namespace AutomationTest_Code.BL
{
    /// <summary>
    /// This class is responsible to pick a random prize from the table
    /// </summary>
    public class PrizeTablePicker
    {
        private static Random random = new Random();

        public double PickPrize(List<double> prizeTable)
        {
            int index = random.Next(prizeTable.Count);
            return prizeTable[index];
        }
    }
}
