namespace LoanCalculator.Models
{
    public class MortgageLoan : SerialLoan
    {

        // All mortgage loans have a rate of 3.5
        public MortgageLoan(decimal amount, int years) : base(amount, 3.5, years)
        {

        }
    }
}
