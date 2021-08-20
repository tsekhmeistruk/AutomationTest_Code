using AutomationTest_Code.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code.BL
{
    /// <summary>
    /// This class manages the player wallet by updating the player balance
    /// </summary>
    public class PlayerWallet
    {
        /// <summary>
        ///  Read only player instance
        /// </summary>
        public Player Player { get; private set; }

        /// <summary>
        /// CTOR
        /// </summary>
        /// <param name="player"></param>
        public PlayerWallet(Player player)
        {
            Player = player;
        }

        /// <summary>
        /// Validate the the player balance can be deductable by a
        /// specific amount
        /// </summary>
        /// <param name="amount"></param>
        /// <returns></returns>
        public bool ValidatePlayerBalanceCanBeDeductable(double amount)
        {
            return (Player.Balance >= amount);
        }

        /// <summary>
        /// Update the balance - reduce amount
        /// </summary>
        /// <param name="amount"></param>
        public void ReduceBetAmount(double amount)
        {
            if (ValidatePlayerBalanceCanBeDeductable(amount))
                Player.Balance -= amount;
            else
                throw new GameException(MessageCodes.INSUFFICITENT_BALANCE_CODE, MessageCodes.INSUFFICITENT_BALANCE_MSG);
        }

        /// <summary>
        /// Update the balance - increase amount
        /// </summary>
        /// <param name="amount"></param>
        public void CreditBalance(double amount)
        {
            Player.Balance += amount;
        }


    }
}
