using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Diagnostics;

using LoanCalculator.Models;

namespace LoanCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : Controller
    {
        /// <summary>
        /// Response for HTTP GET requests.
        /// </summary>
        /// <param name="type">Loan type ("mortgage")</param>
        /// <param name="amount">Total loan amount</param>
        /// <param name="years">Loan term in years</param>
        /// <returns>A Loan object containing a list of installments and data related to the loan</returns>
        /// <exception cref="NotSupportedException">Thrown if the provided loan type is not supported</exception>
        [HttpGet("{type}")]
        public Loan Get(string type, int amount, int years)
        {
            // Return a loan of the desired type
            return type.ToLower() switch
            {
                "mortgage" => new MortgageLoan(amount, years),
                _ => throw new NotSupportedException("Please provide a supported loan type")
            };
        }
    }
}
