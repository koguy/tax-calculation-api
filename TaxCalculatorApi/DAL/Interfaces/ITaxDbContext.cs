using Microsoft.EntityFrameworkCore;
using TaxCalculatorApi.Repository.Entity;

namespace TaxCalculatorApi.Repository.Interfaces
{
    public interface ITaxDbContext
    {
        DbSet<TaxBand> TaxBands { get; }
    }
}
