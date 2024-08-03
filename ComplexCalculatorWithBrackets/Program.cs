using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ComplexCalculatorWithBrackets
{
	internal class Program
	{
		static void Main()
		{
			Console.Write("Введите выражение: ");
			string expression = Console.ReadLine();
			Console.WriteLine($"{expression} = {process_expression(expression)}");
		}

		static double process_expression(string expression) // Обработать выражение
		{
			bool is_open_bracket = false;
			int open_bracket_position = -1;

			bool is_close_bracket = false;
			int close_bracket_position = -1;

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					is_open_bracket = true;
					open_bracket_position = i;
				}

				if (expression[i] == ')')
				{
					if (is_open_bracket)
					{
						is_close_bracket = true;
						close_bracket_position = i;

						/*
						string substring_for_calculate = expression.Substring(open_bracket_position + 1, close_bracket_position - open_bracket_position - 1);
						double intermediate_calculation = arrange_expression(substring_for_calculate);
						string new_substring = Convert.ToString(intermediate_calculation);
                        expression = expression.Remove(open_bracket_position, close_bracket_position - open_bracket_position +1);
                        expression = expression.Insert(open_bracket_position, new_substring);
						*/

						expression = expression.Replace(expression.Substring(open_bracket_position, close_bracket_position - open_bracket_position + 1), Convert.ToString(arrange_expression(expression.Substring(open_bracket_position + 1, close_bracket_position - open_bracket_position - 1))));

						break;
					}
					else
					{
                        Console.WriteLine("Ошибка: нет открывающей скобки");
						return 0;
					} 
				}
			}
			if (is_open_bracket && !is_close_bracket)
			{
                Console.WriteLine("Ошибка: нет закрывающей скобки");
				return 0;
			}

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					expression = Convert.ToString(process_expression(expression));
				}
			}

			return arrange_expression(expression);
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

		static double calculate(double[] operands, char[] operators) // Вычислить
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
