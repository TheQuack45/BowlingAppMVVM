using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingAppMVVM.Model;

namespace BowlingAppMVVM.ViewModel
{
    public static class Utility
    {
        #region Static members definition
        public static Dictionary<Game.SHOT_VALUE, Utility.SHOT_VALUE> ModelToViewModelShots = new Dictionary<Game.SHOT_VALUE, Utility.SHOT_VALUE>()
        {
            { Game.SHOT_VALUE.Zero, Utility.SHOT_VALUE.Zero },
            { Game.SHOT_VALUE.One, Utility.SHOT_VALUE.One },
            { Game.SHOT_VALUE.Two, Utility.SHOT_VALUE.Two },
            { Game.SHOT_VALUE.Three, Utility.SHOT_VALUE.Three },
            { Game.SHOT_VALUE.Four, Utility.SHOT_VALUE.Four },
            { Game.SHOT_VALUE.Five, Utility.SHOT_VALUE.Five },
            { Game.SHOT_VALUE.Six, Utility.SHOT_VALUE.Six },
            { Game.SHOT_VALUE.Seven, Utility.SHOT_VALUE.Seven },
            { Game.SHOT_VALUE.Eight, Utility.SHOT_VALUE.Eight },
            { Game.SHOT_VALUE.Nine, Utility.SHOT_VALUE.Nine },
            { Game.SHOT_VALUE.Spare, Utility.SHOT_VALUE.Spare },
            { Game.SHOT_VALUE.Strike, Utility.SHOT_VALUE.Strike },
            { Game.SHOT_VALUE.Undefined, Utility.SHOT_VALUE.Undefined },
        };

        public static Dictionary<Utility.SHOT_VALUE, Game.SHOT_VALUE> ViewModelToModelShots = new Dictionary<Utility.SHOT_VALUE, Game.SHOT_VALUE>()
        {
            { Utility.SHOT_VALUE.Zero, Game.SHOT_VALUE.Zero },
            { Utility.SHOT_VALUE.One, Game.SHOT_VALUE.One },
            { Utility.SHOT_VALUE.Two, Game.SHOT_VALUE.Two },
            { Utility.SHOT_VALUE.Three, Game.SHOT_VALUE.Three },
            { Utility.SHOT_VALUE.Four, Game.SHOT_VALUE.Four },
            { Utility.SHOT_VALUE.Five, Game.SHOT_VALUE.Five },
            { Utility.SHOT_VALUE.Six, Game.SHOT_VALUE.Six },
            { Utility.SHOT_VALUE.Seven, Game.SHOT_VALUE.Seven },
            { Utility.SHOT_VALUE.Eight, Game.SHOT_VALUE.Eight },
            { Utility.SHOT_VALUE.Nine, Game.SHOT_VALUE.Nine },
            { Utility.SHOT_VALUE.Spare, Game.SHOT_VALUE.Spare },
            { Utility.SHOT_VALUE.Strike, Game.SHOT_VALUE.Strike },
            { Utility.SHOT_VALUE.Undefined, Game.SHOT_VALUE.Undefined },
        };

        public enum SCORE_STATE { Standard, Spare, Strike };
        public enum SHOT { First, Second };
        public enum SHOT_VALUE { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Spare, Strike, Undefined };
        #endregion Static members definition
    }
}
