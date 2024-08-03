using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCalculator
{
	internal class Program
	{
		static void Main()
		{
			Console.Write("Введите выражение: ");
			string expression = Console.ReadLine();
			Console.WriteLine($"{expression} = {arrange_expression(expression)}");
		}

		static double arrange_expression(string expression) // Упорядочить выражение
		{
			string[] numbers = expression.Split('+', '-', '*', '/');
			double[] operands = new double[numbers.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = numbers[i].Trim();
				operands[i] = Convert.ToDouble(numbers[i]);
			}

			char[] operators = new char[numbers.Length - 1];
			int count = 0;
			for (int i = 0; i < expression.Length; i++)
			{
				
				if (expression[i] == '+' || expression[i] == '-' || expression[i] == '*' || expression[i] == '/')
				{
					operators[count] = Convert.ToChar(expression[i]);
					count++;
				}
			}

			return calculate(operands, operators);
		}

		static double calculate(double[] operands, char[] operators) // Вычмслить
		{
			for (int i = 0; i < operators.Length; i++)
			{
				if (operators[i] == '/')
				{
					operands[i] = operands[i] / operands[i + 1];
					operands[i + 1] = 0;
				}
			}
			for (int i = 0; i < operators.Length; i++)
			{
				if (operators[i] == '*')
				{
					operands[i] = operands[i] * operands[i + 1];
					operands[i + 1] = 0;
				}
			}

            double result = operands[0];

			for (int i = 0; i < operators.Length; i++)
			{
				if (operators[i] == '+') result += operands[i + 1];
				else if (operators[i] == '-') result -= operands[i + 1];
			}

			return result;
		}
	}
}
