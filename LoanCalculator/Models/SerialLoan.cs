using System.ComponentModel.DataAnnotations;

namespace LoanCalculator.Models
{
	public class SerialLoan : Loan
	{
		public SerialLoan(decimal amount, double rate, int years) : base(amount, rate, years)
		{
			
		}

        protected override IEnumerable<Installment> GenerateInstallments(decimal amount, double rate, int years)
        {
            // Verify that these parameters are okay
            if (amount < 0)
                throw new ArgumentOutOfRangeException(nameof(amount));
            else if (years < 1)
                throw new ArgumentOutOfRangeException(nameof(years));
            else if (rate < 0)
                throw new ArgumentOutOfRangeException(nameof(rate));

            // There is a possibility that a large year creates a date larger than DateTime.MaxValue
            try
            {
                DateTime.Now.AddYears(years);
            } catch (ArgumentOutOfRangeException exception)
            {
                throw exception;
            }

            int months = years * 12;
            decimal principal = amount / months;

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
