using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Interpolation
{
    public class Polynomial
    {
        private static readonly Dictionary<int, string> powers = new Dictionary<int, string>
        {
            {1, ""},
            {2, "\u00B2"},
            {3, "\u00B3"},
            {4, "\u2074"},
            {5, "\u2075"},
            {6, "\u2076"},
            {7, "\u2077"},
            {8, "\u2078"},
            {9, "\u2079"}
        };
        
        public Dictionary<int, double> Coefficients { get; }
        
        public Polynomial(params double[] coefficients)
        {
            Coefficients = new Dictionary<int, double>();

            for (int i = 0; i < coefficients.Length; i++)
            {
                if (coefficients[i] == 0)
                    continue;
                Coefficients[i] = coefficients[i];
            }
        }

        public static Polynomial operator +(Polynomial that, Polynomial other)
        {
            var result = new Polynomial();
            foreach (var (key, value) in that.Coefficients)
            {
                result.Coefficients[key] = value;
            }

            foreach (var (key, value) in other.Coefficients)
            {
                if (result.Coefficients.ContainsKey(key))
                    result.Coefficients[key] += value;
                else
                    result.Coefficients[key] = value;
            }

            RemoveZeroes(result);

            return result;
        }

        public static Polynomial operator -(Polynomial that, Polynomial other)
        {
            return that + other * (-1);
        }

        public static Polynomial operator *(Polynomial that, Polynomial other)
        {
            var result = new Polynomial();
            foreach (var (thatKey, thatValue) in that.Coefficients)
            {
                foreach (var (otherKey, otherValue) in other.Coefficients)
                {
                    if (result.Coefficients.ContainsKey(thatKey + otherKey))
                        result.Coefficients[thatKey + otherKey] += thatValue * otherValue;
                    else
                        result.Coefficients[thatKey + otherKey] = thatValue * otherValue;
                }
            }

            RemoveZeroes(result);

            return result;
        }

        public static Polynomial operator /(Polynomial polynomial, double divisor)
        {
            if (divisor == 0)
                throw new DivideByZeroException("Divisor was zero");
            return polynomial * (1 / divisor);
        }

        public static implicit operator Polynomial(double constant)
        {
            return new Polynomial(constant);
        }

        public static implicit operator Polynomial(int constant)
        {
            return new Polynomial(constant);
        }

        public override string ToString()
        {
            RemoveZeroes(this);
            var stringBuilder = new StringBuilder();
            var isFirst = true;
            foreach (var (power, value) in Coefficients.Reverse())
            {
                var predicate = value < 0 || isFirst ? "" : "+";
                if (isFirst) isFirst = false;
                if (power == 0)
                {
                    stringBuilder.Append(predicate + value.ToString("F2"));
                }
                else
                {
                    stringBuilder.Append(predicate + value.ToString("F2") + "x" + (powers.ContainsKey(power) ? powers[power] : $"^{power}"));
                }
            }

            return stringBuilder.ToString();
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(this, obj))
                return true;
            return obj switch
            {
                null => false,
                Polynomial _ => GetHashCode() == obj.GetHashCode(),
                _ => false
            };
        }

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        private static void RemoveZeroes(Polynomial polynomial)
        {
            foreach (var pair in polynomial.Coefficients.Where(pair => Math.Round(pair.Value, 2) == 0))
            {
                polynomial.Coefficients.Remove(pair.Key);
            }
        }
    }
}