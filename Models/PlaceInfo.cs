using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CV19.Models
{
   internal class PlaceInfo
    {
        public string Name { get; set; }

        //Расположение страны
        public Point Location { get; set; }

        //Информация о количестве подтвержденных случаев

        public IEnumerable<ConfirmedCount> Counts { get; set; }


    }

    //Структура
    //Структуры синтаксически очень похожи на классы, но существует принципиальное отличие,
    //которое заключается в том, что класс – является ссылочным типом (reference type),
    //а структуры – значимый класс (value type).
    //Главное отличие структур и классов: структуры передаются по значению (то есть копируются), объекты классов - по ссылке.
    //Структуры оптимально использовать вместо маленьких классов
    //Чем больше мы будетем использовать структуры вместо небольших (наверное, правильнее будет сказать – маленьких) классов,
    //тем менее затратным по ресурсам будет использование памяти.



    internal struct ConfirmedCount
    {
        public DateTime Date { get; set; }              
        public int Count { get; set; }

    }

    internal struct DataPoint
    {
        public double XValue { get; set; }
        public double YValue { get; set; }

       
    }



    //Также в нашем приложении нам понадобиться строить графики, для этого рнам нужно добавить пакет OxyPlot.WPF
    //Так как мы используем концепцию MVVM все графики у нас просто рисуются в виде разметкеиXAML
    //И данные беруться через привязку данных из ViewModel, далее см. MainViewModel







}
