using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BowlingAppMVVM.ViewModel
{
    public class NoParamRelayCommand : ICommand
    {
        private readonly Predicate<object> _canExecute;
        private readonly Action _execute;

        public event EventHandler CanExecuteChanged;

        public NoParamRelayCommand(Action execute)
            : this(execute, null)
        {

        }

        public NoParamRelayCommand(Action execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            if (_canExecute == null)
            {
                return true;
            }

            return _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute();
        }

        public void Execute()
        {
            _execute();
        }

        public void RaiseCanExecuteChanged()
        {
            if (CanExecuteChanged != null)
            {
                CanExecuteChanged(this, EventArgs.Empty);
            }
        }
    }
}
