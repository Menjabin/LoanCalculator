using Microsoft.EntityFrameworkCore;

using LoanCalculator.Models;

namespace LoanCalculator.Data
{
    public class LoanContext : DbContext
    {

        public LoanContext(DbContextOptions<LoanContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Loan>().ToTable("Loans");
            modelBuilder.Entity<SerialLoan>().ToTable("SerialLoans");
            //modelBuilder.Entity<MortgageLoan>().ToTable("MortgageLoans");

            modelBuilder.Entity<Installment>().ToTable("Installments");

            /*
            modelBuilder.Entity<Loan>()
                .HasDiscriminator<string>("loan_type")
                .HasValue<Loan>("loan_base")
                .HasValue<SerialLoan>("loan_serial");

            modelBuilder.Entity<SerialLoan>()
                .HasDiscriminator<string>("serialloan_type")
                .HasValue<SerialLoan>("serialloan_base")
                .HasValue<MortgageLoan>("serialloan_mortgage");

            modelBuilder.Entity<List<Installment>>();
            */

            base.OnModelCreating(modelBuilder);
        }
    }
}
