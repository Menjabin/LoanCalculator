namespace LoanCalculator.Models
{
    public class Installment
    {
        // Due date for this installment
        public string? Date { get; set; }

        // Annual percentage rate, the yearly interest for this loan
        public double Rate { private get; set; }

        // Current debt before this installment is paid
        public int CurrentDebt { private get; set; }

        // Remaining debt after repaying this installment
        public int RemainingDebt => CurrentDebt - Principal;

        // Fixed amount paid each installment
        public int Principal { get; set; }

        // Loan term in months
        public int Months { private get; set; }

        // Total amount to pay for this installment
        public int Amount => Principal + Interest;

        // (Rate / Months) converts the annual payback rate to monthly payback rate.
        public int Interest => (int)Math.Round((CurrentDebt * (Rate / Months) / 100));
    }
}