using System;
using System.Collections.Generic;
using System.Text;
using SimpleCalculator;
using Xunit;

namespace CalculatorOperations.Tests
{
    public class SubtractTests
    {
        [Fact]
        public void Subtract_from_14_6()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Subtract(14, 6);

            Assert.Equal(8, result);
        }
    }
}
