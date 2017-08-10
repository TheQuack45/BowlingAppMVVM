using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class Frame : IFrame
    {
        #region Members definition
        public Game.SHOT_VALUE this[int index]
        {
            get
            {
                return this.Shots[index];
            }
            set
            {
                this.Shots[index] = value;
            }
        }
        public (int, Game.SCORE_STATE) Score
        {
            get
            {
                return this.CalculateScore();
            }
        }

        public Game.SHOT_VALUE[] Shots { get; private set; }
        #endregion Members definition

        #region Constructors definition
        public Frame()
        {
            this.Shots = new Game.SHOT_VALUE[] { Game.SHOT_VALUE.Undefined, Game.SHOT_VALUE.Undefined };
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
        #endregion Methods definition
    }
}
