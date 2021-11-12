using GenerateMonthlyPayslip.DomainModel.Objects;

namespace GenerateMonthlyPayslip.DomainModel.ServiceContracts
{
    public interface IPayCalculator
    {
        Payslip Calculate(string employeeName, decimal annualSalary);
    }
}