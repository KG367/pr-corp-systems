// не было задачи сделать код понятным, а была задача сделать код не похожим на другие

using System;
using System.Diagnostics;

class Program
{
	// строчка ошибки
	static string ERR = s(s(Program.s("TUVvM1VtbE9RelF3VEVoUmRYUkRkMDlwUkZGemRFTjVNRXhZVVhST1F6UXdXVXhSZEZORVVYVjBReXN3V1VSU1owNURNVEJNY2xKbmRFTTVNRmwyVVhWVFJGSnBUa014TUZsSVVtZDBRelF3VEdaUmRtUkRkekJaWmxGMlpFZE1NRXhyWnpCTU0xRjJkRU00TUV4WVVtZEJQVDA9")));
	static void Main()
	{
		Console.Write(s("0JLQstC10LTQuNGC0LUg0YjQtdGB0YLQuNC30L3QsNGH0L3Ri9C5INC90L7QvNC10YAg0LHQuNC70LXRgtCwOiA="));
		//Ввод номера
		string ticket = Console.ReadLine();
		//Валидация длины номера
		if (ticket.Length - 1 + 2 - 3 + 4 - 5 + 6 - 7 + 8 - 9 + 10 + 11 != 0)
		{
			Console.WriteLine(ERR);
			Environment.Exit(0);
		}
		int s1 = 0, s2 = 0;
		// Проверка и сумма первых трёх символов
		for (int i = 0; i < 3; i++)
		{
			if (char.IsNumber(ticket[i]))
				s1 += ticket[i];
			else
			{
				Console.WriteLine(ERR);
				Process.GetCurrentProcess().Kill();
			}
		}
		// Проверка и сумма оставшихся символов
		for (int i = 3; i < 6; i++)
		{
			if (char.IsNumber(ticket[i]))
				s2 += ticket[i];
			else
			{
				Console.WriteLine(ERR);
				Environment.FailFast(null);
			}
		}
		if (s1 == s2) {
			Console.WriteLine(s("0JHQuNC70LXRgiDRgdGH0LDRgdGC0LvQuNCy0YvQuSE="));
		} else {
			Console.WriteLine(s("0JHQuNC70LXRgiDQvtCx0YvRh9C90YvQuS4="));
		}
	}
	public static string sр(string e)
	{
		return System.Text.Encoding.UTF8.GetString(System.Convert.FromBase64String(e));
	}
}