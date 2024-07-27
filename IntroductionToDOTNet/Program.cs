﻿#define CONSOLE_PARAMETERS
//#define INPUT_DATA
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNet
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Title = "Introduction to .NET";
#if CONSOLE_PARAMETERS
			Console.Beep(700, 500);
			Console.BackgroundColor = ConsoleColor.DarkBlue;
			//Console.CursorLeft = 22;
			//Console.CursorTop = 11;
			Console.SetCursorPosition(22, 7);
			Console.Write("Hello .NET\n"); // Выводит строку на экран
			Console.WriteLine("Introduction"); // Выводит строку на экран и переводит курсор в начало следующей строки
			Console.BackgroundColor = ConsoleColor.Green;
			Console.ResetColor();
			//Console.Clear();
#endif

#if INPUT_DATA
			Console.Write("Введите ваше имя: ");
			string first_name = Console.ReadLine();
			Console.Write("Введите вашу фамилию: ");
			string last_name = Console.ReadLine();
			Console.Write("Введите ваш возраст: ");
			int age = Convert.ToInt32(Console.ReadLine());

			Console.WriteLine("Ваше имя: " + first_name + ", Ваша фамилия: " + last_name + ", Ваш возраст: " + age); // Конкатенация строк
            Console.WriteLine(string.Format("Ваше имя: {0}, Ваша фамилия: {1}, Ваш возраст: {2}", first_name, last_name, age)); // Форматирование строк
			Console.WriteLine($"Ваше имя: {first_name}, Ваша фамилия: {last_name}, Ваш возраст: {age}"); // Интерполяция строк
#endif


        }
	}
}
