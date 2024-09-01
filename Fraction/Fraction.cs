using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;

namespace Fraction
{
	internal class Fraction
	{
		public int Integer { get; set; }
		public int Numerator { get; set; }
		int denominator;
		public int Denominator
		{
			get => denominator;
			set
			{
				if (value == 0) value = 1;
				denominator = value;
			}
		}

		public Fraction()
		{
			Integer = 0;
			Numerator = 0;
			Denominator = 1;
            Console.WriteLine($"DefaultConstructor:\t {this.GetHashCode()}");
        }

		public Fraction(int integer)
		{
			Integer = integer;
			Numerator = 0;
			Denominator = 1;
			Console.WriteLine($"ConstructorOfInteger:\t {this.GetHashCode()}");
		}

		public Fraction(double number)
		{
			number += 1e-10;
			Integer = (int)number;
			Denominator = (int)1e+9;
			number -= Integer;
			Numerator = (int)(number * Denominator);
			Reduce();
		}

		public Fraction(int numerator, int denominator)
		{
			Integer = 0;
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"ConstructorOfWithoutInteger:\t {this.GetHashCode()}");
		}

		public Fraction(int integer, int numerator, int denominator)
		{
			Integer = integer;
			Numerator = numerator;
			Denominator = denominator;
			Console.WriteLine($"ConstructorOfFullFraction:\t {this.GetHashCode()}");
		}

		public Fraction(Fraction other)
		{
			this.Integer = other.Integer;
			this.Numerator = other.Numerator;
			this.Denominator = other.Denominator;
			Console.WriteLine($"CopyConstructor:\t {this.GetHashCode()}");
		}

		~Fraction()
		{
			Console.WriteLine($"Destructor:\t {this.GetHashCode()}");
		}

		// Arithmetical Operators
		public static Fraction operator *(Fraction left, Fraction right)
		{
			/*
			Fraction left_copy = new Fraction(left);
			Fraction right_copy = new Fraction(right);
			left_copy.ToImproper();
			right_copy.ToImproper();
			*/
			/*
			Fraction left_copy = left.ToImproper();
			Fraction right_copy = right.ToImproper();
			return new Fraction
				(
					left_copy.Numerator * right_copy.Numerator,
					left_copy.Denominator * right_copy.Denominator
				).ToProper();
			*/
			return new Fraction
				(
					left.ToImproper().Numerator * right.ToImproper().Numerator,
					left.ToImproper().Denominator * right.ToImproper().Denominator
				);
		}

		public static Fraction operator /(Fraction left, Fraction right)
		{ 
			return left * right.Inverted();
		}

		public static Fraction operator +(Fraction left, Fraction right)
		{
			return new Fraction
				(
					left.ToImproper().Numerator * right.ToImproper().Denominator + left.ToImproper().Denominator * right.ToImproper().Numerator,
					left.ToImproper().Denominator * right.ToImproper().Denominator
				).ToProper().Reduce();
		}

		public static Fraction operator -(Fraction left, Fraction right)
		{
			return new Fraction
				(
					left.ToImproper().Numerator * right.ToImproper().Denominator - left.ToImproper().Denominator * right.ToImproper().Numerator,
					left.ToImproper().Denominator * right.ToImproper().Denominator
				).ToProper().Reduce();
		}

		public static Fraction operator ++(Fraction fraction)
		{

			if (fraction.Integer == 0 && fraction.Numerator < 0)
			{
				fraction.Numerator += fraction.Denominator;
			}
			else fraction.Integer++;

			return fraction;
		}

		public static Fraction operator --(Fraction fraction)
		{
			if (fraction.Integer == 0 && fraction.Numerator > 0)
			{
				fraction.Numerator -= fraction.Denominator;
			}
			else if (fraction.Integer == 0 && fraction.Numerator < 0)
			{
				fraction.Integer--;
				fraction.Numerator *= -1;
			}
			else fraction.Integer--;

			return fraction;
		}

		// Comparison Operators
		public static bool operator ==(Fraction left, Fraction right)
		{
			return left.ToImproper().Numerator * right.ToImproper().Denominator == left.ToImproper().Denominator * right.ToImproper().Numerator;
		}
		public static bool operator !=(Fraction left, Fraction right)
		{
			return !(left == right);
		}

		public static bool operator >(Fraction left, Fraction right)
		{
			return left.ToImproper().Numerator * right.ToImproper().Denominator > right.ToImproper().Numerator * left.ToImproper().Denominator;
		}

		public static bool operator <(Fraction left, Fraction right)
		{
			return left.ToImproper().Numerator * right.ToImproper().Denominator < right.ToImproper().Numerator * left.ToImproper().Denominator;
		}

		public static bool operator >=(Fraction left, Fraction right)
		{
			return !(left < right);
		}

		public static bool operator <=(Fraction left, Fraction right)
		{
			return !(left > right);
		}

		// Methods
		public Fraction ToProper()
		{
			//Integer += Numerator / Denominator;
			//Numerator %= Denominator;
			//return this;
			Fraction proper = new Fraction();
			proper.Integer += Numerator / Denominator;
			proper.Numerator = Math.Abs(Numerator % Denominator);
			proper.Denominator = Denominator;
			return proper;
		}
		public Fraction ToImproper()
		{
			//Numerator += Integer * Denominator;
			//Integer = 0;
			//return this;
			return new Fraction(Numerator + Integer * Denominator, Denominator);
		}
		public Fraction Inverted()
		{
			//Fraction inverted = new Fraction(this);
			//inverted.ToImproper();
			Fraction inverted = ToImproper();
			(inverted.Numerator, inverted.Denominator) = (inverted.Denominator, inverted.Numerator);
			
			return inverted;
		}

		public Fraction Reduce()
		{
			int more, less, rest;
			if (Math.Abs(Numerator) > Math.Abs(Denominator)) { more = Math.Abs(Numerator); less = Math.Abs(denominator); }
            else { more = Math.Abs(Denominator); less = Math.Abs(Numerator); }
			do
			{
				rest = more % less;
				more = less;
				less = rest;
			} while (rest != 0);
			int GCD = more; // Greatest Common Divisior
			Numerator /= GCD;
			Denominator /= GCD;
			return this;
        }

		public void Print()
		{
			if (Integer != 0) Console.Write(Integer);
			if (Numerator != 0)
			{
				if (Integer != 0) Console.Write("(");
				Console.Write($"{Numerator}/{Denominator}");
				if (Integer != 0) Console.Write(")");
			}
			else if (Numerator == 0 && Integer == 0) Console.WriteLine(0);
            Console.WriteLine();
        }
	}
}
