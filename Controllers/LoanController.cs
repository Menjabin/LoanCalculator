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
        public Loan Get()
        {
            return new Loan
            {
                Amount = 12000,
                Rate = 3,
                MonthsToPay = 12
            };
        }
    }
}
