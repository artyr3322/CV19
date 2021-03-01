using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CV19.Infrastructure.Commands.Base
{
    //Реализация команды в отдельном классе(наследуем наш базовый класс Command)
    //Реализуем методы Execute и CanExecute, проверки на Null будут в свойстве в классе MainViewModel
    //В графическом редакторе привязывать будем свойство


    internal class CloseAppCommand : Command
    {
        public override bool CanExecute(object parameter) => true;
  

        public override void Execute(object parameter) => App.Current.Shutdown();
    }
}
