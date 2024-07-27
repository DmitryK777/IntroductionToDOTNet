using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HardChess
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер доски: ");
			int n = Convert.ToInt32(Console.ReadLine());
			Console.WriteLine();

			for (int i = 0; i < n*n; i++)
			{
				for (int j = 0; j < n*n; j++)
				{
					//Console.Write((i / n % 2 == j / n % 2) ? "* " : "  ");
					Console.Write(i / n % 2 == j / n % 2 ? "* " : "  ");
				}
				Console.WriteLine();
			}
            Console.WriteLine();
        }
	}
}
