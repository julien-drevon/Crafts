using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Rpg.Core.WpfLibrary.Base;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    public virtual event PropertyChangedEventHandler PropertyChanged;

    protected void OnPropertyChanged(Action setValue = null, [CallerMemberName] string name = null)
    {
        setValue?.Invoke();
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }
}