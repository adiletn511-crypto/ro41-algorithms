using System;
using System.Text;

namespace TextToolsApp
{
    public static class TextTools
    {
        public static int CountWords(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return 0;

            string[] parts = s.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            return parts.Length;
        }

        public static bool IsPalindrome(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return true;

            StringBuilder clean = new StringBuilder();
            for (int i = 0; i < s.Length; i++)
            {
                if (!char.IsWhiteSpace(s[i]))
                {
                    clean.Append(char.ToLower(s[i]));
                }
            }

            int left = 0;
            int right = clean.Length - 1;
            while (left < right)
            {
                if (clean[left] != clean[right]) return false;
                left++;
                right--;
            }

            return true;
        }

        public static string Initials(string fullName)
        {
            if (string.IsNullOrWhiteSpace(fullName)) return "";

            string[] words = fullName.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < words.Length; i++)
            {
                if (i > 0) sb.Append(' ');
                sb.Append(char.ToUpper(words[i][0]));
                sb.Append('.');
            }

            return sb.ToString();
        }

        public static string Repeat(string s, int n)
        {
            if (string.IsNullOrEmpty(s) || n <= 0) return "";

            StringBuilder sb = new StringBuilder(s.Length * n);
            for (int i = 0; i < n; i++)
            {
                sb.Append(s);
            }

            return sb.ToString();
        }
    }

    class Program
    {
        static void Main()
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("СРСП 8. Класс TextTools: обработка текста");
            Console.WriteLine("Студент: Нурланулы Адилет (ИС-25 26Б)\n");

            Console.WriteLine("=== 1. Тест CountWords ===");
            TestCountWords("", 0);
            TestCountWords("   ", 0);
            TestCountWords(" a  b ", 2);
            TestCountWords("А роза упала на лапу Азора", 6);
            TestCountWords("Ахметов Ерлан", 2);

            Console.WriteLine("\n=== 2. Тест IsPalindrome ===");
            TestIsPalindrome("", true);
            TestIsPalindrome("   ", true);
            TestIsPalindrome(" a  b ", false);
            TestIsPalindrome("А роза упала на лапу Азора", true);
            TestIsPalindrome("Ахметов Ерлан", false);

            Console.WriteLine("\n=== 3. Тест Initials ===");
            TestInitials("", "");
            TestInitials("   ", "");
            TestInitials(" a  b ", "A. B.");
            TestInitials("Ахметов Ерлан", "А. Е.");
            TestInitials("Ахметов Ерлан Серикұлы", "А. Е. С.");

            Console.WriteLine("\n=== 4. Тест Repeat ===");
            TestRepeat("", 3, "");
            TestRepeat("   ", 2, "      ");
            TestRepeat("ab", 3, "ababab");
            TestRepeat("Ахметов Ерлан", 0, "");
        }

        static void TestCountWords(string input, int expected)
        {
            int actual = TextTools.CountWords(input);
            string status = (actual == expected) ? "OK" : "FAIL";
            Console.WriteLine($"Вход: \"{input}\" | Ожидалось: {expected} | Фактически: {actual} | {status}");
        }

        static void TestIsPalindrome(string input, bool expected)
        {
            bool actual = TextTools.IsPalindrome(input);
            string status = (actual == expected) ? "OK" : "FAIL";
            Console.WriteLine($"Вход: \"{input}\" | Ожидалось: {expected} | Фактически: {actual} | {status}");
        }

        static void TestInitials(string input, string expected)
        {
            string actual = TextTools.Initials(input);
            string status = (actual == expected) ? "OK" : "FAIL";
            Console.WriteLine($"Вход: \"{input}\" | Ожидалось: \"{expected}\" | Фактически: \"{actual}\" | {status}");
        }

        static void TestRepeat(string input, int n, string expected)
        {
            string actual = TextTools.Repeat(input, n);
            string status = (actual == expected) ? "OK" : "FAIL";
            Console.WriteLine($"Вход: \"{input}\", n={n} | Ожидалось: \"{expected}\" | Фактически: \"{actual}\" | {status}");
        }
    }
}
