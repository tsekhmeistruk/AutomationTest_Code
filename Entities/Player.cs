using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code.Entities
{
    /// <summary>
    /// The player entity
    /// </summary>
    public class Player
    {
        /// <summary>
        /// Player unique ID
        /// </summary>
        public int ID { get; set; }

        /// <summary>
        /// Player Name
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Player balance
        /// </summary>
        public double Balance { get; set; }

    }
}
