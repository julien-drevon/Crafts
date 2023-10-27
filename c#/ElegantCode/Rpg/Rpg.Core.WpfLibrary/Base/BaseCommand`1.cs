using System;
using System.Windows.Input;

namespace Rpg.Core.WpfLibrary.Base;
public class BaseCommand<TArgs> : ICommand
{
    private Predicate<TArgs> _ExecutePredicate;

    public BaseCommand(Predicate<TArgs> canExecute, Action<TArgs> execute)
    {
        this._ExecutePredicate = canExecute;
        ExecuteAction = execute;
    }

    public event EventHandler CanExecuteChanged
    {
        add { CommandManager.RequerySuggested += value; }
        remove { CommandManager.RequerySuggested -= value; }
    }

    public virtual Action<TArgs> ExecuteAction { get; set; }

    public virtual Predicate<TArgs> ExecutePredicate
    {
        get => _ExecutePredicate;

        set
        {
            if (_ExecutePredicate != value)
            {
                _ExecutePredicate = value;
            }
        }
    }

    public virtual bool CanExecute(TArgs parameter)
    {
        return ((ICommand)this).CanExecute(parameter);
    }

    bool ICommand.CanExecute(object parameter)
    {
        return ExecutePredicate?.Invoke((TArgs)parameter) ?? false;
    }

    public virtual void Execute(TArgs parameter)
    {
        ((ICommand)this).Execute(parameter);
    }

    void ICommand.Execute(object parameter)
    {
        ExecuteAction?.Invoke((TArgs)parameter);
    }
}