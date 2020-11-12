using System;

namespace Interpolation
{
    public static class NewtonMethod
    {
        public static Polynomial Evaluate(double[] x, double[] y)
        {
            return ConstructPolynomial(x, EvaluateDividedDifferences(x, y));
        }

        private static double[][] EvaluateDividedDifferences(double[] x, double[] y)
        {
            var deltas = new double[x.Length][];
            deltas[0] = y;
            for (int i = 1, step = 1; i < deltas.Length; i++, step++)
            {
                deltas[i] = new double[deltas[i - 1].Length - 1];
                for (int j = 0; j < deltas[i].Length; j++)
                {
                    deltas[i][j] = (deltas[i - 1][j] - deltas[i - 1][j + 1]) / (x[j] - x[j + step]);
                }
            }

            return deltas;
        }

        private static Polynomial ConstructPolynomial(double[] x, double[][] dividedDifferences)
        {
            var polynomial = new Polynomial();
            for (int i = 0; i < dividedDifferences.Length; i++)
            {
                if (i == 0)
                {
                    polynomial += dividedDifferences[i][0];
                }
                else
                {
                    var addablePolynomial = new Polynomial(dividedDifferences[i][0]);
                    for (int j = 0; j < i; j++)
                    {
                        addablePolynomial *= new Polynomial(-x[j], 1);
                    }

                    polynomial += addablePolynomial;
                }
            }

            return polynomial;
        }
    }
}