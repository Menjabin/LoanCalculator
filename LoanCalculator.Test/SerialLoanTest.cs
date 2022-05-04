using System;
using Xunit;

using LoanCalculator.Models;

namespace LoanCalculator.Test
{
	public class SerialLoanTest
	{
		public SerialLoanTest()
		{

		}

        [Fact]
        public void LoanTest()
        {
            // Test normal loans
            CreateAndTestLoan(12000, 3.5, 1);
            CreateAndTestLoan(1000, 1, 2);

            // Test negative values
            Assert.Throws<ArgumentOutOfRangeException>(() => new SerialLoan(-1000, 2.2, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new SerialLoan(-1000, -2.2, 10));
            Assert.Throws<ArgumentOutOfRangeException>(() => new SerialLoan(1000, 2.2, -10));

            // Test other invalid values
            Assert.Throws<ArgumentOutOfRangeException>(() => new SerialLoan(1000, 1.1, DateTime.MaxValue.Year));
            Assert.Throws<ArgumentOutOfRangeException>(() => new SerialLoan(10, 5.2, 0));

            // Test large and small values
            CreateAndTestLoan(decimal.MaxValue, double.Epsilon, 100);
            CreateAndTestLoan(1, 1, 1);
            CreateAndTestLoan(0, 0, 1);
        }

        private static void CreateAndTestLoan(decimal amount, double rate, int years)
        {
            SerialLoan serialLoan = new(amount, rate, years);

            int months = years * 12;
            decimal remainingDebt = amount;
            decimal principal = amount / months;

            foreach (var installment in serialLoan.Installments)
            {
                decimal interest = remainingDebt * ((decimal) rate / months) / 100;

                remainingDebt -= principal;

                Assert.Equal(principal, installment.Principal);
                Assert.Equal(interest, installment.Interest, 10);
                //Assert.Equal(remainingDebt, installment.RemainingDebt);
            }
        }
    }
}

