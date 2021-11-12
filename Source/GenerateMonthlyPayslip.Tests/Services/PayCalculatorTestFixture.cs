using System;
using System.Runtime.InteropServices.ComTypes;
using GenerateMonthlyPayslip.DomainModel.ServiceContracts;
using Moq;

namespace GenerateMonthlyPayslip.Services
{
    public class PayCalculatorTestFixture
    {
        private Mock<ITaxCalculator> TaxCalculatorMock { get; set; }

        public PayCalculatorTestFixture Start()
        {
            TaxCalculatorMock = new Mock<ITaxCalculator>();

            return this;
        }

        public PayCalculatorTestFixture WithTaxResult(decimal tax)
        {
            TaxCalculatorMock.Setup(s => s.Calculate(It.IsAny<decimal>())).Returns(tax);

            return this;
        }

        public PayCalculator Build()
        {
            return new PayCalculator(TaxCalculatorMock.Object);
        }
    }
}