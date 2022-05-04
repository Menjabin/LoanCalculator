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
            int years = 1;

            int principal = amount / years;

            var result = _controller.Get("housing", amount, years);

            foreach (var installment in result)
            {
                int interest = (int)Math.Round(amount * (rate / (years * 12)) / 100);

                Assert.Equal(principal, installment.Principal);
                Assert.Equal(interest, installment.Interest);

                amount -= principal;

                Assert.Equal(amount, installment.RemainingDebt);
            }
        }
    }
}
