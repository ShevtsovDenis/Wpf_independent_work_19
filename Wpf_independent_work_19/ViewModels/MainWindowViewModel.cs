using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Wpf_independent_work_19.Models;

namespace Wpf_independent_work_19.ViewModels
{
    class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;//событие для уведоиления представления о том что необходимо обновить отображение

        void OnPropertyChanged([CallerMemberName] string PropertyName = null)//реализовываем событие через метод Invoke
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        //назначаем свойства
        private double number1;
        public double Number1
        {
            get => number1;
            set
            {
                number1 = value;
                OnPropertyChanged();//в метод не прописываем аргумент, т.к. использовали атрибут CallerMemberName
            }
        }

        private double number2;
        public double Number2
        {
            get => number2;
            set
            {
                number2 = value;
                OnPropertyChanged();
            }
        }
        //создаем свойство, которое и будет командой
        public ICommand AddCommand { get; }//используется только для чтения, поэтому сеттер ен прописываем
        private void OnAddCommandExecute(object p)//создаем метод, который передадим в execute
        {
            Number2 = СircumferenceLength.GetLength(Number1);//вызываем класс из папки Models, где прописан метод, который вычисляет длину окружности
        }
        private bool CanAddCommandExecuted(object p)//создаем метод, который передадим в canExecute
        {
            return true;
        }
        //создаем конструктор для инициализации команды
        public MainWindowViewModel()
        {
            AddCommand = new RelayCommand(OnAddCommandExecute, CanAddCommandExecuted);
        }

    }
}
