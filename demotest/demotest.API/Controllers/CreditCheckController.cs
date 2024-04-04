
using demotest.DTO;
using demotest.Service;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace demotest.API
{
    [Route("api/[controller]")]
    [ApiController]
    public class CreditCheckController : ControllerBase
    {
        private readonly ICreditCheckService _creditCheckService;

        public CreditCheckController(ICreditCheckService creditCheckService)
        {
            _creditCheckService = creditCheckService;
        }

        [HttpPost]
        public async Task<ActionResult<PreQualificationResult>> CheckCreditAsync(Applicant applicant)
        {
            try
            {
                var result = await _creditCheckService.CheckCreditAsync(applicant);
                return Ok(result);
            }
            catch (Exception ex)
            {
                // Handle exception and return appropriate response
                return StatusCode(500, ex.Message);
            }
        }
    }
}
