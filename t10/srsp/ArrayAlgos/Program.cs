using System;
using System.Text;

namespace ArrayAlgosApp
{
    public static class ArrayAlgos
    {
        public static bool IsSorted(int[] a)
        {
            if (a == null || a.Length <= 1) return true;

            for (int i = 0; i < a.Length - 1; i++)
            {
                if (a[i] > a[i + 1]) return false;
            }

            return true;
        }

        public static int BubbleSort(int[] a)
        {
            if (a == null || a.Length <= 1) return 0;

            int comparisons = 0;
            int n = a.Length;

            for (int i = 0; i < n - 1; i++)
            {
                bool swapped = false;
                for (int j = 0; j < n - 1 - i; j++)
                {
                    comparisons++;
                    if (a[j] > a[j + 1])
                    {
                        int temp = a[j];
                        a[j] = a[j + 1];
                        a[j + 1] = temp;
                        swapped = true;
                    }
                }

                if (!swapped) break;
            }

            return comparisons;
        }

        public static int CountOccurrences(int[] sortedA, int x)
        {
            if (sortedA == null || sortedA.Length == 0) return 0;

            int firstGe = LowerBound(sortedA, x);
            int firstGt = UpperBound(sortedA, x);

            return firstGt - firstGe;
        }

        private static int LowerBound(int[] a, int x)
        {
            int lo = 0;
            int hi = a.Length;

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (a[mid] >= x)
                    hi = mid;
                else
                    lo = mid + 1;
            }

            return lo;
        }

        private static int UpperBound(int[] a, int x)
        {
            int lo = 0;
            int hi = a.Length;

            while (lo < hi)
            {
                int mid = lo + (hi - lo) / 2;
                if (a[mid] > x)
                    hi = mid;
                else
                    lo = mid + 1;
            }

            return lo;
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("СРСП 10. Сортировка пузырьком и подсчёт вхождений бинарным поиском");
            Console.WriteLine("Студент: Нурланулы Адилет (ИС-25 26Б)\n");

            Console.WriteLine("=== 1. Тест BubbleSort и IsSorted ===");
            TestBubbleSort(new int[] { });
            TestBubbleSort(new int[] { 5 });
            TestBubbleSort(new int[] { 1, 2, 3, 4, 5 });
            TestBubbleSort(new int[] { 5, 4, 3, 2, 1 });
            TestBubbleSort(new int[] { 3, 1, 3, 2, 3 });

            int[] arr1000 = new int[1000];
            for (int i = 0; i < 1000; i++) arr1000[i] = i + 1;
            int comp1000 = ArrayAlgos.BubbleSort(arr1000);
            bool sorted1000 = ArrayAlgos.IsSorted(arr1000);
            string status1000 = (comp1000 == 999 && sorted1000) ? "OK" : "FAIL";
            Console.WriteLine($"Массив из 1000 элементов (отсортированный): IsSorted={sorted1000} | Сравнений={comp1000} (Ожидалось: 999) | {status1000}");

            Console.WriteLine("\n=== 2. Тест CountOccurrences ===");
            int[] sortedArr = { 1, 2, 2, 2, 5, 7 };
            Console.WriteLine($"Массив: {FormatArray(sortedArr)}");
            TestCount(sortedArr, 2, 3);
            TestCount(sortedArr, 1, 1);
            TestCount(sortedArr, 7, 1);
            TestCount(sortedArr, 3, 0);
            TestCount(sortedArr, 9, 0);
        }

        static void TestBubbleSort(int[] a)
        {
            string before = FormatArray(a);
            int comparisons = ArrayAlgos.BubbleSort(a);
            string after = FormatArray(a);
            bool isSorted = ArrayAlgos.IsSorted(a);
            string status = isSorted ? "OK" : "FAIL";

            Console.WriteLine($"До: {before} | После: {after} | IsSorted: {isSorted} | Сравнений: {comparisons} | {status}");
        }

        static void TestCount(int[] sortedA, int x, int expected)
        {
            int actual = ArrayAlgos.CountOccurrences(sortedA, x);
            string status = (actual == expected) ? "OK" : "FAIL";
            Console.WriteLine($"x = {x} | Ожидалось: {expected} | Фактически: {actual} | {status}");
        }

        static string FormatArray(int[] a)
        {
            if (a == null || a.Length == 0) return "{}";
            StringBuilder sb = new StringBuilder("{");
            for (int i = 0; i < a.Length; i++)
            {
                if (i > 0) sb.Append(", ");
                sb.Append(a[i]);
            }
            sb.Append("}");
            return sb.ToString();
        }
    }
}
