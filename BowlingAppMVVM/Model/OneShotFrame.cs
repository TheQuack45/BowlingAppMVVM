﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class OneShotFrame : FrameBase
    {
        #region Members definition
        private readonly Game.SHOT_VALUE[] _shots;
        #endregion Members definition

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

        #region Constructors definition
        public OneShotFrame(PropertyChangedEventHandler handler)
        {
            this.PropertyChanged += handler;
            Game.SHOT_VALUE[] shots = new Game.SHOT_VALUE[] { Game.SHOT_VALUE.Undefined, };
            this.SetProperty<Game.SHOT_VALUE[]>(ref this._shots, shots);
        }
        #endregion Constructors definition

        #region Methods definition
        private (int, Game.SCORE_STATE) CalculateScore()
        {
            if (this[0] == Game.SHOT_VALUE.Strike)
            {
                return (10, Game.SCORE_STATE.Strike);
            }
            else
            {
                return (Game.ShotScores[this[0]], Game.SCORE_STATE.Standard);
            }
        }

        private void SetShot(int index, Game.SHOT_VALUE value)
        {
            if (value == Game.SHOT_VALUE.Spare)
            {
                // TODO: Should this throw an exception?
                return;
            }

            this.SetProperty<Game.SHOT_VALUE>(ref this._shots[index], value);
        }
        #endregion Methods definition
    }
}
