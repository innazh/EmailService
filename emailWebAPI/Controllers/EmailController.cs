using System;
using emailWebAPI.Models;
using Microsoft.AspNetCore.Mvc;


/*EmailDbContext can then be used in ASP.NET Core controllers or other services through constructor injection. For example:*/
namespace emailWebAPI.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class EmailController : Controller
    {
        //private readonly EmailDbContext _context;

        public EmailController(EmailDbContext context)
        {
            //this._context = context;
        }

        [HttpGet]
        [Route("/api/mails")]
        // GET /api/mails
        public String GetAllEmails()
        {
            return "hi";//a list of all emails stored in the db
        }

        [HttpPost]
        [Route("PostEmail")]
        //POST /api/mails
        public bool PostEmail(Email email)
        {
            return false;
        }
    }
}
