using Microsoft.AspNetCore.Mvc;
using SendEmailApi.Services;

namespace SendEmailApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EmailController : ControllerBase
    {
        private readonly EmailService _emailService;

        public EmailController(EmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] EmailRequest emailRequest)
        {
            if (string.IsNullOrEmpty(emailRequest.To) || string.IsNullOrEmpty(emailRequest.Subject) || string.IsNullOrEmpty(emailRequest.Message))
            {
                return BadRequest(new { success = false, error = "Missing required fields." });
            }

            try
            {
                await _emailService.SendEmail(emailRequest);
                return Ok(new { success = true });
            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Error sending email: " + ex.Message);
                return StatusCode(500, new { success = false, error = "Internal server error." });
            }
        }
    }
}