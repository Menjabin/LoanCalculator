namespace LoanCalculator.Models
{
    public class Installment
    {
        public int Id { get; set; }

        // Due date for this installment
        public string? Date { get; set; }

        // Annual percentage rate, the yearly interest for this loan
        public double Rate { private get; set; }

        // Current debt before this installment is paid
        public decimal CurrentDebt { private get; set; }

        // Remaining debt after repaying this installment
        public decimal RemainingDebt => CurrentDebt - Principal;

        // Fixed amount paid each installment
        public decimal Principal { get; set; }

        // Loan term in months
        public int Months { private get; set; }

        // Total amount to pay for this installment
        public decimal Amount => Principal + Interest;

        // (Rate / Months) converts the annual payback rate to monthly payback rate.
        public decimal Interest => CurrentDebt * ((decimal) Rate / Months) / 100;
    }
}