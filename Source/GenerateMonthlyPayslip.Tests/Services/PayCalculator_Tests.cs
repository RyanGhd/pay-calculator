// ReSharper disable UnusedMember.Global

using System.Runtime.CompilerServices;
using Moq;
using Xunit;

namespace GenerateMonthlyPayslip.Services
{
    public class PayCalculator_Tests
    {
        private readonly PayCalculatorTestFixture _fixture = new PayCalculatorTestFixture();

        [Theory]
        [InlineData(1000, 0, 83.33, 0, 83.33)]
        [InlineData(20000, 0, 1666.67, 0, 1666.67)]
        [InlineData(20001, 0.1, 1666.75, 0.01, 1666.74)]
        [InlineData(30000, 1000, 2500, 83.33, 2416.67)]
        [InlineData(40000, 2000, 3333.33, 166.67, 3166.66)]
        [InlineData(40001, 2000.2, 3333.42, 166.68, 3166.74)]
        [InlineData(50000, 4000, 4166.67, 333.33, 3833.34)]
        [InlineData(80000, 10000, 6666.67, 833.33, 5833.34)]
        [InlineData(80001, 10000.3, 6666.75, 833.36, 5833.39)]
        [InlineData(90000, 13000, 7500, 1083.33, 6416.67)]
        [InlineData(180000, 40000, 15000, 3333.33, 11666.67)]
        [InlineData(180001, 40000.4, 15000.08, 3333.37, 11666.71)]
        [InlineData(190000, 44000, 15833.33, 3666.67, 12166.66)]
        public void Service_calculates_the_payslip_correctly(decimal annualSalary, decimal annualTax, decimal expectedGrossMonthlyIncome, decimal expectedMonthlyTax, decimal expectedNetMonthlyIncome)
        {
            // arrange 
            var sut = _fixture.Start().WithTaxResult(annualTax).Build();

            // act 
            var payslip = sut.Calculate("x", annualSalary);

            // assert
            Assert.Equal("x", payslip.EmployeeName);
            Assert.Equal(expectedGrossMonthlyIncome, payslip.GrossMonthlyIncome);
            Assert.Equal(expectedMonthlyTax, payslip.MonthlyTax);
            Assert.Equal(expectedNetMonthlyIncome, payslip.NetMonthlyIncome);
        }
    }
}