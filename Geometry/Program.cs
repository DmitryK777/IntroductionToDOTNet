#define SQUARE
#define UP_RECTANGULAR_TRIANGLE
#define DOWN_RECTANGULAR_TRIANGLE
#define DOWN_EQUILATERAL_TRIANGLE
#define UP_EQUILATERAL_TRIANGLE
#define RHOMBUS
#define PLUS_MINUS

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Geometry
{
	internal class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Введите размер фигуры: ");
			int n = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine();

#if SQUARE
            Console.WriteLine("SQUARE:");
            for (int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++) Console.Write("* ");
				Console.WriteLine();
			}
			Console.WriteLine();
#endif

#if UP_RECTANGULAR_TRIANGLE
			Console.WriteLine("UP_RECTANGULAR_TRIANGLE:");
			for (int i = 1; i <= n; i++) 
			{
				for (int j = 1; j <= i; j++) Console.Write("* ");
                Console.WriteLine();
            }
			Console.WriteLine();
#endif

#if DOWN_RECTANGULAR_TRIANGLE
            Console.WriteLine("DOWN_RECTANGULAR_TRIANGLE");
            for (int i = 0; i < n; i++)
			{
				for (int j = i; j < n; j++) Console.Write("* ");
				Console.WriteLine();
			}
			Console.WriteLine();
#endif

#if DOWN_EQUILATERAL_TRIANGLE
            Console.WriteLine("DOWN_EQUILATERAL_TRIANGLE:");
			for(int i = 0; i < n; i++)
			{
				for (int j = 0; j < i; j++) Console.Write(" ");
				for (int j = i; j < n; j++) Console.Write("* ");
                Console.WriteLine();
            }
            Console.WriteLine();
#endif

#if UP_EQUILATERAL_TRIANGLE
			Console.WriteLine("UP_EQUILATERAL_TRIANGLE:");
			for (int i = 0; i < n; i++)
			{
				for (int j = i; j < n; j++) Console.Write(" ");
				for (int j = 0; j < (i + 1); j++) Console.Write("* ");
				Console.WriteLine();
			}
			Console.WriteLine();
#endif

#if RHOMBUS
            Console.WriteLine("RHOMBUS: ");
			for (int i = 0; i < n; ++i) 
			{ 
				for(int j = i; j < n; j++) Console.Write(" "); Console.Write("/");
				for(int j = 0; j < i; j++) Console.Write("  "); Console.Write("\\");
                Console.WriteLine();
            }
			for (int i = 0; i < n; ++i)
			{
				for (int j = 0; j < (i + 1); j++) Console.Write(" "); Console.Write("\\");
				for (int j = i; j < (n - 1); j++) Console.Write("  "); Console.Write("/");
				Console.WriteLine();
			}
            Console.WriteLine();
#endif

#if PLUS_MINUS
            Console.WriteLine("PLUS_MINUS:");
			for(int i = 0; i < n; i++)
			{
				for (int j = 0; j < n; j++) Console.Write(i % 2 == j % 2 ? "+ " : "- ");
                Console.WriteLine();
            }
			Console.WriteLine();
#endif
        }
	}
}
