using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingAppMVVM.ViewModel
{
    class BowlerFrameViewModel : FrameViewModelBase
    {
        #region Members definition
        public SHOT_VALUE First { get; set; }

        public SHOT_VALUE Second { get; set; }

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

        #region Constructors definition
        public BowlerFrameViewModel()
        {

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


        #endregion Methods definition
    }
}
