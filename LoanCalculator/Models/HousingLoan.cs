namespace LoanCalculator.Models
{
    public class HousingLoan : ILoan
    {
        private readonly double rate = 3.5;
        private readonly IEnumerable<Installment> Installments;

        public HousingLoan(int amount, int term)
        {
            int months = term * 12;
            int principal = amount / months;

            // Populate "Installments" with an array of monthly installments
            Installments = Enumerable.Range(0, months).Select(index => new Installment
            {
                Date = DateTime.Now.AddMonths(index).ToShortDateString(),
                Rate = rate,
                CurrentDebt = amount - index * principal,
                Principal = principal,
                Months = months
            })
            .ToArray();
        }

        public IEnumerable<Installment> GetInstallments()
        {
            return Installments;
        }
    }
}
