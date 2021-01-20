using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.Infrastructure.Commands.Base
{
    internal class LambdaCommand : Command
    {
        //Это класс команды который непосредственно у нас будет выполняться, его обьекты станут командами в модели-представления

        //Поля с аттрибутом только для чтения(readonly) работают быстрее стандартных полей

        private readonly Action<object> _Execute;
        private readonly Func<object, bool> _CanExecute;


        //Конструктор класса команды
        //В конструкторе надо получить 2 делегата: первфй будет выполняться методом CanExecute(), второй будет выполняться методом Execute


        public LambdaCommand(Action<object> Execute, Func<object, bool> CanExecute = null)
        {
            //?? означает проверку на null. Если первая переменная = null - подставляется вторая. Пример: a = b ?? с
            //Тоесть поле _Execute принимает либо значение введенного параметра Execute либо выдает исключение
            //Функция nameof() возвращает имя элемента в строчном формате

            _Execute = Execute ?? throw new ArgumentNullException(nameof(Execute));
            _CanExecute = CanExecute;
        }

        //Возвращаем либо true(дает добро на выполнение метода Execute(тоесть самой команды), 
        //либо если поле _CanExecute не равно Null возвращаем результат выполнения делегата _CanExecute
        //поле _CanExecute преедставляет из себя некое условие, которое определяет будет ли команда выполняться

        public override bool CanExecute(object parameter) => _CanExecute?.Invoke(parameter) ?? true;

        //Реализация метода без лямбды

        //public override bool CanExecute(object parameter)
        //{
        //   return _CanExecute?.Invoke(parameter) ?? true;
        //}


        //Так как на Null параметр Execute мы проверили еще в конструкторе просто выполним метод-деелегат _Execute(parameter
        public override void Execute(object parameter) => _Execute(parameter);

        //Реализация без лямбды
       // public override void Execute(object parameter)
       // {
       //     _Execute(parameter);
       // }
    }
}
