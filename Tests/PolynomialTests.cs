using System;
using NUnit.Framework;
using Interpolation;

namespace Tests
{
    public class PolynomialTests
    {
        [Test]
        [TestCaseSource(typeof(PolynomialGenerator), nameof(PolynomialGenerator.TestCasesForSum))]
        public void IsSumCorrect(Polynomial p1, Polynomial p2, Polynomial expected)
        {
            Assert.That(p1 + p2, Is.EqualTo(expected));
        }

        [Test]
        [TestCaseSource(typeof(PolynomialGenerator), nameof(PolynomialGenerator.TestCasesForProduct))]
        public void IsProductCorrect(Polynomial p1, Polynomial p2, Polynomial expected)
        {
            Assert.That(p1 * p2, Is.EqualTo(expected));
        }
        
        [Test]
        [TestCaseSource(typeof(PolynomialGenerator), nameof(PolynomialGenerator.TestCasesForDivisionByNumber))]
        public void IsDivisionByNumberCorrect(Polynomial polynomial, double divisor, Polynomial expected)
        {
            Assert.That(polynomial / divisor, Is.EqualTo(expected));
        }

        [Test]
        public void IsDivisionByZeroThrowsException()
        {
            Assert.Throws<DivideByZeroException>(() =>
            {
                var _ = new Polynomial(1, 2, 3) / 0;
            });
        }
    }
    
    public class PolynomialGenerator
        {
            public static object[] TestCasesForSum =
            {
                new object[] {new Polynomial(1, 2, 3), new Polynomial(2, 4, 6), new Polynomial(3, 6, 9)},
                new object[] {new Polynomial(-10, -5, -3), new Polynomial(5, 2, 1), new Polynomial(-5, -3, -2),},
                new object[] {new Polynomial(), new Polynomial(1, 2, 3), new Polynomial(1, 2, 3)},
                new object[] {new Polynomial(1.5, 2.5, 3.5), new Polynomial(2, 5, 7), new Polynomial(3.5, 7.5, 10.5)}
            };

            public static object[] TestCasesForProduct =
            {
                new object[] {new Polynomial(1, 2, 3), new Polynomial(2, 4, 6), new Polynomial(2, 8, 20, 24, 18),},
                new object[]
                    {new Polynomial(-10, -5, -3), new Polynomial(5, 2, 1), new Polynomial(-50, -45, -35, -11, -3),},
                new object[] {new Polynomial(), new Polynomial(1, 2, 3), new Polynomial()},
                new object[]
                    {new Polynomial(1.5, 2.5, 3.5), new Polynomial(2, 5, 7), new Polynomial(3, 12.5, 30, 35, 24.5)}
            };

            public static object[] TestCasesForDivisionByNumber =
            {
                new object[] {new Polynomial(2, 10, 100), 2, new Polynomial(1, 5, 50),},
                new object[] {new Polynomial(43, -100, 65, 0), 10, new Polynomial(4.3, -10, 6.5, 0)}
            };
        }
    }