using System.Data;
using System.Text;

namespace GenerateMonthlyPayslip.DomainModel.Objects
{
    public class Payslip
    {
        public string EmployeeName { get; }
        public decimal GrossMonthlyIncome { get; }
        public decimal MonthlyTax { get; }
        public decimal NetMonthlyIncome { get; }

        public Payslip(string employeeName, decimal grossMonthlyIncome, decimal monthlyTax, decimal netMonthlyIncome)
        {
            EmployeeName = employeeName;
            GrossMonthlyIncome = grossMonthlyIncome;
            MonthlyTax = monthlyTax;
            NetMonthlyIncome = netMonthlyIncome;
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.AppendLine($"Monthly Payslip for: \"{EmployeeName}\"");
            sb.AppendLine($"Gross Monthly Income: {GrossMonthlyIncome:C}");
            sb.AppendLine($"Monthly Income Tax: {MonthlyTax:C}");
            sb.AppendLine($"Net Monthly Income: {NetMonthlyIncome:C}");

            return sb.ToString();
        }
    }
}