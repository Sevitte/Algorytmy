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
        public static double Power(double x, int y)
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

        public static double Factorial(double x)
        {
            if (x == 0)
                return 1;
            return x*Factorial(x-1);
        }

        public static double Abs(double x)
        {
            if (x >= 0)
                return x;
            else
                return -x;

        }

        //1

        public static double TaylorCos(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.000001;
            int n = 0;
            do
            {
                expression = (Power(-1, n) * Power(x, 2 * n)) / Factorial(2 * n);
                result = result + expression;
                n++;
            }
            while (Abs(expression) > epsylon);
            return result;
        }

        public static double TaylorE(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.00001;
            int n = 0;
            do
            {
                expression = Power(x, n) / Factorial(n);
                result = result + expression;
                n++;
            }
            while (Abs(expression) > epsylon);
            return result;
        }

        //2
        public static double TaylorCos2(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.000001;
            int n = 0;
            List<double> expressions = new List<double>();
            do
            {
                expression = (Power(-1, n) * Power(x, 2 * n)) / Factorial(2 * n);
                expressions.Add(expression);
                n++;
            }
            while (Abs(expression) > epsylon);
            for (int i = n-1; i >= 0; i--)
            {
                result = result + expressions[i];
            }
            return result;
        }

        public static double TaylorE2(double x)
        {
            double result = 0;
            double expression = 0;
            double epsylon = 0.00001;
            int n = 0;
            List<double> expressions = new List<double>();
            do
            {
                expression = Power(x, n) / Factorial(n);
                expressions.Add(expression);
                n++;
            }
            while (Abs(expression) > epsylon);
            Console.WriteLine("e" + n);
            for (int i = n-1; i >= 0; i--)
            {
                result = result + expressions[i];
            }
            return result;
        }

        //3
        public static double TaylorCos3(double x)
        {
            double result = 0;
            double epsylon = 0.000001;
            double expression = 0;
            int n = 0;
            do
            {
                if (n == 0)
                    expression = 1;
                if (n == 1)
                    expression = -(Power(x, 2) / 2);
                if (n > 1)
                    expression = expression * (-(Power(x, 2)) / (n * (n - 1)));
                n=n+2;
                result = result + expression;
            }
            while (Abs(expression) > epsylon);
            return result;
        }

        public static double TaylorE3(double x)
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
            while (Abs(expression) > epsylon);
            return result;
        }

        //4
        public static double TaylorCos4(double x)
        {
            double result = 0;
            double epsylon = 0.000001;
            double expression = 0;
            List<double> expressions = new List<double>();
            int n = 0;
            do
            {
                if (n == 0)
                    expression = 1;
                if (n == 1)
                    expression = -(Power(x, 2) / 2);
                if (n > 1)
                    expression = expression * (-(Power(x, 2)) / (n * (n - 1)));
                n = n + 2;
                expressions.Add(expression);
            }
            while (Abs(expression) > epsylon);
            for ( int i = (n/2)-1 ; i >= 0; i--)
            {
                result = result + expressions[i];
            }
            return result;
        }

        public static double TaylorE4(double x)
        {
            double result = 0;
            double epsylon = 0.000001;
            double expression = 0;
            List<double> expressions = new List<double>();
            int n = 0;
            do
            {
                if (n == 0)
                    expression = 1;
                else
                    expression = expression * (x / n);
                n++;
                expressions.Add(expression);
            }
            while (Abs(expression) > epsylon);
            for (int i = n - 1; i >= 0; i--)
            {
                result = result + expressions[i];
            }
            return result;
        }
        static void Main(string[] args)
        {
            //zapis do pliku z https://docs.microsoft.com/pl-pl/dotnet/standard/io/how-to-write-text-to-a-file
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            double n = -4;
            using (StreamWriter outputFile = new StreamWriter(Path.Combine(mydocpath, "WriteLines.txt")))
            {
                do
                {
                    outputFile.WriteLine(TaylorE(TaylorCos(n)) + ";" + Math.Pow(Math.E, Math.Cos(n)));
                    // n = n + 0.000008;
                    // n = n + 0.08;
                }
                while (n < 4);
            }
            //test dla drukowania pojedynczych wyrazen
            //Console.WriteLine(TaylorE3(TaylorCos3(-4)));
            //Console.WriteLine(Math.Pow(Math.E, Math.Cos(-4)));
            Console.ReadLine();
        }
    }
}
