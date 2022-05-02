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
        [HttpGet(Name = "GetLoan")]
        public IEnumerable<Installment> Get(int amount, double rate, int months)
        {
            int principal = amount / months;

            return Enumerable.Range(0, months).Select(index => new Installment
            {
                Date = DateTime.Now.AddMonths(index),
                Rate = rate,
                CurrentLoanAmount = amount - index * principal,
                Principal = principal,
                Months = months
            })
            .ToArray();
        }

        /*
        [Route("/error-development")]
        //[ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleErrorDevelopment([FromServices] IHostEnvironment hostEnvironment)
        {
            if (!hostEnvironment.IsDevelopment())
            {
                return NotFound();
            }

            var exceptionHandlerFeature = HttpContext.Features.Get<IExceptionHandlerFeature>()!;

            return Problem(
                detail: exceptionHandlerFeature.Error.StackTrace,
                title: exceptionHandlerFeature.Error.Message
            );
        }

        [Route("/error")]
        public IActionResult HandleError() => Problem();
        */
    }
}
