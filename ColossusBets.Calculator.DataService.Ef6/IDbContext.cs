using System.Data.Entity;
using ColossusBets.Calculator.DataService.Ef6Model;

namespace ColossusBets.Calculator.DataService.Ef6
{
    public interface IDbContext
    {
        DbSet<Record> Records { get; set; }

        int SaveChanges();
    }
}