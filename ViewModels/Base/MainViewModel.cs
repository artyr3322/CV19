using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CV19.Infrastructure.Commands.Base;
using CV19.Models;

namespace CV19.ViewModels.Base
{

    //Сам класс модели представления: ViewModel

    internal class MainViewModel : ViewModel
    {


        //Также в нашем приложении нам понадобиться строить графики, для этого рнам нужно добавить пакет OxyPlot.WPF
        //Так как мы используем концепцию MVVM все графики у нас просто рисуются в виде разметкеиXAML

        //Нам нужно свойство которое возвращает перечисление точек данных которые нам нужны чтобы построить графики
        //Далее выбираем тип перечисления которое нам необходимо для дальнейшей работы:
        // - Если нам не нужно будет в дальнейшем добавлять и удалять обьекты перечисления(точки) 
        //то выбитаем тип IEnumerable<T>
        // - Если нам нужна изменяемая коллекция используем ObservableCollection<T>

        /// <summary>
        /// Тесторый набор данных для визуализации графиков
        /// </summary>

        private IEnumerable<DataPoint> _TestDataPoints;

        public IEnumerable<DataPoint> TestDataPoints { get => _TestDataPoints; set => Set(ref _TestDataPoints, value); }

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

        private void OnExitCommandExecute(object obj) => App.Current.Shutdown();
    

        #endregion

        //public ICommand _CloseAppCommand;
       // public ICommand CloseApp
        //{
           // get
           // {
             //   if (_CloseAppCommand == null)
              //  {
               //     _CloseAppCommand = new CloseAppCommand();
               // }
               // return _CloseAppCommand;
           // }
       // }



        public MainViewModel()
        {

            #region КОМАНДЫ

            ExitCommand = new LambdaCommand(OnExitCommandExecute, CanExitCommandExecute);



            #endregion

            #region ГРАФИК

            //Создавая список List мы можем в скобках указать количество его элементов
            //Конструктор списка принимает только целочисленные значения типа int,
            //А так как у нас операция деления мы укажем что резудьтат должен быть приведен к типу int
            //Количество элементов в нашем списке совпадает с количеством итераций цикла for

            List<DataPoint> data_points = new List<DataPoint>((int)(360/0.1));

            //Для построения графика используем математические операции
            //Все математические операции представлены статическим классом Math
            //
            //Чтобы понять что такоет синус и косинус угла нужно представить его в виде треугольника
            //Синус угла - соотношение катета(который находится напротив самого угла, в противоположном конце треугольника)
            //к гипотенузе
            //Косинус - это соотношение катета который лежит возле самого угла к гипотенузе
            //
            //Math.PI - число ПИ, оно равно 3.1415926535897931

            for (var x = 0d; x <= 360; x += 0.1)
            {
                const double to_rad = Math.PI / 180;
                double y = Math.Sin(x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            }

            TestDataPoints = data_points;


            #endregion
        }




    }
}
