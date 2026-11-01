using System;

namespace ArrayOpsProject
{
    static class ArrayOps
    {
        // 1. Сумма элементов массива
        public static int Sum(int[] a)
        {
            int sum = 0;
            for (int i = 0; i < a.Length; i++)
            {
                sum += a[i];
            }
            return sum;
        }

        // 2. Индекс первого минимального элемента (начальное значение из массива)
        public static int IndexOfMin(int[] a)
        {
            int min = a[0];
            int minIndex = 0;

            for (int i = 1; i < a.Length; i++)
            {
                // Строгое неравенство (<) сохраняет индекс именно ПЕРВОГО минимума
                if (a[i] < min)
                {
                    min = a[i];
                    minIndex = i;
                }
            }
            return minIndex;
        }

        // 3. Количество элементов строго больше x
        public static int CountGreater(int[] a, int x)
        {
            int count = 0;
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i] > x)
                {
                    count++;
                }
            }
            return count;
        }

        // 4. Разворот массива на месте
        public static void Reverse(int[] a)
        {
            int n = a.Length;
            for (int i = 0; i < n / 2; i++)
            {
                int temp = a[i];
                a[i] = a[n - 1 - i];
                a[n - 1 - i] = temp;
            }
        }
    }

    class Program
    {
        static void PrintArray(int[] a)
        {
            Console.Write("{");
            for (int i = 0; i < a.Length; i++)
            {
                Console.Write(a[i]);
                if (i < a.Length - 1)
                    Console.Write(", ");
            }
            Console.Write("}");
        }

        static void TestArray(int[] a)
        {
            Console.Write("Исходный массив: ");
            PrintArray(a);
            Console.WriteLine();

            Console.WriteLine($"Sum = {ArrayOps.Sum(a)}");
            Console.WriteLine($"IndexOfMin = {ArrayOps.IndexOfMin(a)}");
            Console.WriteLine($"CountGreater(x = 2) = {ArrayOps.CountGreater(a, 2)}");

            ArrayOps.Reverse(a);
            Console.Write("После Reverse:   ");
            PrintArray(a);
            Console.WriteLine();
            Console.WriteLine(new string('-', 35));
        }

        static void Main(string[] args)
        {
            int[][] testArrays = new int[][]
            {
                new int[] { 4, 1, 7, 3, 9 },
                new int[] { 5 },
                new int[] { -2, -7, -4 },
                new int[] { 2, 2, 2 }
            };

            for (int i = 0; i < testArrays.Length; i++)
            {
                TestArray(testArrays[i]);
            }
        }
    }
}
