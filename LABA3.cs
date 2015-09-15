using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABA3
{
    class Program
    {
        static double meth_sr(int a, int b, int m)
        {
            double h = (double)(b - a) / m;
            double sumSR = 0;
            for (double i = a; i < b; i += h)
            {
                double sr = h * ((i + h) * Math.Log(i + h) - (i + h) - 5 * Math.Sin(i + h));
                sumSR += sr;
            }
            return sumSR;

        }
        static double meth_tr(int a, int b, int m)
        {
            double h = (b - a) / m;
            double sumTR = h * (Math.Log(a) - 5 * Math.Cos(a) + Math.Log(b) - 5 * Math.Cos(b)) / 3;  
            for (double i = a + h; i < b; i += h)
            {
                double tr = h * (Math.Log(i) - 5 * Math.Cos(i));
                sumTR += tr;
            }
            return sumTR;

        }

        static double meth_simp(double a, int b, int m)
        {
            double h = (b - a) / (2 * m);
            double sumSIMP = h * (Math.Log(a) - 5 * Math.Cos(a) + Math.Log(b) - 5 * Math.Cos(b)) / 3; 
            for (double i = a + h; i < b - h; i += (b - a) / m)
                sumSIMP = sumSIMP + h * (4 * (Math.Log(i) - 5 * Math.Cos(i)) + 2 * (Math.Log(i+h) - 5 * Math.Cos(i+h)))/3;
            return sumSIMP;

        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите нижнюю границу интервала a      (Подсказка а=1)");
            int a = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите верхнюю границу интервала b      (Подсказка b=8)");
            int b = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите первоначальное число площадок m:      (Подсказка m=100) ");
            int m = int.Parse(Console.ReadLine());
            Console.WriteLine("Введите желаемую точность:      (Подсказка 0,0001) ");
            double delta = double.Parse(Console.ReadLine());
            double S1 = meth_sr(a, b, m);

            int m1 = m * 2;
            double S2 = meth_sr(a, b, m1);
            while (Math.Abs(S1 - S2) >= delta)
            {
                S1 = S2;
                S2 = meth_sr(a, b, m1 * 2);
                m1 = m1 * 2;
            }
            Console.WriteLine("***S2={0};m={1};d={2}***", S2, m1, delta);
            Console.WriteLine("S={0}", meth_simp(a, b, 10000));

            Console.ReadLine();
        }
    }
}
