using System;
using Xunit;

using LoanCalculator.Controllers;
using LoanCalculator.Models;

namespace LoanCalculator.Test
{
    public class LoanControllerTest
    {
        LoanController _controller;

        public LoanControllerTest()
        {
            _controller = new LoanController();
        }

        [Fact]
        public void GetTest()
        {
            int amount = 12000;
            double rate = 3.5;
            int months = 12;

            int principal = amount / months;

            var result = _controller.Get(amount, rate, months);

            foreach (var installment in result)
            {
                int interest = (int)Math.Round(amount * (rate / months) / 100);

                Assert.Equal(rate, installment.Rate);
                Assert.Equal(principal, installment.Principal);
                Assert.Equal(interest, installment.Interest);

                amount -= principal;

                Assert.Equal(amount, installment.RemainingDebt);
            }
        }
    }
}
