namespace LoanCalculator.Models
{
    public class MortgageLoan : SerialLoan
    {
        public MortgageLoan(decimal amount, int years, double rate = 3.5) : base(amount, rate, years)
        {

        }
    }
}
