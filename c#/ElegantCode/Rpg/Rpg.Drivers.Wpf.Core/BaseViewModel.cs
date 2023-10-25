using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows.Input;

namespace Rpg.Drivers.Wpf.Core;

public abstract class BaseViewModel : INotifyPropertyChanged
{
    protected void OnPropertyChanged([CallerMemberName] string name = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }

    public virtual event PropertyChangedEventHandler PropertyChanged;
}

