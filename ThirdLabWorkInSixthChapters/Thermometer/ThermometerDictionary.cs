﻿/*
Упражнение 6.3 Написать программу, вычисляющую среднюю 
температуру за год. Создать двумерный рандомный массив temperature[12,30], в
котором будет храниться температура для каждого дня месяца (предполагается,
что в каждом месяце 30 дней). Сгенерировать значения температур случайным 
образом. Для каждого месяца распечатать среднюю температуру. Для этого 
написать метод, который по массиву temperature [12,30] для каждого месяца 
вычисляет среднюю температуру в нем, и в качестве результата возвращает 
массив средних температур. Полученный массив средних температур 
отсортировать по возрастанию.


Домашнее задание 6.3 Написать программу для упражнения 6.3,
использовав класс Dictionary<TKey, TValue>. В качестве ключей выбрать 
строки – названия месяцев, а в качестве значений – массив значений 
температур по дням*/

namespace ThirdLabWorkInSixthChapters.Thermometer
{
    public class ThermometerDictionary : Thermometer
    {
        private readonly Dictionary<string, int[]> _temperature;
        private static readonly string[] _month = { "Январь", "Февраль", "Март", "Апрель", "Май", "Июнь", "Июль", "Август", "Сентябрь", "Октябрь", "Ноябрь", "Декабрь" };

        public ThermometerDictionary(int[,] array) : base(array)
        {
            _temperature = TeperatureDictionary(array);
        }

        public ThermometerDictionary(int minTemperature, int maxTemperature) : this(CreateRandom(minTemperature, maxTemperature))
        {
        }

        public ThermometerDictionary() : this(-25, 35)
        {
        }

        private static Dictionary<string, int[]> TeperatureDictionary(int[,] array)
        {
            var temperature = new Dictionary<string, int[]>();
            int[] dayTemperature = new int[30];
            for (var i = 0; i < _month.Length; i++)
            {
                for (var j = 0; j < dayTemperature.Length; j++)
                {
                    dayTemperature[j] = array[i, j];
                }
                temperature.Add(_month[i], dayTemperature);
                dayTemperature = new int[dayTemperature.Length];
            }
            return temperature;
        }

        public int[] MonthlyAverage()
        {
            var monthTemperature = new int[12];
            for (var i = 0; i < monthTemperature.Length; i++)
            {
                monthTemperature[i] = (int)_temperature.ElementAt(i).Value.Average();
            }
            return monthTemperature;
        }

        public int YearAverage() => (int)_temperature.Values.Average(x => x.Average());

        public void PrintTemperatures()
        {
            foreach (var month in _temperature.Keys)
            {
                Console.WriteLine($"{month} : {String.Join(";", _temperature[month])}");
            }
        }

        public static void Run()
        {
            var thermometer = new ThermometerDictionary();
            thermometer.PrintTemperatures();
            Console.WriteLine($"Средняя температура за год: {thermometer.YearAverage()}");
            Console.WriteLine();
            var mothValue = thermometer.MonthlyAverage();
            PrintAverageMonth(mothValue);
            Console.WriteLine();

        }
    }
}
