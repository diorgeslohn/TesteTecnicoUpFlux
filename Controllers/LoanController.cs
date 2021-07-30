using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TesteUpFlux.v3.Models;
using TesteUpFlux.v3.Services;

namespace TesteUpFlux.v3.Controllers
{
    [Route("/book/[controller]/loan/[controller]")]
    [ApiController]    
    public class LoanController : ControllerBase
    {
        private readonly LoanService _loanService;

        public LoanController(LoanService loanService)
        {
            _loanService = loanService;
        }

        [HttpGet]
        public ActionResult<List<Loan>> Get() => _loanService.Get();

        [HttpGet("{id}", Name = "GetLoan")]
        public ActionResult<Loan> Get(string id)
        {
            var loan = _loanService.Get(id);

            if (loan == null)
            {
                return NotFound();
            }

            return loan;
        }

        [HttpPost]
        public ActionResult<Loan> Create(Loan loan)
        {
            _loanService.Create(loan);

            return CreatedAtRoute("GetLoan", new { id = loan.User.ToString() }, loan);
        }

        [HttpPut("{id}")]
        public IActionResult Update(string id, Loan loanIn)
        {
            var loan = _loanService.Get(id);

            if (loan == null)
            {
                return NotFound();
            }

            _loanService.Update(id, loanIn);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(string id)
        {
            var loan = _loanService.Get(id);

            if (loan == null)
            {
                return NotFound();
            }

            _loanService.Remove(loan.User);

            return NoContent();
        }


    }
}
