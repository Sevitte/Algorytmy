using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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

        //1

        public static double taylorCos(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.000001;
            int n = 0;
            do
            {
                expression = (power(-1, n) * power(x, 2 * n)) / factorial(2 * n);
                result = result + expression;
                n++;
            }
            while (abs(expression) > epsylon);
            Console.WriteLine(n);
            return result;
        }

        public static double taylorE(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.00001;
            int n = 0;
            do
            {
                expression = power(x, n) / factorial(n);
                result = result + expression;
                n++;
            }
            while (abs(expression) > epsylon);
            Console.WriteLine("e");
            Console.WriteLine(n);
            return result;
        }

        //2
        public static double taylorCos2(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.000001;
            int n = 0;
            List<double> expressions = new List<double>();
            do
            {
                expression = (power(-1, n) * power(x, 2 * n)) / factorial(2 * n);
                expressions.Add(expression);
                n++;
            }
            while (abs(expression) > epsylon);
            Console.WriteLine(n);
            for (int i = n-1; i >= 0; i--)
            {
                result = result + expressions[i];
            }
            return result;
        }

        public static double taylorE2(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.00001;
            int n = 0;
            List<double> expressions = new List<double>();
            do
            {
                expression = power(x, n) / factorial(n);
                expressions.Add(expression);
                n++;
            }
            while (abs(expression) > epsylon);
            Console.WriteLine("e" + n);
            for (int i = n-1; i >= 0; i--)
            {
                result = result + expressions[i];
            }
            return result;
        }

        //3
        public static double taylorCos3(double x)
        {
            double result = 0;
            double epsylon = 0.000001;
            double expression = 0;
            int n = 0;
            do
            {
                if (n == 0)
                    expression = 1;
                else 
                    expression = expression*(-x/(2*n));
                n++;
                result = result + expression;
            }
            while (abs(result* (-x / (2 * n))) > epsylon);
            return result;
        }

        public static double taylorE3(double x)
        {
            double result = 0;
            double epsylon = 0.000001;
            double expression = 0;
            int n = 0;
            do
            {
                if (n == 0)
                    expression = 1;
                else
                    expression = expression * (x / n);
                n++;
                result = result + expression;
            }
            while (abs(result * (x / n)) > epsylon);
            return result;
        }

        static void Main(string[] args)
        {
            ////zapis do pliku z https://docs.microsoft.com/pl-pl/dotnet/standard/io/how-to-write-text-to-a-file
            //string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            //double n = -4;
            //using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "WriteLines3.txt")))
            //{
            //    do
            //    {
            //        outputFile.WriteLine(taylorE3(taylorCos3(n)) + ";" + Math.Pow(Math.E, Math.Cos(n)));
            //        n = n + 0.000008;
            //    }
            //    while (n < 4);
            //}


            Console.WriteLine(taylorE3(taylorCos3(-1)));
            Console.WriteLine(Math.Pow(Math.E, Math.Cos(-1)));
            Console.ReadLine();
        }
    }
}
