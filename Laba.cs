using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AVM
{
    class Program
    {
        static void Main(string[] args)
        {
            
            const int N = 8;//буфер корней
            const double H = 0.0001;//допуск точности вичисления
            double h, y1 = 0, y2 = 0, a, b, x;
            double[] k = new double[N];
	        int i=0;
	        Console.WriteLine("Наше уравнение ln(x)-5cos(x)\nВведите \na,b,h\n пример a = -1; b = 10; h = 0.1;");
            a = Convert.ToDouble(Console.ReadLine());//начало отрезка по оси X
            b = Convert.ToDouble(Console.ReadLine());//конец отрезка
            h = Convert.ToDouble(Console.ReadLine());//шаг
	        x = a;
            Console.WriteLine("Диапазоны содержащие корни:\n");
	        while(x<=b)
	        {	
		        y1 = Math.Log(x) - 5 * Math.Cos(x);
		        if((y1*y2)<0) //уходит ниже нуля это значеине либо предыдущее
		        {
                    Console.WriteLine(" y1=" + y1 +" y2="+ y2);
			        k[i] = x;
                    Console.WriteLine("x[{2}] [ {0} , {1} ]\n", k[i], (k[i] + h),++i);
		        }
		        y2=y1;
		        x += h;
	        }
            Console.WriteLine("Искомые корни:\n");
            for (int j = 0; j < i; j++)
            {
                Console.WriteLine("\n Диапазон x[{2}] [ {0} , {1} ]", k[j], (k[j] + h), i + 1);//xt = x -(1/x-5*(-Math.Sin(x)))/(Math.Log(x)-5*Math.Cos(x))
                double xTemp;
                x = k[j]+h;
		        do
		        {
                    xTemp = x - ( Math.Log(x) - 5 * Math.Cos(x) )    /     ( 1 / x - 5 * (-Math.Sin(x)) );
                    y1 = (Math.Log(xTemp)-5*Math.Cos(xTemp));
		            x=xTemp;
		        }		while(y1>H);
                Console.WriteLine("\nx{0}={1}\n",j,x);
	        }
            Console.ReadLine();
        }
    }
}
