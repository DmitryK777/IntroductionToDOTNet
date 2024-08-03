using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
	internal class Program
	{
		static void Main(string[] args)
		{

            Console.Write("Введите выражение: ");
			string expression = Console.ReadLine();

			char[] operators = { '+', '-', '*', '/' };
			string[] operands = expression.Split(operators);

			double first_operand = Convert.ToDouble(operands[0]); 
			double second_operand = Convert.ToDouble(operands[1]);

			double result = 0;

			if (expression.Contains('+')) result = first_operand + second_operand;
			else if (expression.Contains('-')) result = first_operand - second_operand;
			else if (expression.Contains('*')) result = first_operand * second_operand;
			else if (expression.Contains('/')) result = first_operand / second_operand;

			Console.WriteLine($"Результат вычисления: {result}");
            Console.WriteLine();



        }
	}
}
