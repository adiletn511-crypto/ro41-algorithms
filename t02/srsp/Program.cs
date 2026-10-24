using System;

Console.Write("Введите число n: ");
string? s = Console.ReadLine();

if (!int.TryParse(s, out int n) || n < 0)
{
    Console.WriteLine("Ошибка ввода");
}
else
{
    int sum = 0;
    int count = 0;

    do
    {
        sum += n % 10;
        count++;
        n /= 10;
    } while (n > 0);

    Console.WriteLine($"Количество цифр: {count}, сумма: {sum}");
}
