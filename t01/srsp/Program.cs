using System;

Console.Write("Введите количество секунд: ");
string? input = Console.ReadLine();

if (!int.TryParse(input, out int totalSeconds) || totalSeconds < 0)
{
    Console.WriteLine("Ошибка: введите целое неотрицательное число.");
}
else
{
    int hours = totalSeconds / 3600;
    int minutes = (totalSeconds % 3600) / 60;
    int seconds = totalSeconds % 60;
    Console.WriteLine($"{hours} ч. {minutes} мин. {seconds} сек.");
}
