using NUnit.Framework;
using Interpolation;

namespace Tests
{
    [TestFixture]
    public class NewtonMethodTests
    {
        [Test]
        public void IsNewtonMethodCorrect()
        {
            Assert.That(NewtonMethod.Evaluate(new[] {0d, 2, 3}, new[] {1d, 2, 1}),
                Is.EqualTo(new Polynomial(0, 1.5, -0.5)));
            Assert.That(NewtonMethod.Evaluate(new [] {-1, 0, 0.5, 1}, new [] {0, 2, 9d/8, 0}),
                Is.EqualTo(new Polynomial(2, -1, -2, 1)));
            Assert.That(NewtonMethod.Evaluate(new []{-2d, 0, 1}, new []{-4d, -1, -3}),
                Is.EqualTo(new Polynomial(11, -5d/6, -7d/6)));
        }
    }
}