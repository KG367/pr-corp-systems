using System;
class NumberGuesser
{
    static void Main()
    {
        Console.WriteLine("Загадайте число от 0 до 63. Я попробую его угадать.");
        Console.WriteLine("Отвечайте '1' (да) или '0' (нет) на мои вопросы.");
        // Начальные границы поиска
        int lower = 0;
        int upper = 64;
        // Простой бинарный поиск
        while (lower != upper)
        {
            int m = lower + (upper - lower + 1) / 2;
            Console.Write($"Ваше число больше или равно {m}? (1/0): ");
            string answer = Console.ReadLine();
            Console.WriteLine($"{lower} {upper}");
            // В зависимости от ответа соответствующе меняем границы
            if (answer == "1")
            {
                lower = m;
            }
            else if (answer == "0")
            {
                upper = m - 1;
            }
            else
            {
                // Неправильный ввод
                Console.WriteLine("Ввод не нравится, переделайте");
                continue;
            }
        }
        Console.WriteLine($"Ваше число: {lower}");
        // Риторический вопрос
        Console.WriteLine("Я угадал?");
    }
}