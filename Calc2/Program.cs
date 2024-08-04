﻿using System;
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
			expression = "22+33*44-55/11";
			Console.WriteLine(expression);

			char[] delimiters = new char[] { '+', '-', '*', '/' };

			string[] s_numbers = expression.Split(delimiters);
			Print(s_numbers);
            

			double[] numbers = new double[s_numbers.Length];
			for (int i = 0; i < numbers.Length; i++)
			{
				numbers[i] = Convert.ToDouble(s_numbers[i]);
                Console.Write(numbers[i] + "\t");
            }
            Console.WriteLine();

			string[] operators =  expression.Split('0', '1', '2', '3', '4', '5', '6', '7', '8', '9', ' ', '.');
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
