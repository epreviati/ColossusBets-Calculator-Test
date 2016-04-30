using System.Data.Entity;
using ColossusBets.Calculator.DataService.Ef6Model;

namespace ColossusBets.Calculator.DataService.Ef6.Context
{
    public class CalculatorContext : DbContext, IDbContext
    {
        public CalculatorContext()
            : base("CalculatorContext")
        {
        }

        /// <summary>
        ///     Records table
        /// </summary>
        public DbSet<Record> Records { get; set; }
    }
}