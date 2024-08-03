//#define CONSOLE_PARAMETERS
//#define INPUT_DATA
//#define DATA_TYPES
//#define LITERALS
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IntroductionToDOTNet
{
	internal class Program
	{
		static readonly string delimeter = "---------------------------------------------------\n";
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

#if DATA_TYPES
            /*
            Console.WriteLine("CHAR");
            Console.WriteLine(sizeof(char));
            Console.WriteLine((int)char.MinValue);
            Console.WriteLine((int)char.MaxValue);
            Console.WriteLine();
			*/

            Console.WriteLine("SHORT");
			/*
            Console.WriteLine(sizeof(short));
           
            Console.WriteLine($"{short.MinValue} ... {short.MaxValue}");

			Console.WriteLine(sizeof(ushort));
			Console.WriteLine($"{ushort.MinValue} ... {ushort.MaxValue}");
			*/

            Console.WriteLine($"Переменная типа  'short' занимает {sizeof(short)} байт памяти\n" +
				$"и принимает значения в диапазоне\n " +
				$"ushort: от {ushort.MinValue} до {ushort.MaxValue}\n" +
				$"short: от {short.MinValue} до {short.MaxValue}");
			Console.WriteLine($"Класс-обвёртка: 'Int32'");
			Console.WriteLine(delimeter);

			Console.WriteLine($"Переменная типа  'int' занимает {sizeof(int)} байт памяти\n" +
				$"и принимает значения в диапазоне\n " +
				$"uint: от {uint.MinValue} до {uint.MaxValue}\n" +
				$"int: от {int.MinValue} до {int.MaxValue}");

            Console.WriteLine(delimeter);
			

			Console.WriteLine($"Переменная типа  'long' занимает {sizeof(long)} байт памяти\n" +
				$"и принимает значения в диапазоне\n " +
				$"ulong: от {ulong.MinValue} до {ulong.MaxValue}\n" +
				$"long: от {long.MinValue} до {long.MaxValue}");

			Console.WriteLine(delimeter);



			Console.WriteLine($"Переменная типа  'float' занимает {sizeof(float)} байт памяти\n" +
				$"и принимает значения в диапазоне\n " +
				$"float: от {float.MinValue} до {float.MaxValue}\n");

			Console.WriteLine(delimeter);

			Console.WriteLine($"Переменная типа  'double' занимает {sizeof(double)} байт памяти\n" +
				$"и принимает значения в диапазоне\n " +
				$"double: от {double.MinValue} до {double.MaxValue}\n");
            Console.WriteLine($"минимальное положительное значение double: {double.Epsilon}");

            Console.WriteLine(delimeter);


			Console.WriteLine($"Переменная типа  'decimal' занимает {sizeof(decimal)} байт памяти\n" +
				$"и принимает значения в диапазоне\n " +
				$"decimal: от {decimal.MinValue} до {decimal.MaxValue}\n");
			
			Console.WriteLine(delimeter);

#endif

#if LITERALS
            Console.WriteLine(((object)5.0m).GetType());
            //Console.WriteLine(Int16.MaxValue);

            Console.WriteLine("+".GetType());

#endif
			
			int a = 2_000_000_000;
			int b = 5;

            /*
			a = (short)b; // CS0266
			b = a;
			uint c = (uint)b; 
			Console.WriteLine(c);
			*/

            Console.WriteLine((a*b));
            Console.WriteLine((a*b).GetType());
        }
	}
}
