using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public class Game : INotifyPropertyChanged
    {
        #region Static members definition
        public enum SHOT_VALUE { Zero, One, Two, Three, Four, Five, Six, Seven, Eight, Nine, Spare, Strike, Undefined };
        public enum SCORE_STATE { Standard, Spare, Strike };

        public static readonly Dictionary<SHOT_VALUE, int> ShotScores = new Dictionary<SHOT_VALUE, int>()
        {
            { SHOT_VALUE.Zero, 0 },
            { SHOT_VALUE.One, 1 },
            { SHOT_VALUE.Two, 2 },
            { SHOT_VALUE.Three, 3 },
            { SHOT_VALUE.Four, 4 },
            { SHOT_VALUE.Five, 5 },
            { SHOT_VALUE.Six, 6 },
            { SHOT_VALUE.Seven, 7 },
            { SHOT_VALUE.Eight, 8 },
            { SHOT_VALUE.Nine, 9 },
            { SHOT_VALUE.Undefined, 0 },
        };
        #endregion Static members definition

        #region Members definition
        private ObservableCollection<Player> _players;

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged members
        #endregion Members definition

        #region Properties definition
        public ObservableCollection<Player> Players
        {
            get
            {
                return this._players;
            }
            private set
            {
                this.SetProperty<ObservableCollection<Player>>(ref this._players, value);
            }
        }
        #endregion Properties definition

        #region Constructors definition
        public Game(int playerCount = 4)
        {
            var players = new ObservableCollection<Player>()
            {
                new Player(),
                new Player(),
                new Player(),
                new Player(),
            };
            this.Players = players;
        }
        #endregion Constructors definition

        #region Methods definition
        private bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        private void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Methods definition
    }
}
