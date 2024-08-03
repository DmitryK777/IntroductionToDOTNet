using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace MoveSquare
{
	internal class Program
	{
		[DllImport("msvcrt")]
		static extern int _getch();

		static void reset_screen()
		{
			Console.ResetColor();
			Console.Clear();
			Console.BackgroundColor = ConsoleColor.Magenta;
		}

		static void change_cursor_position(int position_X, int position_Y)
		{
			Console.SetCursorPosition(position_X, position_Y);
			Console.WriteLine("  ");
		}

		static void Main(string[] args)
		{
			const char forword = (char)119;
			const char FORWORD = (char)87;
			const char ru_forword = (char)0xD186;
			const char RU_FORWORD = (char)0xD0A6;

			const char back = (char)115;
			const char BACK = (char)83;
			const char ru_back = (char)0xD18B;
			const char RU_BACK = (char)0xD0AB;

			const char left = (char)97;
			const char LEFT = (char)65;
			const char ru_left = (char)0xD184;
			const char RU_LEFT = (char)0xD0A4;

			const char right = (char)100;
			const char RIGHT = (char)68;
			const char ru_right = (char)0xD0B2;
			const char RU_RIGHT = (char)0xD092;

			const char upArrow = (char)72;
			const char downArrow = (char)80;
			const char leftArrow = (char)75;
			const char rightArrow = (char)77;

			const char ESCAPE = (char)27;

			const int X_MIN = 0;
			const int X_MAX = 118;
			const int Y_MIN = 0;
			const int Y_MAX = 28;

			int position_X = 15;
			int position_Y = 15;

			char instruction;

			Console.WriteLine("Двигайте квадратик стрелками,\n" +
				"или клавишами:\n" +
				"\"W\" - вверх,\n" +
				"\"S\" - вниз,\n" +
				"\"A\" - влево,\n" +
				"\"D\" - вправо\n\n" +
				"ESC - Выход.");

			Console.BackgroundColor = ConsoleColor.Magenta;
			Console.SetCursorPosition(position_X, position_Y);
			Console.WriteLine("  ");
			
			do
			{
				instruction = (char)_getch();
				switch (instruction) 
				{
					case forword: case FORWORD: case ru_forword: case RU_FORWORD: case upArrow:
						if (position_Y > Y_MIN) 
						{
							reset_screen();
							change_cursor_position(position_X, --position_Y);
						}
						break;

					case back: case BACK: case ru_back: case RU_BACK: case downArrow:
						if (position_Y < Y_MAX)
						{
							reset_screen();
							change_cursor_position(position_X, ++position_Y);
						}
					    break;

					case left: case LEFT: case ru_left: case RU_LEFT: case leftArrow: if (position_X > X_MIN)
						{
							reset_screen();
							change_cursor_position(--position_X, position_Y);
						}
						break;

					case right: case RIGHT: case ru_right: case RU_RIGHT: case rightArrow:
						if (position_X < X_MAX)
						{
							reset_screen();
							change_cursor_position(++position_X, position_Y);
						}
						break;
										
					case ESCAPE:
						Console.ResetColor();
						Console.WriteLine("Exit");
						break;
					
					default:
						Console.ResetColor();
						Console.WriteLine("ERROR");
						break;
				}
			} while (instruction != ESCAPE);

			Console.ResetColor();
		}
	}
}
