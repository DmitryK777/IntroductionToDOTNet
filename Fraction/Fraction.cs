using System;
using System.Collections.Generic;
using System.Linq;
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
			Denominator = 1;
            Console.WriteLine($"DefaultConstructor:\t {this.GetHashCode()}");
        }

		public Fraction(int integer)
		{
			Integer = integer;
			Denominator = 1;
			Console.WriteLine($"ConstructorOfInteger:\t {this.GetHashCode()}");
		}

		public Fraction(int numerator, int denominator)
		{
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
		public static Fraction operator*(Fraction left, Fraction right)
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

		public static Fraction operator/(Fraction left, Fraction right)
		{ 
			return left * right.Inverted();
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


		// Methods
		public Fraction ToProper()
		{
			//Integer += Numerator / Denominator;
			//Numerator %= Denominator;
			//return this;
			Fraction proper = new Fraction();
			proper.Integer += Numerator / Denominator;
			proper.Numerator = Numerator % Denominator;
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
