using System;
using System.Windows.Input;

namespace Rpg.Drivers.Wpf.Core;

public class BaseCommand<TArgs> : ICommand
{
    private Predicate<TArgs> _CanExecute;
    private Action<TArgs> _Execute;

    public BaseCommand(Predicate<TArgs> canExecute, Action<TArgs> execute)
    {
        _CanExecute = canExecute;
        _Execute = execute;
    }

    public event EventHandler CanExecuteChanged;

    public virtual bool CanExecute(TArgs parameter)
    {
        return ((ICommand)this).CanExecute(parameter);
    }

    bool ICommand.CanExecute(object parameter)
    {
        return _CanExecute?.Invoke((TArgs)parameter) ?? false;
    }

    public virtual void Execute(TArgs parameter)
    {
        ((ICommand)this).Execute(parameter);
    }

    void ICommand.Execute(object parameter)
    {
        _Execute?.Invoke((TArgs)parameter);
    }
}