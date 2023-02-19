using System.IO;
using System;
using System.Runtime.InteropServices;
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

            #region Асинхронность
            // Console.WriteLine("Begin main");
            // DoWorkAsync(1000);                                                                    //вызов асинхронного метода
            // Console.WriteLine("Continue main");
            //
            // for (int i = 0; i < 10; i++)
            // {
            //     Console.WriteLine("Main");
            // }
            // Console.WriteLine("End main");
            #endregion

            var result = SafeFileAsync("D:\\text.txt");                              //засовываем вызов асинхронного метода в переменную
            var input = Console.ReadLine();                                                  //делаем доступным ввод в консоли
            Console.WriteLine(result.Result);
            Console.ReadLine();
        }

        static async Task<bool> SafeFileAsync(string path)                                        //делаем асинхронную обертку для метода SafeFile
        {
            var result = await Task<bool>.Run(() => SaveFile(path));
            return result;
        }
        
        static bool SaveFile(string path)                                                        //сформировали огромную строку и хотим сохранить в её в файл
        {
            var rnd = new Random();
            var text = "";
            for (int i = 0; i < 50000; i++)
            {
                text += rnd.Next();
            }

            using (var sw = new StreamWriter(path, false, Encoding.UTF8))
            {
                sw.WriteLine();
            }

            return true;
        }

        static async Task DoWorkAsync(int max)                                                    //асинхронный метод DoWorkAsync, который будет вызыватт асинхронно DoWork1
        {
            Console.WriteLine("Begin async");
            await Task.Run(() => DoWork1(max));                                                  //запуск метода
            Console.WriteLine("End async");
        }
        
        static void DoWork1(int max)
        {

            for (int i = 0; i < max; i++)
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