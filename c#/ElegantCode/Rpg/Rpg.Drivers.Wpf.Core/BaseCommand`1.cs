using System;
using System.Windows.Input;

namespace Rpg.Drivers.Wpf.Core;

public class BaseCommand<TArgs> : ICommand
{
    public event EventHandler CanExecuteChanged;

    private Predicate<TArgs> _CanExecute;
    private Action<TArgs> _Execute;

    public BaseCommand(Predicate<TArgs> canExecute, Action<TArgs> execute)
    {
        _CanExecute = canExecute;
        _Execute = execute;
    }

    public virtual bool CanExecute(object parameter)
    {
        return _CanExecute((TArgs)parameter);
    }

    public virtual void Execute(object parameter)
    {
        _Execute((TArgs)parameter);
    }

}

