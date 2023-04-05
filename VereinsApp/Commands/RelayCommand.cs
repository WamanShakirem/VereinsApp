using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

//Quelle https://www.c-sharpcorner.com/UploadFile/20c06b/icommand-and-relaycommand-in-wpf/
//Dieses RelayCommand kann auf den Sender zugreifen

namespace VereinsApp.Commands
{
    /// <summary>
    /// Ein Befehl mit dem einzigen Zweck, seine Funktionalität zu vermitteln 
    /// zu anderen Objekten durch Aufrufen von Delegaten. 
    /// Der Standardrückgabewert für die CanExecute-Methode ist 'true'.
    /// <see cref="RaiseCanExecuteChanged"/> muss jedes mal aufgerufen werden, wenn
    /// <see cref="CanExecute"/> muss einen anderen Wert zurückgeben.
    /// </summary>
    public class RelayCommand : System.Windows.Input.ICommand
    {
        private readonly Action<object> _execute;
        private readonly Predicate<object> _canExecute;
        private Action sendEmail;

        public RelayCommand(Action<object> execute) : this(execute, null) { }

        public RelayCommand(Action sendEmail)
        {
            this.sendEmail = sendEmail;
        }

        public RelayCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute ?? throw new ArgumentNullException(nameof(execute));
            _canExecute = canExecute;
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public bool CanExecute(object parameter)
        {
            return _canExecute == null || _canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
        }
    }
    
}
