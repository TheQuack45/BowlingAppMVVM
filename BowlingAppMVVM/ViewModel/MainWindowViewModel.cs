using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BowlingAppMVVM.Model;

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
            // TODO: Should the ViewModel know about the concept of a Player? Moreover, should it have a list of them?
            Players = new ObservableCollection<BowlerFramesViewModel>();
            Players.Add(new BowlerFramesViewModel());
            Players.Add(new BowlerFramesViewModel());
            Players.Add(new BowlerFramesViewModel());
            Players.Add(new BowlerFramesViewModel());
            this._game = new Game(Players.Count);
            // TODO: Wire up ViewModel to Model.
        }
        #endregion Constructors definition

        #region Methods definition

        #endregion Methods Definition
    }
}
