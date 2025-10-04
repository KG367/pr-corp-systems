using System;
class Program
{
    static void Main()
    {
        // Ввод начальных данных
        Console.Write("Введите количество бактерий (N): ");
        int N;
        while (!int.TryParse(Console.ReadLine(), out N) || N <= 0)
            Console.WriteLine("Что-то не то, попробуйте ещё раз");
        Console.Write("Введите количество капель антибиотика (X): ");
        int X;
        while (!int.TryParse(Console.ReadLine(), out X) || X <= 0)
            Console.WriteLine("Что-то не то, попробуйте ещё раз");
        int bacteria = N; // текущее количество бактерий
        int hours = 0; // счетчик часов
        int killPower = 10; // мощность антибиотика
        Console.WriteLine("\nДинамика изменения количества бактерий:");
        // Цикл моделирования процесса
        while (killPower > 0 && bacteria > 0)
        {
            hours++;
            // Бактерии удваиваются
            bacteria *= 2;
            // Антибиотик убивает бактерии
            bacteria -= killPower * X;
            // Количество бактерий не может быть отрицательным
            if (bacteria < 0)
                bacteria = 0;
            // Мощность антибиотика уменьшается
            killPower--;
            Console.WriteLine($"Час {hours}: Бактерий = {bacteria}, Мощность антибиотика = {killPower * X}");
        }
        Console.WriteLine($"\nПроцесс завершен через {hours} часов");
        Console.WriteLine($"Конечное количество бактерий: {bacteria}");
    }
}
// К примеру программы из задания есть некоторые вопросики, напр. в нач. условиях 50 бакт и 2 капли
// Считаем, 50*2=100, 100-2*10=80, но никак не 70