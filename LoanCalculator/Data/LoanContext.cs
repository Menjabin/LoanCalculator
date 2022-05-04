using Microsoft.EntityFrameworkCore;

using LoanCalculator.Models;

namespace LoanCalculator.Data
{
    public class LoanContext : DbContext
    {
        public DbSet<Loan> Loans { get; set; }

        public DbSet<SerialLoan> SerialLoans { get; set; }

        public DbSet<MortgageLoan> MortgageLoans { get; set; }

        public DbSet<Installment> Installments { get; set; }

        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {

        }
    }
}
