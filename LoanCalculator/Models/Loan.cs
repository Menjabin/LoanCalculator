namespace LoanCalculator.Models
{
	public abstract class Loan
	{
        public int Id { get; set; }

        public double Rate { get; }
        public IEnumerable<Installment> Installments { get; }

        public decimal TotalInterest { get; } = 0;

        /// <summary>
        /// Create a generic loan
        /// </summary>
        /// <param name="amount">Total loan amount</param>
        /// <param name="rate">Annual Percentage Rate. The yearly rate for this loan</param>
        /// <param name="years">Loan term in years</param>
		public Loan(decimal amount, double rate, int years)
		{
            Rate = rate;
            Installments = GenerateInstallments(amount, rate, years);

            // Loop through all installments and add up the interest
            foreach (var installment in Installments) {
                TotalInterest += installment.Interest;
            }
        }

        /// <summary>
        /// Generate a list of installments. This method will be overridden to define different loan behaviors
        /// </summary>
        /// <param name="amount">Total loan amount</param>
        /// <param name="rate">Yearly rate for this loan</param>
        /// <param name="years">Loan term in years</param>
        /// <returns>An enumerable list of the installments that make up this loan</returns>
        protected abstract IEnumerable<Installment> GenerateInstallments(decimal amount, double rate, int years);
	}
}
