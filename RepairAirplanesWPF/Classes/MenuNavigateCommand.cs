using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace RepairAirplanesWPF.Classes
{
    public class MenuNavigateCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        private Action<object> Action;
        public MenuNavigateCommand(Action<object> action)
        {
            this.Action = action;
        }
        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {

            this.Action?.Invoke(parameter);
        }
    }
}
