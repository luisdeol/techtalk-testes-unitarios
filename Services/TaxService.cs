using System;
using TechTalkDemo.UnitTests.Repositories;

namespace TechTalkDemo.UnitTests.Services
{
    public class TaxService
    {
        private readonly ITaxRepository _taxRepository;
        public TaxService(ITaxRepository taxRepository)
        {
            _taxRepository = taxRepository;
        }

        private const double TAX_HIGH_SALARIES = 0.30;
        private const double TAX_AVERAGE_SALARIES = 0.20;
        private const double TAX_DEFAULT = 0.10;

        public double CalculateTaxesFromGrossSalary(double grossSalary) {
            double tax;

            if (grossSalary < 0)
                throw new ArgumentException("Salário menor que zero.");

            if (grossSalary > 10000)
                tax = TAX_HIGH_SALARIES * grossSalary;
            else if (grossSalary > 5000)
                tax = TAX_AVERAGE_SALARIES * grossSalary;
            else
                tax = TAX_DEFAULT * grossSalary;
            
            _taxRepository.SaveQuery(grossSalary, tax);

            return tax;
        }
    }
}