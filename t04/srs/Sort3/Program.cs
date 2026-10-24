using System;

class Program
{
    static void Main()
    {
        RunTest(3, 1, 2);
        RunTest(1, 2, 3);
        RunTest(3, 2, 1);
        RunTest(2, 2, 1);
        RunTest(5, 5, 5);
    }

    static void RunTest(int originalA, int originalB, int originalC)
    {
        int a = originalA;
        int b = originalB;
        int c = originalC;

        Order.Sort3(ref a, ref b, ref c);

        Console.WriteLine($"{originalA} {originalB} {originalC} -> {a} {b} {c}");
    }
}

static class Order
{
    public static void Swap(ref int x, ref int y)
    {
        int temp = x;
        x = y;
        y = temp;
    }

    public static void Sort3(ref int a, ref int b, ref int c)
    {
        if (a > b) Swap(ref a, ref b);
        if (a > c) Swap(ref a, ref c);
        if (b > c) Swap(ref b, ref c);
    }
}
