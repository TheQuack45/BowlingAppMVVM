using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace BowlingAppMVVM.Model
{
    public abstract class FrameBase : INotifyPropertyChanged
    {
        #region Properties declaration
        public abstract Game.SHOT_VALUE this[int index] { get; set; }
        public abstract (int, Game.SCORE_STATE) Score { get; }
        public abstract Game.SHOT_VALUE[] Shots { get; }
        #endregion Properties declaration

        #region INotifyPropertyChanged members
        public event PropertyChangedEventHandler PropertyChanged;
        #endregion INotifyPropertyChanged members

        #region Methods definition
        protected bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (Equals(storage, value))
            {
                return false;
            }

            storage = value;
            this.RaisePropertyChanged(propertyName);
            return true;
        }

        protected void RaisePropertyChanged([CallerMemberName] string propertyName = null)
        {
            this.PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        #endregion Methods definition
    }
}
