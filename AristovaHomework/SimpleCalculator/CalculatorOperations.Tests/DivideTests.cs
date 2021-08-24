using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using SimpleCalculator;

namespace CalculatorOperations.Tests
{
    public class DivideTests
    {
        [Fact]
        public void Divide_8_by_0()
        {
            Calculator calculator = new Calculator();

            Action act = () => calculator.Divide(8,0);

            var exception = Record.Exception(act).Message;

            Assert.Equal(new DivideByZeroException().Message, exception);
        }
        [Fact]
        public void Divide_8_by_2()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Divide(8, 2);

            Assert.Equal(4, result);
        }
        [Fact]
        public void Divide_24_by_7()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Divide(24, 7);
            var expected = (double)24/7;

            Assert.Equal(expected, result);
        }
    }
}
