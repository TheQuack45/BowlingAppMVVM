using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.ViewModel
{
    class MainWindowViewModel : ViewModelBase
    {
        #region Members definition
        public ObservableCollection<BowlerFramesViewModel> Players { get; private set; }
        #endregion Members definition

        #region Constructors definition
        /// <summary>
        /// Represents the ViewModel for the MainWindow.xaml View.
        /// </summary>
        public MainWindowViewModel()
        {
            Players = new ObservableCollection<BowlerFramesViewModel>();
            Players.Add(new BowlerFramesViewModel());
            Players.Add(new BowlerFramesViewModel());
            Players.Add(new BowlerFramesViewModel());
            Players.Add(new BowlerFramesViewModel());
        }
        #endregion Constructors definition

        #region Methods definition

        #endregion Methods Definition
    }
}
