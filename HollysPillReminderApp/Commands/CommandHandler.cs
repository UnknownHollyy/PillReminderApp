using System.Windows.Input;

namespace HollysPillReminderApp.Commands
{
    public class CommandHandler : ICommand
    {

        private Action action;
        private Func<bool> canExecute;

        public event EventHandler CanExecuteChanged;

        public CommandHandler(Action action, Func<bool> canExecute)
        {
            this.action = action;
            this.canExecute = canExecute;
        }

        public bool CanExecute(object parameter)
        {
            return (bool)(canExecute?.Invoke());
        }

        public void Execute(object parameter)
        {
            action();
        }
    }
}
