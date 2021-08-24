using System;
using Xunit;
using SimpleCalculator;

namespace CalculatorOperations.Tests
{
    public class AddTests
    {
            [Fact]
            public void Add_5_and_2()
            {
                Calculator calculator = new Calculator();

                var result = calculator.Add(5, 2);

                Assert.Equal(7, result);
            }
       
    }
}
