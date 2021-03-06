﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CV19.ViewModels.Base
{

    //internal: класс и члены класса с подобным модификатором доступны из любого места кода в той же сборке,
    //однако он недоступен для других программ и сборок (как в случае с модификатором public).


    //Базовый класс модели представления, от которого будет наследоваться непосредственно класс модели представления


    internal abstract class ViewModel : INotifyPropertyChanged, IDisposable
    {




        public event PropertyChangedEventHandler PropertyChanged;

    


        //За счет CallerMemberName когда в свойствах полей будем реализовывать интерфейс можно будет вызывать метод OnPropertyChanged
        //без указания названия свойства, оно подтянется автоматически

        protected virtual void OnPropertyChanged([CallerMemberName]string PropertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(PropertyName));
        }

        //Данный метод будет обновлять свойства для которого определено поле где оно хранит свои данные
        // ref T field - сюда передаем ссылку на поле свойства
        // - T value - сюда передаем новое значение для этого свойства
        // - [CallerMemberName] string PeopsetName - тут будет имя свойства которое мы передадим в метод OnPropertyChanged


        protected virtual bool Set<T>(ref T field, T value, [CallerMemberName] string PeopsetName = null)
        {
            //Метод Equals проверяет равны ли значения обьектов указанных в его параметрах

            //Данный метод сравнивает значение установленное в поле с новым значением и определяет нужно или нет его менять
            //он предназначен для очищения системы от ненужных действий(обновления на одно и то же)
            //Если оба значения равны он блокирет замену(чтобы система не выполняла ненужные действия)


            if (Equals(field, value)) return false;

            //В случае если значение в поле и новое значение в свойстве не равны с помощью метода OnPropertyChanged меняем значение в поле
            //и разрешаем изменения(возвращаем true)

            field = value;
            OnPropertyChanged(PeopsetName);
            return true;

        }


        //Реализуем интерфейс IDisposable


       

        public void Dispose() 
        {
            Dispose(true);
        }

        private bool _Disposed;


        //Освобождение управляемых ресурсов

        //Данный метод виртуальный
        //По умолчанию он выполняется в таком виде
        //При желании мы можем егопереопределить
       protected virtual void Dispose(bool Disposing)
        {
            //В скобках лочическая операия которая возвращает true в случае если: хотя бы одно из указанных условий верно: переменная Disposing равна true(по умолчанию все переменные типа bool 
            //равны false, поэтому !Disposing это true) или переменная Disposed равна false
            //В данном случае мы ничего не выполняем return;
            //В противнм случае устанавливаем переменной _Disposed  значение true

            if (!Disposing || _Disposed) return;
            _Disposed = true;


        }

     




    }
}
