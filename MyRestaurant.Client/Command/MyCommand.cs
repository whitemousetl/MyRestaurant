using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MyRestaurant.Client.Command;
public class MyCommand : ICommand
{
    //public event EventHandler? CanExecuteChanged;

    public event EventHandler? CanExecuteChanged { add { } remove { } }

    private readonly Action _action;

    public MyCommand(Action action)
    {
        _action = action;
    }

    public bool CanExecute(object? parameter)
    {
        return true;
    }

    public void Execute(object? parameter)
    {
        _action();
    }
}
