using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewModels.Base
{

    //Сам класс модели представления: ViewModel

    internal class MainViewModel : ViewModel
    {
        #region Заголовок окна

        private string _Title;

        public string Title
        {
            //можно записать блок get так
            //get { return _Title}

            get => _Title;
            set => Set(ref _Title, value);
            //{

            //Используем метод Equals(): Если новое значение свойства совпадает со значением поля yичего не выполнять
            //Это нуно чтобы не нагружать систему ненужными действиями
            // if (Equals(_Title, value)) return;
            //_Title = value;
            //OnPropertyChanged();

            //Так как у нас в базовом классе есть метод Set
            //мы можем записать данный блок так:
            //Set(ref _Title, value);

            //Или как вверху, еще проще, все операции выполнит метод Set: сравнит значение поля с новым значением свойства, если они не совпадают перезапишет поле
            //и применит метод OnPropertyChanged
            //}


        }

        #endregion

        public MainViewModel()
        {
            string title = "Аналіз статистики CV19";
            _Title = title;
        }



    }
}
