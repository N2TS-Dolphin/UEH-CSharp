using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Linq;
using System.Collections.Specialized;

namespace Project01
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Nhap so N: ");
            int N = int.Parse(Console.ReadLine());
            float S1, S2, S3, S4, S5, S6;
            S1 = S2 = S3 = S5 = S6 = 0;
            S4 = 1;

            for (int i = 1; i <= N; i++)
            {
                int temp = 1;

                S1 += i;
                S2 += 1 / (float)i;
                S3 += i * 10 + i;
                S4 *= i;

                for (int j = 1; j <= i; j++)
                    temp *= j;

                S5 += 1 / (float)temp;
                S6 += 1 / (float)(N * (N + 1));
            }

            Console.Write("S1 = ");
            Console.WriteLine(S1);

            Console.Write("S2 = ");
            Console.WriteLine(S2);

            Console.Write("S3 = ");
            Console.WriteLine(S3);

            Console.Write("S4 = ");
            Console.WriteLine(S4);

            Console.Write("S5 = ");
            Console.WriteLine(S5);

            Console.Write("S6 = ");
            Console.WriteLine(S6);

            Console.ReadKey();
        }
    }
}