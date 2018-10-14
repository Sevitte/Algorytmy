using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//e^cosx

namespace Alg1
{
    class Program
    {
        public static double power(double x, int y)
        {
            int counter;
            double x2 = x;

            if (y == 0)
                return 1;

            for (counter = 1; counter < y; counter++)
            {
                x = x * x2;
            }
            return x;
        }

        public static double factorial(double x)
        {
            if (x == 0)
                return 1;
            return x*factorial(x-1);
        }

        public static double abs(double x)
        {
            if (x >= 0)
                return x;
            else
                return -x;

        }
        public static double taylorCos(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.0001;
            int n = 0;
            do
            {
                expression = (power(-1, n) * power(x, 2*n)) / factorial(2*n);
                result = result + expression;
                n++;
            }
            while (expression > epsylon);
            return result;
        }

        public static double taylorE(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.0001;
            int n = 0;
            do
            {
                expression = power(x, n) / factorial(n);
                result = result + expression;
                n++;
            }
            while (expression > epsylon);
            return result;
        }


        static void Main(string[] args)
        {

             Console.WriteLine(taylorE(taylorCos(0)));
             Console.WriteLine(Math.Pow(Math.E,Math.Cos(0)));
            
            double n = -4;
            do
             {
                
                 Console.WriteLine(taylorE(taylorCos(n)) + ";" + Math.Pow(Math.E,Math.Cos(n)));
                //n = n + 0.000008;
                n = n + 0.5;
             }
             while (n < 4);



            Console.ReadLine();
        }
    }
}
