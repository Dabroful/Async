using System.IO;
using System;
using System.Text;
using System.Threading;

namespace Potoki.Streams
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            Thread thread1 = new Thread(new ThreadStart(DoWork1));                       //создаем поток для метода DoWork без параметров
            thread1.Start();                                                             //запускаем этот поток
            
            Thread thread2 = new Thread(new ParameterizedThreadStart(DoWork2));          //создаем поток для метода DoWork с параметрами
            thread2.Start(int.MaxValue);
            
            int j = 0;                                                                   //цикл, который нагружает систему
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (i % 10000 == 0)
                {
                    Console.WriteLine("Main");
                }
            }
        }

        static void DoWork1()
        {
            int j = 0;
            for (int i = 0; i < int.MaxValue; i++)
            {
                j++;
                if (i % 10000 == 0)
                {
                    Console.WriteLine("DoWork1");
                }
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