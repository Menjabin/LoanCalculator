using Microsoft.AspNetCore.Mvc;

namespace LoanCalculator.Controllers
{
    [ApiController]
    [Route("loan")]
    public class LoanController : ControllerBase
    {
        private readonly ILogger<LoanController> _logger;

        public LoanController(ILogger<LoanController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public Loan Get(int amount, double rate, int months)
        {
            return new Loan
            {
                Amount = amount,
                Rate = rate,
                MonthsToPay = months
            };
        }
    }
}
