using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Rpg.Core.WpfLibrary;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    protected void OnPropertyChanged(Action setValue = null, [CallerMemberName] string name = null)
    {
        setValue?.Invoke();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public virtual event PropertyChangedEventHandler PropertyChanged;
}

