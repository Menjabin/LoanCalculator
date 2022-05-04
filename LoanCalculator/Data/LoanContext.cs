using Microsoft.EntityFrameworkCore;

using LoanCalculator.Models;

namespace LoanCalculator.Data
{
    public class LoanContext : DbContext
    {
        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {

        }

        public DbSet<Loan> Loans { get; set; }
    }
}
