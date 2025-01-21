using Microsoft.EntityFrameworkCore;
using TaxCalculatorApi.Repository.Entity;
using TaxCalculatorApi.Repository.Interfaces;

namespace TaxCalculatorApi.Repository
{
    public class TaxDbContext : DbContext, ITaxDbContext
    {
        public TaxDbContext(DbContextOptions<TaxDbContext> options)
            :base(options)
        {
        }

        public DbSet<TaxBand> TaxBands => Set<TaxBand>();
    }
}
