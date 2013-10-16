using NUnit.Framework;

namespace Calculator.Separation.Tests
{
    [TestFixture]
    public class CalculatorFixture
    {
        [TestCase(Operations.Addition, 0d, 0d, 0d)]
        [TestCase(Operations.Addition, 10d, 10d, 20d)]
        [TestCase(Operations.Subtraction, 1d, 1d, 0d)]
        [TestCase(Operations.Subtraction, 0d, 0d, 0d)]
        [TestCase(Operations.Multiplication, -1d, -1d, 1d)]
        [TestCase(Operations.Multiplication, 3d, 5d, 15d)]
        [TestCase(Operations.Division, -1d, -1d, 1d)]
        [TestCase(Operations.Division, 3d, 3d, 1d)]
        [TestCase(Operations.Equal, 3d, 3d, 3d)]
        [TestCase(Operations.Equal, 0d, 0d, 0d)]
        [TestCase(Operations.Equal, 25d, 0d, 25d)]
        public void ComputeTest(Operations operation, double first, double second, double expected)
        {
            var actual = Calculator.Compute(operation, first, second);

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
