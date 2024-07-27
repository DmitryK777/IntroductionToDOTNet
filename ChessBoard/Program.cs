using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChessBoard
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.OutputEncoding = System.Text.Encoding.UTF8;
			Console.InputEncoding = System.Text.Encoding.UTF8;


			const char UPPER_LEFT_ANGLE = (char)0x250C;
			const char UPPER_RIGHT_ANGLE = (char)0x2510;
			const char LOWER_LEFT_ANGLE = (char)0x2514;
			const char LOWER_RIGHT_ANGLE = (char)0x2518;
			const char HORIZONTAL_LINE = (char)0x2500;
			const char VERTICAL_LINE = (char)0x2502;
			const char WHITE_BOX = (char)0x25A0;
			const char BLACK_BOX = (char)0x25A1;
			

			Console.Write("Введите размер доски: ");
			int n = Convert.ToInt32(Console.ReadLine());
			n++;
			Console.WriteLine();

			for (int i = 0; i <= n; i++)
			{
				for (int j = 0; j <= n; j++)
				{
					if (i == 0 && j == 0) Console.Write(UPPER_LEFT_ANGLE);
					else if (i == 0 && j == n) Console.Write(UPPER_RIGHT_ANGLE);
					else if (i == n && j == 0) Console.Write(LOWER_LEFT_ANGLE);
					else if (i == n && j == n) Console.Write(LOWER_RIGHT_ANGLE);
					else if (i == 0 || i == n) Console.Write(HORIZONTAL_LINE);
					else if (j == 0 || j == n) Console.Write(VERTICAL_LINE);
					else Console.Write(i % 2 == j % 2 ? WHITE_BOX : BLACK_BOX);
				}
				Console.WriteLine();
			}
		}
	}
}
