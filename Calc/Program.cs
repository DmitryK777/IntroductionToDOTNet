using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc
{
	internal class Program
	{
		static void Main(string[] args)
		{
			string expression;
			string[] numbers;

			do
			{
				Console.Write("Введите простое арифметическое выражение: ");
				expression = Console.ReadLine();
				expression = expression.Replace('.', ',');
				numbers = expression.Split('+', '-', '*', '/');
				if (numbers.Length != 2) Console.WriteLine("Неверная запись, введите ещё раз.");
            } while (numbers.Length != 2);
			
			double a = Convert.ToDouble(numbers[0]);
			double b = Convert.ToDouble(numbers[1]);

			switch(expression[expression.IndexOfAny(new char[] { '+', '-', '*', '/' })])
			{
				case '+': Console.WriteLine($"{a} + {b} = {a + b} "); break;
				case '-': Console.WriteLine($"{a} - {b} = {a - b} "); break;
				case '*': Console.WriteLine($"{a} * {b} = {a * b} "); break;
				case '/': Console.WriteLine($"{a} / {b} = {a / b} "); break;
            }
        }
	}
}
