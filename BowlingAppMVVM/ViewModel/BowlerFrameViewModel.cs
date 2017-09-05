using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BowlingAppMVVM.Model;
using System.ComponentModel;

namespace BowlingAppMVVM.ViewModel
{
    class BowlerFrameViewModel : FrameViewModelBase
    {
        #region Members definition
        private readonly Frame _frame;

        #region Command members
        //private ICommand _selectionChangedCommand;
        //public ICommand SelectionChangedCommand
        //{
        //    get
        //    {
        //        if (_selectionChangedCommand == null)
        //        {
        //            _selectionChangedCommand = new NoParamRelayCommand(() => Console.WriteLine("Selection changed fired"));
        //        }
        //        return _selectionChangedCommand;
        //    }
        //}
        #endregion Command members
        #endregion Members definition

        #region Properties definition
        // TODO: This should be a collection of shots. Not individual properties.
        // That would also allow a better class structure.
        public Utility.SHOT_VALUE First
        {
            get
            {
                return Utility.ModelToViewModelShots[this._frame[0]];
            }
            set
            {
                this._frame[0] = Utility.ViewModelToModelShots[value];
            }
        }
        public Utility.SHOT_VALUE Second
        {
            get
            {
                return Utility.ModelToViewModelShots[this._frame[1]];
            }
            set
            {
                this._frame[1] = Utility.ViewModelToModelShots[value];
            }
        }
        #endregion Properties definition

        #region Constructors definition
        public BowlerFrameViewModel(Frame frame)
        {
            this._frame = frame;
            this._frame.PropertyChanged += new PropertyChangedEventHandler(UpdateShots);
        }
        #endregion Constructors defintition

        #region Methods definition
        //public override SHOT_VALUE GetShotScore(SHOT shot)
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
            Game.SHOT_VALUE second = this._frame.Shots[1];

            this.First = Utility.ModelToViewModelShots[first];
            RaisePropertyChanged(nameof(First));
            this.Second = Utility.ModelToViewModelShots[second];
            RaisePropertyChanged(nameof(Second));
        }
        #endregion Methods definition
    }
}
