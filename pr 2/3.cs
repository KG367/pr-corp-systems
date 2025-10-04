using System;
class Program
{
    static void Main()
    {
        // Ввод чисел
        Console.Write("Введите числитель M: ");
        int m;
        bool check;
        while (check=!int.TryParse(Console.ReadLine(), out m))
        {
            Console.WriteLine("Это не число, попробуйте ещё раз");
        }
        int n;
        Console.Write("Введите знаменатель N: ");
        while (check=!int.TryParse(Console.ReadLine(), out n))
        {
            Console.WriteLine("Это не число, попробуйте ещё раз");
        }
        // Находим НОД
        int gcd = FindGCD(Math.Abs(m), Math.Abs(n));
        // Сокращаем дробь
        int numerator = m / gcd;
        int denominator = n / gcd;

        // Приведение к стандартному виду (?)
        if (denominator < 0)
        {
            numerator = -numerator;
            denominator = -denominator;
        }
        // Выводим результат
        Console.WriteLine($"Несократимая дробь: {numerator}/{denominator}");
    }
    // Метод для нахождения НОД (через каноническое разложение на простые)
    static int FindGCD(int a, int b)
    {
        List<int> first = new List<int>();
        // Разложение на простые первого множителя
        // Де-факто проверки на простоту не происходит, но я бы увидился если бы среди итоговых делителей оказалось составное
        // Нахождение пары вышеупомянутого составного и исходного числа может претендовать на тьюринга или абелевку
        for (int i = 2; a != 1; i++)
        {
            Console.WriteLine(2);
            first.Add(0);
            while (a % i == 0)
            {
                first[i - 2]++;
                a /= i;
            }
        }
        // Аналогично, разложение на простые второго множителя
        // По-хорошему надо выделить в отдельную функцию но время (05:44) говорит что пора закругляться
        List<int> second = new List<int>();
        for (int i = 2; b != 1; i++)
        {
            second.Add(0);
            while (b % i == 0)
            {
                second[i - 2]++;
                b /= i;
            }
        }
        int res = 1;
        // формула из википедии, магия
        for (int i = 0; i < Math.Min(first.Count, second.Count); i++)
            res *= ipow(i + 2, Math.Min(first[i], second[i]));
        return res;
    }
    // Вчера копался в исходниках одной криптографической либы, вот оттуда функция
    static int ipow(int x, int y)
    {
        int result = 1;
        for (; ; )
        {
            Console.WriteLine("1");
            if ((y & 1) != 0)
                result *= x;
            y >>= 1;
            if (y == 0)
                break;
            x *= x;
        }

        return result;
    }
}