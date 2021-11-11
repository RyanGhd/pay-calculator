using System.Collections;
using System.Collections.Generic;
using System.Dynamic;
using GenerateMonthlyPayslip.DomainModel.ServiceContracts;

namespace GenerateMonthlyPayslip.Services
{
    public class TaxCalculator : ITaxCalculator
    {
        private readonly IList<(decimal LowerLimit, decimal UpperLimit, decimal TaxPercentage)> _taxBrackets;

        public TaxCalculator()
        {
            _taxBrackets = GetTaxBrackets();
        }

        private IList<(decimal LowerLimit, decimal UpperLimit, decimal TaxPercentage)> GetTaxBrackets()
        {
            return new List<(decimal LowerLimit, decimal UpperLimit, decimal TaxPercentage)>
            {
                (0,20000,0),
                (20000,40000,0.1M),
                (40000,80000,0.2M),
                (80000,180000,0.3M),
                (180000,decimal.MaxValue,0.4M),
            };
        }

        public decimal Calculate(decimal income)
        {
            decimal totalPayableTax = 0;

            foreach (var (lowerLimit, upperLimit, taxPercentage) in _taxBrackets)
            {
                if (income <= upperLimit)
                {
                    totalPayableTax += (income - lowerLimit) * taxPercentage;
                    break;
                }

                totalPayableTax += (upperLimit - lowerLimit) * taxPercentage;
            }

            return totalPayableTax;
        }
    }
}