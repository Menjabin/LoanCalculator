namespace LoanCalculator.Models
{
    public interface ILoan
    {
        public IEnumerable<Installment> GetInstallments();
    }
}
