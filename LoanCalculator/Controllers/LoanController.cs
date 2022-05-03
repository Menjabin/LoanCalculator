using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

using LoanCalculator.Models;

namespace LoanCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : Controller
    {
        public LoanController()
        {

        }

        /// <summary>
        /// API response for HTTP GET requests.
        /// 
        /// Returns a payback plan for a loan with a fixed annual payback rate.
        /// The plan is an array consisting of all the installments that make up this loan.
        /// <param name="amount"><c>amount</c>: the total loan amount</param>
        /// <param name="rate"><c>rate</c>: the annual payback rate for this loan</param>
        /// <param name="months"><c>months</c>: the loan term in months</param>
        /// </summary>
        [HttpGet("{type}")]
        public IEnumerable<Installment> Get(string type, int amount, int term)
        {
            return type.ToLower() switch
            {
                "housing" => new HousingLoan(amount, term).GetInstallments(),
                _ => throw new NotSupportedException("Provide a supported loan type")
            };
        }
    }
}
