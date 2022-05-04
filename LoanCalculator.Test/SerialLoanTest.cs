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
            CreateAndCheckLoan(12000, 3.5, 1);
            CreateAndCheckLoan(1000, 1, 2);
            CreateAndCheckLoan(412580238916, 213, 23751);
        }

        private static void CreateAndCheckLoan(decimal amount, double rate, int years)
        {
            SerialLoan serialLoan = new(amount, rate, years);
            decimal principalSum = 0;
            decimal remainingDebt = amount;

            decimal principal = amount / (years * 12);

            foreach (var installment in serialLoan.Installments)
            {
                // Assert that all principals are the same
                Assert.Equal(principal, installment.Principal);
            }
        }
    }
}

