using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LABA4
{
    class Program
    {
        static int sort_hoar(int[] mas, int left, int right, int b)//Метод Хоара
        {
            int i = left;
            int j = right;
            int t = mas[(left + right) / 2];
            do
            {
                while (mas[i] < t)
                {
                    i++;
                }
                while (mas[j] > t)
                {
                    j--;
                }
                if (i <= j)
                {
                    int w = mas[i];
                    mas[i] = mas[j];
                    mas[j] = w;
                    i++;
                    j--;
                    b++;
                }
            } while (i <= j);
            if (i < right) sort_hoar(mas, i, right, b);
            if (j > left) sort_hoar(mas, left, j, b);
            return b;
        }
        static int[] sort_lin(int[] mas, int N)//Линейный выбор с обменом (сортировка выбором). 
        {
            int b = 0;
            for (int i = 0; i <= N - 1; i++)
            {
                int k = i;
                int max = mas[i];
                for (int j = i + 1; j <= N - 1; j++)
                {
                    if (mas[j] > max)
                    {
                        max = mas[j];
                        k = j;
                        b++;
                    }
                }
                mas[k] = mas[i];
                mas[i] = max;
            }
            Console.WriteLine("Число перестановок равно {0}", b);
            return mas;
        }
        static void bin_search(int[] mas, int N)//функция бинарного поиска  
        {
            Console.WriteLine("Введите значение элемента Х для поиска: ");
            int X = int.Parse(Console.ReadLine());
            bool Flag = false;
            int L = 0;
            int R = N - 1;
            int m = 0;
            while ((L <= R) && (Flag == false))
            {
                m = (R + L) / 2;
                if (mas[m] == X)
                    Flag = true;
                else
                {
                    if (mas[m] > X)
                        L = m + 1;
                    else
                        R = m - 1;
                }
            }
            if (Flag == true)
                Console.WriteLine("Элемент Х найден, его номер равен {0}", m + 1);
            else
                Console.WriteLine("Элемент Х не найден");
        }
        static int[] Input(int N)
        {
            int[] a = new int[N];
            var r = new Random();
            for (int i = 0; i <= N - 1; i++)
            {
                a[i] = r.Next(0, 99);
            }
            return a;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Введите размерность массива N");
            int N = int.Parse(Console.ReadLine());
            int[] mas = Input(N);
            for (int i = 0; i <= N - 1; i++)
            {
                Console.Write(mas[i]);
                Console.Write("  ");
            }
            Console.WriteLine();
            sort_lin(mas, N);
            for (int i = 0; i <= N - 1; i++)
            {
                Console.Write(mas[i]);
                Console.Write("  ");
            }
            Console.WriteLine();
            Console.WriteLine();
            int k = sort_hoar(mas, 0, N - 1, 0);
            Console.WriteLine("Сортировка методом Хоара:");
            Console.WriteLine("Число перестановок равно {0}", k);
            for (int i = 0; i <= N - 1; ++i)
            {
                Console.Write(mas[i]);
                Console.Write("  ");
            }
            Console.WriteLine();
            sort_lin(mas, N);
            bin_search(mas, N);


            Console.ReadLine();
        }
    }
}
