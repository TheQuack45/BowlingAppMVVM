using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using BowlingAppMVVM.Model;

namespace BowlingAppMVVM.ViewModel
{
    class BowlerFramesViewModel : ViewModelBase
    {
        #region Members definition
        private readonly Player _player;

        #region Command members
        //private ICommand _selectionChangedCommand;
        //public ICommand SelectionChangedCommand
        //{
        //    get
        //    {
        //        if (_selectionChangedCommand == null)
        //        {
        //            _selectionChangedCommand = new NoParamRelayCommand(() => { this.UpdateScore(); });
        //        }
        //        return _selectionChangedCommand;
        //    }
        //}
        #endregion Command members
        #endregion Members definition

        #region Properties definition
        public string PlayerName
        {
            get
            {
                return this._player.Name;
            }
            set
            {
                this._player.Name = value;
            }
        }

        public int Score { get; set; }

        public ObservableCollection<FrameViewModelBase> Frames { get; private set; }
        #endregion Properties definition

        #region Constructors definition
        /// <summary>
        /// Represents the ViewModel for the BowlerFrames.xaml View.
        /// </summary>
        public BowlerFramesViewModel(Player player)
        {
            // TODO: I don't think this ShotChanged event stuff is handled very well.
            // I get the feeling that there should be some enforcement that ShotChanged needs to have a delegate added to it at some point.
            player.ShotChanged += UpdateScore;
            this._player = player;
            this.Frames = new ObservableCollection<FrameViewModelBase>();

            foreach (FrameBase frame in player.Frames)
            {
                if (frame is Frame)
                {
                    this.Frames.Add(new BowlerFrameViewModel((Frame)frame));
                }
                else if (frame is OneShotFrame)
                {
                    this.Frames.Add(new OneShotBowlerFrameViewModel((OneShotFrame)frame));
                }
            }
        }
        #endregion Constructors definition

        #region Methods definition
        private void UpdateScore()
        {
            this.Score = this._player.Score;
            RaisePropertyChanged(nameof(this.Score));
        }
        #endregion Methods Definition
    }
}
