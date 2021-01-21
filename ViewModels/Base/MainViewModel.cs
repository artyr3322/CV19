using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CV19.Infrastructure.Commands.Base;

namespace CV19.ViewModels.Base
{

    //Сам класс модели представления: ViewModel

    internal class MainViewModel : ViewModel
    {
        #region Заголовок окна

        //Комментарии над свойствами пишем обязательно именно в таком виде, так как они будут отображаться у нас как подсказки в разметке
        //(при наведении на название свойства в биндингах)

        /// <summary>
        /// заголовок окна
        /// </summary>

        private string _Title = "Статистика Covid 19";

        public string Title
        {
            //можно записать блок get так
            //get { return _Title}

            //Используем метод Equals(): Если новое значение свойства совпадает со значением поля yичего не выполнять
            //Это нуно чтобы не нагружать систему ненужными действиями
            // {if (Equals(_Title, value)) return;
            //_Title = value;
            //OnPropertyChanged();}

            //Так как у нас в базовом классе есть метод Set
            //мы можем записать данный блок так:
            //{Set(ref _Title, value);}

            //Или как вверху, еще проще, все операции выполнит метод Set: сравнит значение поля с новым значением свойства, если они не совпадают перезапишет поле
            //и применит метод OnPropertyChanged



            get => _Title;
            set => Set(ref _Title, value);
            

        }

        #endregion

        /// <summary>
        /// статус программы
        /// </summary>

        private string _Status = "Готов!";
        public string Status
        { get => _Status; set => Set(ref _Status, value); }

        #region ExitCommand

        public ICommand ExitCommand { get; }

        private bool CanExitCommandExecute(object obj) => true;

        private void OnExitCommandExecute(object obj)
        {
            App.Current.Shutdown();
        }

        #endregion






        public MainViewModel()
        {

            #region КОМАНДЫ

            ExitCommand = new LambdaCommand(OnExitCommandExecute, CanExitCommandExecute);

            #endregion
        }




    }
}
