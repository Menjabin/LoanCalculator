using Microsoft.AspNetCore.Mvc;

using LoanCalculator.Models;

namespace LoanCalculator.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoanController : Controller
    {
        private static readonly List<Loan> loans = new();

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

        /// <summary>
        /// Response for HTTP POST requests. Creates and stores a loan in the loan list
        /// </summary>
        /// <param name="type">Loan type ("mortgage")</param>
        /// <param name="amount">Total loan amount</param>
        /// <param name="years">Loan term in years</param>
        /// <exception cref="NotSupportedException">Thrown if the provided loan type is not supported</exception>
        [HttpPost("{type}")]
        public void Post(string type, int amount, int years)
        {
            // Create a loan and add it to the list
            loans.Add(type.ToLower() switch
            {
                "mortgage" => new MortgageLoan(amount, years),
                _ => throw new NotSupportedException("Please provide a supported loan type")
            });
        }

        [HttpDelete("{id}")]
        public ObjectResult Delete(int id)
        {
            var loan = loans.Find(l => l.LoanId == id);
            if (loan == null)
                return BadRequest("Loan not found");

            loans.Remove(loan);
            return Ok(loans);
        }
    }
}
