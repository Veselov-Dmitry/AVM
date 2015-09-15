using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABA2
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Введите начальную точку интервала a:      (Подсказка а=1)");
            double a = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите конечную точку интервала b:      (Подсказка b=8)");
            double b = double.Parse(Console.ReadLine());
            Console.WriteLine("Введите количество узлов m:      (Подсказка m=5)");
            int m = int.Parse(Console.ReadLine());
            for (double j = 1; j <= 20; j++)
            {
                double x1 = a + (j - 1) * (b - a) / (20 - 1);
                double y1 = Math.Log(x1) - 5 * Math.Cos(x1);
                double[] mas = new double[5];
                for (int i = 1; i <= 5; i++)
                {
                    mas[i - 1] = a + (double)(i - 1) * (b - a) / 4;
                }
                double[] mas1 = new double[5];
                for (int i = 0; i < 5; i++)
                {
                    mas1[i] = Math.Log(mas[i]) - 5 * Math.Cos(mas[i]);
                }
                double l0 = ((x1 - mas[1]) * (x1 - mas[2]) * (x1 - mas[3]) * (x1 - mas[4])) / ((mas[0] - mas[1]) * (mas[0] - mas[2]) * (mas[0] - mas[3]) * (mas[0] - mas[4]));
                double l1 = ((x1 - mas[0]) * (x1 - mas[2]) * (x1 - mas[3]) * (x1 - mas[4])) / ((mas[1] - mas[0]) * (mas[1] - mas[2]) * (mas[1] - mas[3]) * (mas[1] - mas[4]));
                double l2 = ((x1 - mas[1]) * (x1 - mas[0]) * (x1 - mas[3]) * (x1 - mas[4])) / ((mas[2] - mas[1]) * (mas[2] - mas[0]) * (mas[2] - mas[3]) * (mas[2] - mas[4]));
                double l3 = ((x1 - mas[1]) * (x1 - mas[2]) * (x1 - mas[0]) * (x1 - mas[4])) / ((mas[3] - mas[1]) * (mas[3] - mas[2]) * (mas[3] - mas[0]) * (mas[3] - mas[4]));
                double l4 = ((x1 - mas[1]) * (x1 - mas[2]) * (x1 - mas[3]) * (x1 - mas[0])) / ((mas[4] - mas[1]) * (mas[4] - mas[2]) * (mas[4] - mas[3]) * (mas[4] - mas[0]));
                double L = l0 * mas1[0] + l1 * mas1[1] + l2 * mas1[2] + l3 * mas1[3] + l4 * mas1[4];
                double delta = L - y1;
                Console.WriteLine("\n{0}  |  {1}  |  {2}  |   {3}", x1, y1, L, delta);
            }
            Console.ReadLine();
        }
    }
}
