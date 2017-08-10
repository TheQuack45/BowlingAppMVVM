using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingAppMVVM.ViewModel
{
    class BowlerFramesViewModel : ViewModelBase
    {
        #region Members definition
        public string PlayerName { get; set; }
        public int Score { get; set; }

        public ObservableCollection<FrameViewModelBase> Frames { get; private set; }

        #region Command members
        private ICommand _selectionChangedCommand;
        public ICommand SelectionChangedCommand
        {
            get
            {
                if (_selectionChangedCommand == null)
                {
                    _selectionChangedCommand = new NoParamRelayCommand(() => { this.UpdateScore(); });
                }
                return _selectionChangedCommand;
            }
        }
        #endregion Command members
        #endregion Members definition

        #region Constructors definition
        /// <summary>
        /// Represents the ViewModel for the BowlerFrames.xaml View.
        /// </summary>
        public BowlerFramesViewModel(string playerName = "")
        {
            this.PlayerName = playerName;
            RaisePropertyChanged(PlayerName);
            this.Frames = new ObservableCollection<FrameViewModelBase>();
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new BowlerFrameViewModel());
            this.Frames.Add(new OneShotBowlerFrameViewModel());
        }
        #endregion Constructors definition

        #region Methods definition
        private void UpdateScore()
        {
            // TODO: Implement this
            throw new NotImplementedException();
        }
        #endregion Methods Definition
    }
}
