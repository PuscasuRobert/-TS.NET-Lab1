using System;
using System.Threading;
using System.Diagnostics;

namespace Lab1
{
    class Program
    {
        static int n=123;
        static void Main(string[] args)
        {
            n = Convert.ToInt32(Console.ReadLine());

            Thread t1 = new Thread(new ThreadStart(findPrime1));
            t1.Start();

            Thread t2 = new Thread(new ThreadStart(findPrime2));
            t2.Start();

            t1.Join();
            t2.Join();
        }

        static void findPrime1()
        {
            Console.WriteLine("Start fir: " + 1 + ", " + "n= " + n + ", " + DateTime.Now.ToString("hh:mm:s:ms"));

            int i, j;
            int[] prime = new int[n + 1];

            for (i = 0; i <= n; i++)
            {
                prime[i] = 1;
            }

            for (i = 2; i * i <= n; i++)
                if (prime[i] == 1)
                    for (j = i; j <= n / i; j++)
                        prime[i * j] = 0;

            for (i = n - 1; i >= 2; i--)
                if (prime[i] == 1)
                {
                    Console.WriteLine("End fir: " + 1 + ", " + "nr= " + i + ", " + DateTime.Now.ToString("hh:mm:s:ms"));
                    return;
                }

            Console.WriteLine("End fir: " + 1 + ", " + "n= " + i + ", " + DateTime.Now.ToString("hh:mm:s:ms"));
            return;
        }

        static void findPrime2()
        {
            Console.WriteLine("Start fir: " + 2 + ", " + "n= " + n + ", " + DateTime.Now.ToString("hh:mm:s:ms"));

            int i, j;
            int rez = 0;
            for (i = 2; i <= n - 1; i++)
            {
                bool ok = true;
                for (j = 2; j <= i / 2; j++)
                    if (i % j == 0)
                    {
                        ok = false;
                        break;
                    }

                if(ok == true)
                {
                    rez = i;
                }
            }

            Console.WriteLine("End fir: " + 2 + ", " + "n= " + rez + ", " + DateTime.Now.ToString("hh:mm:s:ms"));
            return;
        }
    }
}
