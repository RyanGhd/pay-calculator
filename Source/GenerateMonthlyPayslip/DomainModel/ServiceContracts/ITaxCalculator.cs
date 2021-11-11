namespace GenerateMonthlyPayslip.DomainModel.ServiceContracts
{
    public interface ITaxCalculator
    {
        decimal Calculate(decimal income);
    }
}