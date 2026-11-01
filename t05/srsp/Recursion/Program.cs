using System;

namespace Recursion
{
    static class Rec
    {
        // Сумма цифр неотрицательного числа
        public static int DigitSum(int n)
        {
            // Базовый случай: если число состоит из одной цифры (меньше 10), возвращаем само число
            if (n < 10)
                return n;

            // Шаг рекурсии: последняя цифра + сумма цифр оставшейся части числа
            return (n % 10) + DigitSum(n / 10);
        }

        // Возведение x в степень n (n >= 0) без Math.Pow
        public static long Pow(int x, int n)
        {
            // Базовый случай: любое число в нулевой степени равно 1
            if (n == 0)
                return 1;

            // Шаг рекурсии: умножаем основание x на x в степени (n - 1)
            return x * Pow(x, n - 1);
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            // Проверка DigitSum на 0, 7, 12345, 1000
            Console.WriteLine($"DigitSum(0) = {Rec.DigitSum(0)}");
            Console.WriteLine($"DigitSum(7) = {Rec.DigitSum(7)}");
            Console.WriteLine($"DigitSum(12345) = {Rec.DigitSum(12345)}");
            Console.WriteLine($"DigitSum(1000) = {Rec.DigitSum(1000)}");

            Console.WriteLine();

            // Проверка Pow на (2, 0), (2, 10), (5, 3), (7, 1)
            Console.WriteLine($"Pow(2, 0) = {Rec.Pow(2, 0)}");
            Console.WriteLine($"Pow(2, 10) = {Rec.Pow(2, 10)}");
            Console.WriteLine($"Pow(5, 3) = {Rec.Pow(5, 3)}");
            Console.WriteLine($"Pow(7, 1) = {Rec.Pow(7, 1)}");
        }
    }
}
