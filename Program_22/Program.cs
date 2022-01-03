using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Program_22
{
    internal class Program
    {
        public static int[] array;

        public static void SumArray()
        {
            int sum = array.Sum();
            Console.WriteLine($"\n\nСумма чисел массива:\t{sum}\n");
        }
        public static void MaxArray(Task task)
        {
            int maxValue = array.Max();
            Console.WriteLine($"Максимальное число в массиве:\t{maxValue}");
        }

        static void Main(string[] args)
        {
            Console.Title = "ЗАДАНИЕ 22. ПАРАЛЛЕЛЬНОЕ ПРОГРАММИРОВАНИЕ И БИБЛИОТЕКА TPL";
            Console.Write("Введите количество элементов массива:\t");
            int MasCount = int.Parse(Console.ReadLine());
            array = new int[MasCount];
            Random rand = new Random();
            Console.WriteLine("\nМассив:");
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = rand.Next(100);
                Console.Write(array[i] + "  ");
                Thread.Sleep(200);
            }

            Task task = new Task(() => SumArray());
            Action<Task> action = new Action<Task>(MaxArray);
            Task task2 = task.ContinueWith(action);
            task.Start();

            Console.ReadLine();
        }
    }
}

//1.Сформировать массив случайных целых чисел (размер  задается пользователем).
//    Вычислить сумму чисел массива и максимальное число в массиве.
//    Реализовать  решение  задачи  с  использованием  механизма  задач продолжения.
