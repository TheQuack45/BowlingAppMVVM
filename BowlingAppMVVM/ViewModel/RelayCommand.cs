using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingAppMVVM.ViewModel
{
    public class RelayCommand<T> : ICommand
    {
        #region Members definition
        private readonly Predicate<T> _canExecute;
        private readonly Action<T> _execute;

        public event EventHandler CanExecuteChanged;
        #endregion Members definition

        #region Constructors definition
        public RelayCommand(Action<T> execute)
            : this(execute, null)
        {

        }

        public RelayCommand(Action<T> execute, Predicate<T> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        #endregion Constructors definition

        #region Methods definition
        public bool CanExecute(T parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public bool CanExecute(object parameter)
        {
            if (parameter == null)
            {
                return true;
            }

            return _canExecute((T)parameter);
        }

        public void Execute(T parameter)
        {
            _execute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute((T)parameter);
        }
        #endregion Methods definition
    }
}
