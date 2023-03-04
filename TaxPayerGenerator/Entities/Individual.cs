namespace TaxPayerGenerator.Entities
{
    class Individual : TaxPayer
    {
        public double HealthExpenditures { get; set; }

        public Individual(string name, double annualIncome, double healthExpenditures)
            : base(name, annualIncome)
        {
            HealthExpenditures = healthExpenditures;
        }

        public override double Tax()
        {
            if (AnnualIncome < 20000.00)
            {
                return AnnualIncome * 0.15 - HealthExpenditures * 0.5;
            }
            else
            {
                return AnnualIncome * 0.25 - HealthExpenditures * 0.5;
            }
        }
    }
}
