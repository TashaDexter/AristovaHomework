using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SimpleCalculator;

namespace CalculatorOperations.Tests
{
    public class MultiplyTests
    {
        [Fact]
        public void Multiply_4_by_9()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Multiply(4,9);

            Assert.Equal(36, result);

        }

    }
}
