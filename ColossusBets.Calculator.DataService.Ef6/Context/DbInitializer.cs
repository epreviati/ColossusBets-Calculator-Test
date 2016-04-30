using System.Data.Entity;

namespace ColossusBets.Calculator.DataService.Ef6.Context
{
    public class DbInitializer : DropCreateDatabaseIfModelChanges<CalculatorContext>
    {
        protected override void Seed(CalculatorContext context)
        {
            // Do nothing if we do not need any test data
        }
    }
}