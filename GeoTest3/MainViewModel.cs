using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoTest3
{
    internal class MainViewModel
    {
        static Dictionary<string, DateTime> countries = new Dictionary<string, DateTime>()
        {
             {"Чупашева А.И", DateTime.Parse("01.10.2015")},
             {"Иванов А.В", DateTime.Parse("10.01.2017")},
             {"Кривцов О.П", DateTime.Parse("05.02.2019")},
             {"Янаева Э.С", DateTime.Parse("15.12.2014")},
        };
    }
}
