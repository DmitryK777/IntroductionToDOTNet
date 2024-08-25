using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calc2
{
	internal class Program
	{
		static string expression;
		//22+33*44-55/11
		static void Main(string[] args)
		{
            Console.Write("Введите арифметическое выражение: ");
			//expression = Console.ReadLine();
			expression = "(22+33)*(77*(55-50))/11";
			Explore(expression);
			Console.WriteLine(Calculate(expression));
		}

		static void Explore(string expression)
		{
			/*
			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					for (int j = i + 1; j < expression.Length; j++)
					{
						if (expression[j] == ')')
						{
							expression = expression.Replace
								(
								expression.Substring(i, j-i+1), 
								Calculate(expression.Substring(i+1, j-i-1)).ToString()
								);
							Program.expression = expression;
							break;
						}
						if (expression[j] == '(')
						{
							Explore(expression.Substring(j));
							//Program.expression = expression;
						}
					}
				}
			}
			*/

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
						expression = expression.Replace
								(
								expression.Substring(open_bracket_position, close_bracket_position - open_bracket_position + 1),
								Calculate(expression.Substring(open_bracket_position + 1, close_bracket_position - open_bracket_position - 1)).ToString()
								);
						Program.expression = expression;
						break;
					}
					else
					{
						Console.WriteLine("Ошибка: нет открывающей скобки");
					}
				}
			}

			if (is_open_bracket && !is_close_bracket)
			{
				Console.WriteLine("Ошибка: нет закрывающей скобки");
			}

			for (int i = 0; i < expression.Length; i++)
			{
				if (expression[i] == '(')
				{
					Explore(expression);
				}
			}
		}

		static double Calculate(string expression)
		{
			Console.WriteLine(expression);
			char[] delimiters = new char[] { '+', '-', '*', '/' };

			string[] s_numbers = expression.Split(delimiters);
			for (int i = 0; i < s_numbers.Length; i++) Console.Write(s_numbers[i] + "\t");
			Console.WriteLine();


			double[] numbers = new double[s_numbers.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = Convert.ToDouble(s_numbers[i]);
				Console.Write(numbers[i] + "\t");
			}
			Console.WriteLine();

			string[] operators = expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', '.');
			for (int i = 0; i < operators.Length; i++) Console.Write(operators[i] + "\t");
			Console.WriteLine();
			operators = operators.Where(val => val != "").ToArray();
			for (int i = 0; i < operators.Length; i++) Console.Write(operators[i] + "\t");
			Console.WriteLine();


			////////////////////////////////////////////////
			for (int i = 0; i < operators.Length; i++)
			{
				while (operators[i] == "*" || operators[i] == "/")
				{
					if (operators[i] == "*") numbers[i] *= numbers[i + 1];
					if (operators[i] == "/") numbers[i] /= numbers[i + 1];
					ShiftLeft(numbers, i + 1);
					ShiftLeft(operators, i);
				}

			}
			Print(numbers);
			Print(operators);

			////////////////////////////////////////////////
			for (int i = 0; i < operators.Length; i++)
			{
				while (operators[i] == "+" || operators[i] == "-")
				{
					if (operators[i] == "+") numbers[i] += numbers[i + 1];
					if (operators[i] == "-") numbers[i] -= numbers[i + 1];
					ShiftLeft(numbers, i + 1);
					ShiftLeft(operators, i);
				}

			}
			Print(numbers);
			Print(operators);

			return numbers[0];
		}

		static void Print(double[] arr)
		{
			for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + "\t");
            Console.WriteLine();
        }

		static void Print(string[] arr)
		{
			for (int i = 0; i < arr.Length; i++) Console.Write(arr[i] + "\t");
			Console.WriteLine();
		}

		static double[] ShiftLeft(double[] arr, int index = 0)
		{
			for (int i = index; i < arr.Length-1; i++)
			{
				arr[i] = arr[i+1];
			}
			arr[arr.Length - 1] = 0;
			return arr;
		}

		static string[] ShiftLeft(string[] arr, int index = 0)
		{
			for (int i = index; i < arr.Length-1; i++)
			{
				arr[i] = arr[i + 1];
			}
			arr[arr.Length - 1] = null;
			return arr;
		}
		
	}
}
