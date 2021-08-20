using AutomationTest_Code.BL;
using AutomationTest_Code.Entities;
using AutomationTest_Code.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AutomationTest_Code
{
    /// <summary>
    /// This class is the interface to test.
    /// 1. It has a single public method that runs a game in auto mode.
    /// 2. It has a property that allows you to get, after autoplay is complete, the 
    ///     entire game round result collection
    /// It also handles the player balance for each run
    /// </summary>
    public class GameManager
    {
        #region private members
        private const int AUTO_PLAY_COUNT = 50;
        private IGameRound m_gameRound;
        private int m_roundsCountLimit = AUTO_PLAY_COUNT;
        #endregion

        #region public properties
        /// <summary>
        /// How many rounds were run during the auto play
        /// </summary>
        public int RoundsCount { get; private set; }

        /// <summary>
        /// All the results of auto run rounds
        /// These include the IsWin indication and the prize that was won
        /// </summary>
        public List<GameRoundResult>AutoPlayedRounds { get; set; }
        #endregion

        #region CTors
        public GameManager()
        {
            InitializeInstance(new GameRound(), AUTO_PLAY_COUNT);
        }
        
        /// <summary>
        /// Support DI
        /// </summary>
        /// <param name="gameRound"></param>
        public GameManager(IGameRound gameRound)
        {
            InitializeInstance(gameRound, AUTO_PLAY_COUNT);
        }

        public GameManager(IGameRound gameRound, int roundCount)
        {
            InitializeInstance(gameRound, roundCount);
        }


        #endregion

        #region public methods
        /// <summary>
        /// Run auto play.
        /// 1. Run auto play as multiple game rounds
        /// 2. Handle player balance - win and lose
        /// 3. Stop if player balance is not sufficient
        /// 4. Save all rounds results into public collection
        /// </summary>
        /// <param name="player">a player entity</param>
        /// <param name="betAmount">each round bet amount, which will be deducted from the player balance</param>
        /// <returns></returns>
        public string RunAutoPlay(Player player, double betAmount)
        {
            // prepare the RoundsCounter - we will add each round to it
            RoundsCount = 0;

            // prepare the list of all game round results
            AutoPlayedRounds = new List<GameRoundResult>();

            // prepare a new player wallet instance for this player
            PlayerWallet playerWallet = new PlayerWallet(player);

            // Process game rounds - run auto play
            try
            {
                do
                {
                    // try to reduce the balance for the player
                    playerWallet.ReduceBetAmount(betAmount);

                    // Run the game round
                    GameRoundResult result = m_gameRound.GenerateRound(player);

                    // add to the rounds counter
                    RoundsCount++;

                    // is this round won by the player? if so - add to balance
                    if (result.IsWin)
                        playerWallet.CreditBalance(result.WinAmount);

                    // was there a bonus?
                    result.HasBonus = IsQualifiedForBonus(player, betAmount);
                        
                    // add the round result to the saved results collection
                    AutoPlayedRounds.Add(result);
                }
                while (RoundsCount < m_roundsCountLimit);
            }
            catch(GameException ex)
            {
                // Something went wrong! return the error message to the caller.
                return ex.Message;
            }

            // all rounds completed - return success
            return "Success";
        }
        #endregion

        #region private region
        /// <summary>
        /// You need to change this method to answer part 2 of the exam
        /// i. Player has played at least 10 win rounds - use AutoPlayedRounds to determine it.
        /// ii.Each bet amount is greater(>) than a win amount - use AutoPlayedRounds and betAmount
        /// iii.Player’s total sum of wins is equal the half of the total sum of bet amounts - calculate it
        /// </summary>
        /// <returns></returns>
        private bool IsQualifiedForBonus(Player player, double betAmount)
        {
            return true;
        }

        /// <summary>
        /// Initializtion helper method
        /// </summary>
        /// <param name="gameRound"></param>
        /// <param name="roundCount"></param>
        private void InitializeInstance(IGameRound gameRound, int roundCount)
        {
            m_gameRound = gameRound;
            m_roundsCountLimit = roundCount;
        }
    }
    #endregion
}
