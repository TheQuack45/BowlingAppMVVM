using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingAppMVVM.Model;
using System.ComponentModel;

namespace BowlingAppMVVM.ViewModel
{
    class OneShotBowlerFrameViewModel : FrameViewModelBase
    {
        #region Members definition
        private readonly OneShotFrame _frame;
        #endregion Members definition

        #region Properties definition
        // TODO: This should be a collection of shots, not individual properties.
        public Utility.SHOT_VALUE First { get; set; }
        #endregion Properties definition

        #region Constructors definition
        public OneShotBowlerFrameViewModel(OneShotFrame frame)
        {
            this._frame = frame;
        }
        #endregion Constructors defintition

        #region Methods definition
        //public override SHOT_VALUE GetShotScore(SHOT shot = SHOT.First)
        //{
        //    throw new NotImplementedException();
        //}

        //public override (int score, SCORE_STATE state) GetScore()
        //{
        //    throw new NotImplementedException();
        //}

        private void UpdateShots(object sender, PropertyChangedEventArgs args)
        {
            Game.SHOT_VALUE first = this._frame.Shots[0];

            this.First = Utility.ModelToViewModelShots[first];
            RaisePropertyChanged(nameof(First));
        }
        #endregion Methods definition
    }
}
