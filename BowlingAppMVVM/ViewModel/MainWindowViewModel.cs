using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingAppMVVM.Model;
using System.Collections.Specialized;

namespace BowlingAppMVVM.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Members definition
        public ObservableCollection<BowlerFramesViewModel> Players { get; private set; }

        private readonly Game _game;
        #endregion Members definition

        #region Constructors definition
        /// <summary>
        /// Represents the ViewModel for the MainWindow.xaml View.
        /// </summary>
        public MainWindowViewModel()
        {
            this._game = new Game();
            this._game.Players.CollectionChanged += new NotifyCollectionChangedEventHandler(UpdatePlayers);
            this._game.StartGame();
        }
        #endregion Constructors definition

        #region Methods definition
        private void UpdatePlayers(object sender, NotifyCollectionChangedEventArgs args)
        {
            this.Players = new ObservableCollection<BowlerFramesViewModel>(this._game.Players.Select((player) => new BowlerFramesViewModel(player)).ToList());
            RaisePropertyChanged(nameof(Players));
        }
        #endregion Methods Definition
    }
}
