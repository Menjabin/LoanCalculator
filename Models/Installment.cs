namespace LoanCalculator.Models
{
    public class Installment
    {
        // Set these variables
        public DateTime Date { get; set; }

        public double Rate { get; set; }

        public int CurrentLoanAmount { private get; set; }

        public int Principal { get; set; }

        public int Months { private get; set; }

        // Calculate these variables
        public int Amount => Principal + Interest;

        public int RemainingDebt => CurrentLoanAmount - Principal;

        // (Rate / Months) converts the annual payback rate to monthly payback rate.
        public int Interest => (int)Math.Round((CurrentLoanAmount * (Rate / Months) / 100));
    }
}