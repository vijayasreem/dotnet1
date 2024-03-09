
using demotest.DTO;
using demotest.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demotest.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoanVerificationController : ControllerBase
    {
        private readonly ILoanVerificationService _loanVerificationService;

        public LoanVerificationController(ILoanVerificationService loanVerificationService)
        {
            _loanVerificationService = loanVerificationService;
        }

        [HttpPost]
        public async Task<IActionResult> VerifyApplicantDocuments([FromBody] Applicant applicant)
        {
            await _loanVerificationService.VerifyApplicantDocuments(applicant);
            // Perform additional operations or return appropriate response
            return Ok();
        }
    }
}
