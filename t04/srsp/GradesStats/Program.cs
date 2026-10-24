using System;

class Program
{
    static void Main()
    {
        int count = 0;
        int sum = 0;
        int fives = 0;

        int g = Grades.Read();
        while (g != Grades.Stop)
        {
            if (Grades.IsValid(g))
            {
                count++;
                sum += g;
                if (g == Grades.Max)
                {
                    fives++;
                }
            }
            g = Grades.Read();
        }

        Grades.PrintStats(count, sum, fives);
    }
}

static class Grades
{
    public const int Min = 2;
    public const int Max = 5;
    public const int Stop = 0;

    public static int Read()
    {
        string? input = Console.ReadLine();
        if (int.TryParse(input, out int val))
        {
            return val;
        }
        return -1;
    }

    public static bool IsValid(int g)
    {
        return g >= Min && g <= Max;
    }

    public static void PrintStats(int count, int sum, int fives)
    {
        if (count == 0)
        {
            Console.WriteLine("Оценок нет");
        }
        else
        {
            double avg = (double)sum / count;
            Console.WriteLine($"Всего оценок: {count}, сумма: {sum}, пятерок: {fives}, среднее: {avg:F2}");
        }
    }
}
