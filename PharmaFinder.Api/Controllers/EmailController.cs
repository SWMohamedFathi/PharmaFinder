using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PharmaFinder.Core.DTO;
using PharmaFinder.Core.Service;

namespace PharmaFinder.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private IEmailService _emailService;
        public EmailController(IEmailService emailService)
        {
            _emailService = emailService;
        }

        [HttpPost(Name = "SendEmail")]
        public void SendEmail(SendEmailDto emailDto)
        {
            _emailService.SendEmail(emailDto);
        }
    }
}
