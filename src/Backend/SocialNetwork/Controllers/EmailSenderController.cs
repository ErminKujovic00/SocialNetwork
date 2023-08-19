using Microsoft.AspNetCore.Mvc;
using SocialNetwork.BLL.Interfaces;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SocialNetwork.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailSenderController : ControllerBase
    {
        private readonly IEmailSenderService _emailSenderService;

        public EmailSenderController(IEmailSenderService emailSenderService)
        {
            _emailSenderService = emailSenderService;
        }
        // POST api/<EmailSenderController>
        [HttpPost]
        public async void Post(string name, string subject, string mail, string message)
        {
            await _emailSenderService.sendEmailAsync(name, subject, mail, message);
        }

        // GET: api/<EmailSenderController>
       /* [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<EmailSenderController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }*/


      /*  // PUT api/<EmailSenderController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<EmailSenderController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }*/
    }
}
