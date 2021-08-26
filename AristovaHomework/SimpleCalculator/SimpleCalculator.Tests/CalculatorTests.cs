using System;
using Xunit;


namespace SimpleCalculator.Tests
{
    public class CalculatorTests
    {
        [Fact] 
        public void Add_5_and_2()            
        {             
            Calculator calculator = new Calculator(); 
            var result = calculator.Add(5, 2);
            Assert.Equal(7, result);
        }

        [Fact]
        public void Subtract_from_14_6()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Subtract(14, 6);

            Assert.Equal(8, result);
        }

        [Fact]
        public void Multiply_4_by_9()
        {
            Calculator calculator = new Calculator();

            var result = calculator.Multiply(4, 9);

            Assert.Equal(36, result);
        }

        [Fact]
        public void Divide_8_by_0()
        {
            Calculator calculator = new Calculator();

            Action act = () => calculator.Divide(8, 0);

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
            var expected = (double)24 / 7;

            Assert.Equal(expected, result);
        }
    }
}
