using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public interface IFrame
    {
        #region Properties declaration
        Game.SHOT_VALUE this[int index] { get; set; }
        (int, Game.SCORE_STATE) Score { get; }
        #endregion Properties declaration
    }
}
