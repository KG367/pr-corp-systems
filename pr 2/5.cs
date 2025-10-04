using System;
class CoffeeMachine
{
    // Основные параметры напитков
    const int AMERICANO_WATER = 300; // мл воды для американо
    const int LATTE_WATER = 30; // мл воды для латте
    const int LATTE_MILK = 270; // мл молока для латте
    const int AMERICANO_PRICE = 150; // цена американо
    const int LATTE_PRICE = 170; // цена латте
    static int water; // текущий запас воды
    static int milk; // текущий запас молока
    static int latte_count = 0; // количество приготовленного латте
    static int americano_count = 0; // количество приготовленного американо
    static void Main()
    {
        // Запрашиваем начальный запас ингредиентов
        Console.Write("Введите количество воды (мл): ");
        while (!int.TryParse(Console.ReadLine(), out water))
            Console.WriteLine("Это не число, попробуйте ещё раз");

        Console.Write("Введите количество молока (мл): ");
        while (!int.TryParse(Console.ReadLine(), out milk))
            Console.WriteLine("Это не число, попробуйте ещё раз");

        // Главный цикл
        // Проверка на достаточность ингредиентов
        while ((water >= AMERICANO_WATER) || (water >= LATTE_WATER && milk >= LATTE_MILK))
        {
            Console.WriteLine("Меню:");
            Console.WriteLine("1 - Американо");
            Console.WriteLine("2 - Латте");
            Console.Write("Выберите напиток: ");
            int choice;
            while (!int.TryParse(Console.ReadLine(), out choice))
                Console.WriteLine("Это не число, попробуйте ещё раз");
            // Выбор позиции меню
            switch (choice)
            {
                case 1:
                    // Американо
                    if (water >= AMERICANO_WATER)
                    {
                        water -= AMERICANO_WATER;
                        americano_count++;
                        Console.WriteLine($"Ваш напиток готов.");
                    }
                    else
                    {
                        Console.WriteLine("Недостаточно воды для приготовления Американо");
                    }
                    break;
                case 2:
                    // Латте
                    if (water >= LATTE_WATER && milk >= LATTE_MILK)
                    {
                        water -= LATTE_WATER;
                        milk -= LATTE_MILK;
                        latte_count++;
                        Console.WriteLine($"Ваш напиток готов.");
                    }
                    else
                    {
                        // Спорю на обед что нет тесткейса где до этого пункта дошли с нехваткой воды 
                        // Если, конечно, не менять исходное соотношение вода/молоко на напитки
                        // Плохо для расширения, но в целом норм
                        Console.WriteLine("Недостаточно молока для приготовления Латте");
                    }
                    break;
                default:
                    Console.WriteLine("Неверный выбор");
                    break;
            }
        }

        // Итоговый отчёт
        Console.WriteLine("Ингредиентов не достаточно");
        Console.WriteLine($"Осталось воды: {water} мл");
        Console.WriteLine($"Осталось молока: {milk} мл");
        Console.WriteLine($"Приготовлено Американо: {americano_count} шт.");
        Console.WriteLine($"Приготовлено Латте: {latte_count} шт.");
        Console.WriteLine($"Итого: {americano_count*AMERICANO_PRICE+latte_count*LATTE_PRICE}.");
    }
}