namespace LoanCalculator
{
    public class Loan
    {
        public int Amount { get; set; }

        public double Rate { get; set; }

        public int MonthsToPay { get; set; }

        //public double Monthly => Math.Round((double) Amount / MonthsToPay, 2);

        //public double FirstInterest => Math.Round(Amount * Rate, 2);
    }
}