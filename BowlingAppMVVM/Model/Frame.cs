using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class Frame : FrameBase
    {
        #region Properties definition   
        public override Game.SHOT_VALUE this[int index]
        {
            get
            {
                return this._shots[index];
            }
            set
            {
                this.SetShot(index, value);
            }
        }

        public override (int, Game.SCORE_STATE) Score
        {
            get
            {
                return this.CalculateScore();
            }
        }

        public override Game.SHOT_VALUE[] Shots
        {
            get
            {
                return this._shots;
            }
        }
        #endregion Properties definition

        #region Members definition
        private readonly Game.SHOT_VALUE[] _shots;
        #endregion Members definition

        #region Constructors definition
        public Frame()
        {
            this._shots = new Game.SHOT_VALUE[] { Game.SHOT_VALUE.Undefined, Game.SHOT_VALUE.Undefined };
        }
        #endregion Constructors definition

        #region Methods definition
        private (int, Game.SCORE_STATE) CalculateScore()
        {
            if (this[0] == Game.SHOT_VALUE.Strike)
            {
                return (10, Game.SCORE_STATE.Strike);
            }
            else if (this[1] == Game.SHOT_VALUE.Spare)
            {
                return (10, Game.SCORE_STATE.Spare);
            }
            else
            {
                int score = Game.ShotScores[this[0]] + Game.ShotScores[this[1]];
                return (score, Game.SCORE_STATE.Standard);
            }
        }

        private void SetShot(int index, Game.SHOT_VALUE value)
        {
            this.SetProperty<Game.SHOT_VALUE>(ref this._shots[index], value);
        }
        #endregion Methods definition
    }
}
