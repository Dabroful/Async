using System.IO;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Potoki.Streams
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            #region Создание потоков вручную
            // Thread thread1 = new Thread(new ThreadStart(DoWork1));                       //создаем поток для метода DoWork без параметров
            // thread1.Start();                                                             //запускаем этот поток
            //
            // Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));          //создаем поток для метода DoWork с параметрами
            // thread2.Start(int.MaxValue);
            //
            // int j = 0;                                                                   //цикл, который нагружает систему
            // for (int i = 0; i < int.MaxValue; i++)
            // {
            //     j++;
            //     if (i % 10000 == 0)
            //     {
            //         Console.WriteLine("Main");
            //     }
            // }
            #endregion

            Console.WriteLine("Begin main");
            DoWorkAsync();                                                                    //вызов асинхронного метода
            Console.WriteLine("Continue main");
            
            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("Main");
            }
            Console.WriteLine("End main");
            Console.ReadLine();
        }

        static async Task DoWorkAsync()                                                       //асинхронный метод DoWorkAsync, который будет вызыватт асинхронно DoWork1
        {
            Console.WriteLine("Begin async");
            await Task.Run(() => DoWork1());                                                  //запуск метода
            Console.WriteLine("End async");
        }
        
        static void DoWork1()
        {

            for (int i = 0; i < 10; i++)
            {
                Console.WriteLine("DoWork1");
            }
        }
        
        static void DoWork2(object max)
        {
            int j = 0;
            for (int i = 0; i < (int)max; i++)
            {
                j++;
                if (i % 10000 == 0)
                {
                    Console.WriteLine("DoWork2");
                }
            }
        }
    }
}