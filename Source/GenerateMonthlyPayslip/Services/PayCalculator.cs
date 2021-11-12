using System;
using GenerateMonthlyPayslip.DomainModel.Objects;
using GenerateMonthlyPayslip.DomainModel.ServiceContracts;

namespace GenerateMonthlyPayslip.Services
{
    public class PayCalculator : IPayCalculator
    {
        private readonly ITaxCalculator _taxCalculator;

        public PayCalculator(ITaxCalculator taxCalculator)
        {
            _taxCalculator = taxCalculator;
        }

        public Payslip Calculate(string employeeName, decimal annualSalary)
        {
            //tax
            var totalTax = _taxCalculator.Calculate(annualSalary);

            var monthlyTax = decimal.Round(decimal.Divide(totalTax, 12),2, MidpointRounding.AwayFromZero);

            var grossMonthlyIncome = decimal.Round(decimal.Divide(annualSalary, 12), 2, MidpointRounding.AwayFromZero);

            var netMonthlyIncome = grossMonthlyIncome - monthlyTax;

            return new Payslip(employeeName, grossMonthlyIncome, monthlyTax, netMonthlyIncome);
        }
    }
}