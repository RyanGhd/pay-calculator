// ReSharper disable UnusedMember.Global

using System.Runtime.InteropServices;
using Xunit;

namespace GenerateMonthlyPayslip.Services
{
    public class TaxCalculator_Tests
    {
        [Theory]
        [InlineData(1000, 0)]
        [InlineData(20000, 0)]
        [InlineData(20001, 0.1)]
        [InlineData(30000, 1000)]
        [InlineData(40000, 2000)]
        [InlineData(40001, 2000.2)]
        [InlineData(50000, 4000)]
        [InlineData(80000, 10000)]
        [InlineData(80001, 10000.3)]
        [InlineData(90000, 13000)]
        [InlineData(180000, 40000)]
        [InlineData(180001, 40000.4)]
        [InlineData(190000, 44000)]
        public void Service_calculates_the_tax(decimal income, decimal expectedTax)
        {
            // arrange 
            var sut = new TaxCalculator();

            //act 
            var tax = sut.Calculate(income);

            // assert
            Assert.Equal(expectedTax, tax);
        }
    }
}