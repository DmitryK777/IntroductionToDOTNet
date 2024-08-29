//#define CONSTRUCTORS_CHECK
//#define ARITHMETICAL_OPERATORS
//#define COMPARISION_OPERATORS
#define HOME_WORK

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Program
	{
		static void Main(string[] args)
		{
#if CONSTRUCTORS_CHECK
			Fraction A = new Fraction();
			A.Print();

			Fraction B = new Fraction(5);
			B.Print();

			Fraction C = new Fraction(1, 2);
			C.Print();

			Fraction D = new Fraction(2, 3, 4);
			D.Print();
#endif

#if ARITHMETICAL_OPERATORS
			Fraction A = new Fraction(2, 3, 4);
			Fraction B = new Fraction(3, 4, 5);
			Fraction C = new Fraction(A * B);
			
			A.Print();
			B.Print();
			C.Print();
			(A / B).Print();
#endif

#if COMPARISION_OPERATORS
            Console.WriteLine(new Fraction(1, 2) == new Fraction(5, 10));
#endif

#if HOME_WORK
			Fraction A = new Fraction(2, 2, 7);
			Fraction B = new Fraction(5, 3, 4);
			Fraction C = new Fraction(A - B);
			Fraction D = new Fraction(B - A);

			C.Print();
			D.Print();

			Fraction I = new Fraction(2.75);
			I.Print();

			Console.WriteLine(I > A);
			Console.WriteLine(I > B);

			Fraction J = new Fraction(3, 2, 9);
			J--.Print();
#endif



		}
	}
}
