using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingAppMVVM.ViewModel
{
    abstract class FrameViewModelBase : ViewModelBase
    {
        //#region Static members definition
        //public enum SCORE_STATE { Standard, Spare, Strike };
        //public enum SHOT { First, Second };
        //public enum SHOT_VALUE { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Spare, Strike, Undefined };
        //#endregion Static members definition

        private ICommand _selectionChangedCommand;
        public ICommand SelectionChangedCommand
        {
            get
            {
                if (_selectionChangedCommand == null)
                {
                    _selectionChangedCommand = new NoParamRelayCommand(() => Console.WriteLine("Selection changed was fired!"));
                }
                return _selectionChangedCommand;
            }
        }

        #region Methods definition
        //public abstract SHOT_VALUE GetShotScore(SHOT shot);

        //public abstract (int score, SCORE_STATE state) GetScore();
        #endregion Methods definition
    }
}
