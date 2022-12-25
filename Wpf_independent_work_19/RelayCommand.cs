using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Wpf_independent_work_19
{
    class RelayCommand : ICommand//создаем класс-обертку для команд и реализуем интерфейс ICommand
    {
        //создаем поля для конструктора
        private readonly Action<object> execute;
        private readonly Func<object, bool> canExecute;

        public event EventHandler CanExecuteChanged//раскрывая событие передаем управление CommandManager
        {
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;

        }

        public RelayCommand(Action<object> Execute, Func<object, bool> CanExecute = null)//создаем конструктор, чтобы класс был универсален для всех команд
        {
            execute = Execute ?? throw new ArgumentNullException(nameof(Execute));//проверяем на null
            canExecute = CanExecute;
        }

        public bool CanExecute(object parameter) => canExecute?.Invoke(parameter) ?? true;//в методе вызываем соответствующее поле и проверяем на null 

        public void Execute(object parameter) => execute(parameter);//в методе вызываем соответствующее поле

    }
}
