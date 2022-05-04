namespace LoanCalculator.Models
{
	public class SerialLoan : Loan
	{
		public SerialLoan(int amount, double rate, int years) : base(amount, rate, years)
		{
			
		}

        protected override IEnumerable<Installment> GenerateInstallments(int amount, double rate, int years)
        {
            int months = years * 12;
            int principal = (int) Math.Round((decimal) (amount / months));

            return Enumerable.Range(0, months).Select(index => new Installment
            {
                Date = DateTime.Now.AddMonths(index).ToShortDateString(),
                Rate = rate,
                CurrentDebt = amount - index * principal,
                Principal = principal,
                Months = months
            })
            .ToArray();
        }
    }
}
