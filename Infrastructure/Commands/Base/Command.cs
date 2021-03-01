using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.Infrastructure.Commands.Base
{
    internal abstract class Command : ICommand
    {


        //Данное событие возникает когда команда переходит из одного состояния в другое
        //Тоесть если CanExecute возвращал true но стал возвращать false

        //Мы можем реализовать событие самостоятельно,
        //а также можем передать управление данным событием самому WPF с помощью CommandManager
        //Для этого реализуем его явно

        //Добавим элементы add и remove

        //В первом случае(add) с помощью свойства RequertSuggested добавляем обработчик события который кто-то пытался добавить
        //Во втором случае (remove) мы удаляем событие которое происходило с элементов к котрму подвязана команда

        //Таким образов данне событие с помощью стандартного класса WPF CommandManager в режиме реального времени отслеживает состояние обьекта и его готовность выполнить команду


        public event EventHandler CanExecuteChanged
        {
            add => CommandManager.RequerySuggested += value; 
            remove => CommandManager.RequerySuggested -= value; 
        }



        //Данный метод возвращает либо истину(команду можно выполнить) либо ложь(команду выполнить нельзя)
        //Если он возвращает false элемент к которому привязана команда неактивен
        public abstract bool CanExecute(object parameter);


        //Данный метод это то что делает команда
        public abstract void Execute(object parameter);
       
    }
}
