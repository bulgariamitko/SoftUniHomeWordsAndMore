using System;

namespace _02FractionCalculator
{
    public struct Fraction
    {
        private long numerator;
        private long denominator;

        public long Numerator
        {
            get { return numerator; }
            set { numerator = value; }
        }

        public long Denominator
        {
            get { return denominator; }
            set
            {
                if (value == 0)
                {
                    throw new ArgumentException("The denominator cannot be 0!");
                }
                denominator = value;
            }
        }

        public Fraction(long numerator, long denominator) : this()
        {
            this.Numerator = numerator;
            this.Denominator = denominator;
        }

        public static Fraction operator+(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            result.numerator = fraction1.numerator*fraction2.denominator + fraction2.numerator*fraction1.denominator;
            result.denominator = fraction1.denominator*fraction2.denominator;
            return result;
        }

        public static Fraction operator -(Fraction fraction1, Fraction fraction2)
        {
            Fraction result = new Fraction();
            result.numerator = fraction1.numerator * fraction2.denominator - fraction2.numerator * fraction1.denominator;
            result.denominator = fraction1.denominator * fraction2.denominator;
            return result;
        }

        public override string ToString()
        {
            return ((decimal) this.numerator/(decimal) this.denominator).ToString();
        }
    }
}