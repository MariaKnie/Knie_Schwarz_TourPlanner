using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Knie_Schwarz_TourPlanner_project.ViewModels
{
    public class RelayCommand : ICommand
    {
        readonly Action<object?> _execute;
        readonly Predicate<object?>? _canExecute;

        public RelayCommand(Action<object?> execute)
        {
            _execute = execute;
        }

        public RelayCommand(Action<object?> execute, Predicate<object?>? canExecute = null)
        {
            _execute = execute;
            _canExecute = canExecute;
        }
        public event EventHandler? CanExecuteChange;    //for raise execute

        public event EventHandler? CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
        }

        public bool CanExecute(object? parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object? parameter)
        {
            _execute(parameter);
        }

        internal void RaiseCanExecuteChanged()
        {
            if (_canExecute != null)
                CanExecuteChange?.Invoke(this, EventArgs.Empty);
        }
    }
}
