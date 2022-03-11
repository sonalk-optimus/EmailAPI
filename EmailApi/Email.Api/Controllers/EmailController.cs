using Email.Api.Models;
using Email.Api.Services;
using Microsoft.AspNetCore.Mvc;
using System;

namespace Email.Api.Controllers
{
    [Route("api/email")]
    [ApiController]
    public class EmailController : ControllerBase
    {
        private readonly IMailService _mailService;
        public EmailController(IMailService mailService)
        {
            _mailService = mailService;
        }

        [HttpPost("send")]
        public IActionResult Send([FromForm] MailRequest request)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    _mailService.SendEmail(request);
                    
                }
                catch (Exception ex)
                {

                    throw ex;
                }
            }

            return Ok();
        }
    }
}
