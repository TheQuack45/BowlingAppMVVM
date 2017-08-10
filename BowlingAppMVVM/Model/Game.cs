using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class Game
    {
        #region Static members definition
        public enum SHOT_VALUE { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Spare, Strike, Undefined };
        public enum SCORE_STATE { Standard, Spare, Strike };

        public static readonly Dictionary<SHOT_VALUE, int> ShotScores = new Dictionary<SHOT_VALUE, int>()
        {
            { SHOT_VALUE.Zero, 0 },
            { SHOT_VALUE.One, 1 },
            { SHOT_VALUE.Two, 2 },
            { SHOT_VALUE.Three, 3 },
            { SHOT_VALUE.Four, 4 },
            { SHOT_VALUE.Five, 5 },
            { SHOT_VALUE.Six, 6 },
            { SHOT_VALUE.Seven, 7 },
            { SHOT_VALUE.Eight, 8 },
            { SHOT_VALUE.Nine, 9 },
            { SHOT_VALUE.Undefined, 0 },
        };
        #endregion Static members definition

        #region Members definition
        public Player[] Players { get; private set; }
        #endregion Members definition

        #region Constructors definition
        public Game(int playerCount = 4)
        {
            this.Players = new Player[playerCount];
        }
        #endregion Constructors definition
    }
}
