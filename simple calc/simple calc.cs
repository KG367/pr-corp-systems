namespace Calc
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Welcome to the Calc");
            float memory = 0;
            string value;
            do
            {
                float one, two=0, result;
                string sign;
                bool check;
                Console.Write("Input first number: ");
                check = Single.TryParse(Console.ReadLine(), out one);
                while (!check) {
                    Console.WriteLine("Input is incorrect, try again");
                    check = Single.TryParse(Console.ReadLine(), out one);
                }
                Console.WriteLine("Input action sign");
                Console.WriteLine("Available operations: +, -, *, /, % (mod), i (1/x), 2 (x^2), sr (√x), M+, M-, MR");
                string[] one_op = ["i", "2", "sr", "M+", "M-", "MR"],
                        two_op = ["+", "-", "*", "/", "%"];
                while (true)
                {
                    sign = Console.ReadLine();
                    if (two_op.Contains(sign))
                    {
                        Console.Write("Input second number: ");
                        check = Single.TryParse(Console.ReadLine(), out two);
                        while (!check)
                        {
                            Console.WriteLine("Input is incorrect, try again");
                            check = Single.TryParse(Console.ReadLine(), out two);
                        }
                    }
                    else if (one_op.Contains(sign))
                        break;
                    Console.WriteLine("Incorrect sign, try again");
                }

                switch (sign.ToUpper())
                    {
                        case "+":
                            result = one + two;
                            Console.WriteLine($"Sum is: {result}");
                            break;
                        case "-":
                            result = one - two;
                            Console.WriteLine($"Subtraction is: {result}");
                            break;
                        case "*":
                            result = one * two;
                            Console.WriteLine($"Product is: {result}");
                            break;
                        case "%":
                            if (two == 0)
                            {
                                Console.WriteLine("Error: Cannot divide by zero!");
                            }
                            else
                            {
                                result = one % two;
                                Console.WriteLine($"Remainder is: {result}");
                            }
                            break;
                        case "I":
                            if (one == 0)
                            {
                                Console.WriteLine("Error: Cannot calculate 1/0!");
                            }
                            else
                            {
                                result = 1 / one;
                                Console.WriteLine($"1/x result is: {result}");
                            }
                            break;
                        case "2":
                            result = one * one;
                            Console.WriteLine("This number squared is: " + result);
                            break;
                        case "SR":
                            if (one < 0)
                                Console.WriteLine("Error: Cannot calculate square root of negative number!");
                            else
                            {
                                result = (float)Math.Sqrt(one);
                                Console.WriteLine($"Square root is: {result}");
                            }
                            break;
                        case "M+":
                            memory += one;
                            Console.WriteLine($"Added {one} to memory");
                            Console.WriteLine($"Memory now contains: {memory}");
                            break;
                        case "M-":
                            memory -= one;
                            Console.WriteLine($"Subtracted {one} from memory");
                            Console.WriteLine($"Memory now contains: {memory}");
                            break;
                        case "MR":
                            Console.WriteLine($"Memory recall: {memory}");
                            break;
                        case "/":
                            if (two == 0)
                                Console.WriteLine("Error: Division by zero!");
                            else
                            {
                                result = one / two;
                                Console.WriteLine($"Division result is: {result}");
                            }
                            break;
                        default:
                            Console.WriteLine("You entered an invalid operator");
                            Console.WriteLine("Available operators: +, -, *, /, % (mod), i (1/x), 2 (x^2), sr (√x), M+, M-, MR");
                            break;
                    }
                if (Math.Abs(memory) > 1e30f)
                    Console.WriteLine("Warning: The in-memory number is close to overflow!");
                Console.Write("Do you want to continue(y/n): ");
                value = Console.ReadLine();
            } while (value.ToUpper() == "Y");
            
        }
    }
}