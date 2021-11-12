using System;
using Autofac;
using GenerateMonthlyPayslip.DomainModel.ServiceContracts;
using GenerateMonthlyPayslip.Services;

namespace GenerateMonthlyPayslip
{
    class Program
    {
        private static IContainer _container = Bootstrap();

        static void Main(string[] args)
        {
            var (wasSuccessful, emplyeeName, annualSalary) = GetArgs(args);

            if (!wasSuccessful)
                return;

            var calculator = _container.Resolve<IPayCalculator>();

            var payslip = calculator.Calculate(args[0], annualSalary);

            Console.WriteLine(payslip.ToString());
        }

        static IContainer Bootstrap()
        {
            var containerBuilder = new ContainerBuilder();

            containerBuilder.RegisterType<PayCalculator>().As<IPayCalculator>().SingleInstance();
            containerBuilder.RegisterType<TaxCalculator>().As<ITaxCalculator>().SingleInstance();

            var container = containerBuilder.Build();

            return container;
        }

        private static (bool WasSuccessful,string EmployeeName, decimal AnnualSalaray) GetArgs(string[] args)
        {
            if (args.Length < 2)
            {
                Console.WriteLine("Please enter employee name and Annual salary (e.g. \"Sally Young\" 100000)");

                return (false,null,0);
            }

            if (!decimal.TryParse(args[1], out var annualSalary))
            {
                Console.WriteLine("Please enter a decimal value for Annual salary (e.g. 1000.00 or 1000)");

                return (false, null, 0);
            }

            return (true, args[0], annualSalary);
        }
    }
}
