namespace LoanCalculator.Models
{
    public class MortgageLoan : SerialLoan
    {
        public double rate = 3.5;

        public MortgageLoan(int amount, int years) : base(amount, 3.5, years)
        {

        }
    }
}
