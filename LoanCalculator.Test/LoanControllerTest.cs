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
    }
}
