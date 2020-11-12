using System;

namespace Interpolation
{
    public static class LagrangeMethod
    {
        public static Polynomial Evaluate(double[] x, double[] y)
        {
            var polynomial = new Polynomial();
            for (int i = 0; i < x.Length; i++)
            {
                polynomial += BasicPolynomial(x, i) * y[i];
            }
            return polynomial;
        }

        private static Polynomial BasicPolynomial(double[] array, int i)
        {
            Polynomial basicPolynomial = new Polynomial(1);

            for (int j = 0; j < array.Length; j++)
            {
                if (j != i)
                {
                    basicPolynomial *= new Polynomial(-array[j], 1) / (array[i] - array[j]);
                }
            }

            return basicPolynomial;
        }
    }
}