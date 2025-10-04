//https://youtu.be/wW5rqURh5-4?si=mjEFYFjEr0tQ6ydG
//#define DEBUG

using System;
using System.Globalization;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

class Program {
    static void debug(string text, [CallerLineNumber] int lineNumber=0) {
#if DEBUG
        Console.WriteLine(lineNumber.ToString()+' '+text);
#endif
    }
    private static List<double> cache = new List<double>(); // factorial cache
    // Функция для вычисления факториала (с простейшим кэшем)
    static double Factorial(int n) {
        debug($"{n} {cache.Count}");
        if (cache.Count > n && cache[n] != 0) {
            debug($"{n} {cache[n]} {cache.Count}");
            return cache[n];
        }

        double result = Factorial(n - 1) * n;
        while (cache.Count == n)
            cache.Add(0);
        debug($"{n} {result} {cache.Count}");
        cache[n] = result;
        return result;
    }
    // Функция для вычисления n-го члена ряда Маклорена (для sinh(x))
    static double GetNthTerm(double x, int n) {
        return Math.Pow(x, 2*n+1) / Factorial(2*n+1);
    }
    // Функция для вычисления суммы ряда с заданной точностью
    static double sinh(double x, double epsilon) {
        double sum = 0;
        double term = x; // Первый член ряда
        int n = 0;

        while (Math.Abs(term) > epsilon) {
            sum += term;
            n++;
            term = GetNthTerm(x, n); // Вычисление следующего члена
        }
        return sum;
    }

    static void Main() {
        cache.Add(1);

        Console.WriteLine("Введите x:");

        double x;
        bool check = double.TryParse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture, out x);
        while (!check)
        {
            Console.WriteLine("Это не число, попробуйте ещё раз");
            check = double.TryParse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture, out x);
        }
        // Вычисление с заданной точностью
        double epsilon;
        do
        {
            Console.WriteLine("Введите точность (e <= 0.01):");
            check = double.TryParse(Console.ReadLine().Replace(',', '.'), CultureInfo.InvariantCulture, out epsilon);
            if (!check)
                Console.WriteLine("Это не число, попробуйте ещё раз");
            else if (epsilon > 0.01)
                Console.WriteLine("Точность должна быть меньше 0.01");
            else if (epsilon <= 0)
                Console.WriteLine("Точность должна быть больше 0");
            else
                break;
        } while (true);

        double result = sinh(x, epsilon);
        Console.WriteLine($"Значение sinh({x}) с точностью {epsilon}: {result}");
        Console.WriteLine($"Истинное значение функции: {Math.Sinh(x)}");
        // Вычисление n-го члена
        Console.WriteLine("\nВведите номер члена ряда (n):");
        int n;
        check = int.TryParse(Console.ReadLine().Replace(',', '.'), out n);
        while (!check)
        {
            Console.WriteLine("Это не число, попробуйте ещё раз");
            check = int.TryParse(Console.ReadLine().Replace(',', '.'), out n);
        }
        double nthTerm = GetNthTerm(x, n);
        Console.WriteLine($"Значение {n}-го члена ряда: {nthTerm}");
    }
}