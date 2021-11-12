// ReSharper disable UnusedMember.Global

using System.Data;
using System.Text;
using GenerateMonthlyPayslip.DomainModel.Objects;
using Xunit;

namespace GenerateMonthlyPayslip.DomainModel
{
    public class Payslip_Tests
    {
        [Fact]
        public void Object_prints_expected_result()
        {
            // arrange 
            var objectUnderTest = new Payslip("Mary Song", 5000, 500, 4500);
            var expectedResult = new StringBuilder()
                                        .AppendLine("Monthly Payslip for: \"Mary Song\"")
                                        .AppendLine("Gross Monthly Income: $5,000.00")
                                        .AppendLine("Monthly Income Tax: $500.00")
                                        .AppendLine("Net Monthly Income: $4,500.00")
                                        .ToString();

            // act
            var result = objectUnderTest.ToString();

            // assert
            Assert.Equal(expectedResult, result);
        }
    }
}