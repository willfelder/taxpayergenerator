using TaxPayerGenerator.Entities;

namespace TaxPayerGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                // Create a list of tax payers

                List<TaxPayer> taxPayers = new List<TaxPayer>();

                Console.Write("Enter the number of tax payers: ");
                int numTaxPayers = int.Parse(Console.ReadLine());

                for (int i = 1; i <= numTaxPayers; i++)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Tax payer #{i} data: ");
                    Console.Write("Individual or company (i/c)? ");
                    char response = char.Parse(Console.ReadLine());

                    Console.Write("Name: ");
                    string name = Console.ReadLine();
                    Console.Write("Annual income: ");
                    double annualIncome = double.Parse(Console.ReadLine());

                    // Create an individual or company object

                    if (response == 'i')
                    {
                        Console.Write("Health expenditures: ");
                        double healthExpenditures = double.Parse(Console.ReadLine());

                        taxPayers.Add(new Individual(name, annualIncome, healthExpenditures));
                    }
                    else
                    {
                        Console.Write("Number of employees: ");
                        int numberOfEmployees = int.Parse(Console.ReadLine());

                        taxPayers.Add(new Company(name, annualIncome, numberOfEmployees));
                    }
                }
                Console.WriteLine();
                Console.WriteLine("TAXES PAID: ");

                // Display the income and tax

                double sum = 0.0;

                foreach(TaxPayer payers in taxPayers)
                {
                    double tax = payers.Tax();
                    Console.WriteLine($"{payers.Name}: ${tax.ToString("F2")}");
                    sum += tax;
                }
                Console.WriteLine();
                Console.WriteLine($"TOTAL TAXES: ${sum.ToString("F2")}");
            }
            catch (IOException e)
            {
                Console.WriteLine("Something went wrong.");
                Console.WriteLine(e.Message);
            }
        }
    }
}