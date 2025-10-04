using System;
class Program
{
    static void Main()
    {
        // Ввод данных
        int n;
        Console.Write("Введите количество модулей (n): ");
        while (!int.TryParse(Console.ReadLine(), out n) || n <= 0)
            Console.Write("Это не число, попробуйте ещё раз\nВведите количество модулей (n): ");

        int a, b;
        Console.Write("Введите размеры модуля (a b): ");
        string[] input = Console.ReadLine().Split();
        while (!int.TryParse(input[0], out a) ||
                !int.TryParse(input[1], out b) ||
                a <= 0 || b <= 0)
        {
            Console.Write("Некоректный ввод\nВведите размеры модуля (a b): ");
            input = Console.ReadLine().Split();
        }

        int h, w;
        Console.Write("Введите размеры поля (h w): ");
        input = Console.ReadLine().Split();
        while (!int.TryParse(input[0], out h) ||
                !int.TryParse(input[1], out w) ||
                h <= 0 || w <= 0)
        {
            Console.Write("Некоректный ввод, попробуйте ещё раз\nВведите размеры поля (h w): ");
            input = Console.ReadLine().Split();
        }

        // Вычисление максимальной толщины защиты
        int maxD = CalculateMaxProtection(n, a, b, h, w);
        if (maxD == -1)
            Console.WriteLine("Невозможно поместить модули на поле");
        else
            Console.WriteLine($"Максимальная толщина защиты: {maxD}");
    }
    static int CalculateMaxProtection(int n, int a, int b, int h, int w)
    {
        int maxD = -1;
        for (int d = 0; d <= Math.Min(w, h); d++)
        {
            // Проверка вместимости как горизонтально, так и вертикально
            if (CanPlaceModules(n, a, b, w, h, d))
                maxD = d; // запоминаем толщину
            else
                break; // Если d не подошёл однажды, дальше продолжать смысла нет
        }
        return maxD;
    }
    static bool CanPlaceModules(int n, int a, int b, int h, int w, int d)
    {
        // Размеры модуля с защитой
        int aWithD = a + 2 * d;
        int bWithD = b + 2 * d;
        // Проверяем оба варианта ориентации
        return (h >= aWithD && w >= bWithD && CanFit(n, aWithD, bWithD, h, w)) || (h >= bWithD && w >= aWithD && CanFit(n, bWithD, aWithD, h, w));
    }
    static bool CanFit(int n, int a, int b, int h, int w)
    {
        // Максимальное количество модулей по высоте и ширине
        int maxHeight = h / a;
        int maxWidth = w / b;
        return maxHeight * maxWidth >= n;
    }
}