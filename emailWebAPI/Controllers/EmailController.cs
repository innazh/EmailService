using System;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using emailWebAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


/*EmailDbContext can then be used in ASP.NET Core controllers or other services through constructor injection. For example:*/
namespace emailWebAPI.Controllers
{
    [Route("api/mails")]
    [ApiController]
    public class EmailController : Controller
    {
        private readonly EmailDbContext _context;

        public EmailController(EmailDbContext context)
        {
            this._context = context;
        }

        [HttpGet]
        [Route("/api/mails")]
        // GET /api/mails
        public async Task<IActionResult> GetAllEmails()
        {
            //a list of all emails stored in the db
            return Json(await _context.Email.ToListAsync());
        }

        [HttpPost]
        [Route("/api/mails")]
        //POST /api/mails
        public async Task<IActionResult> PostEmail(Email email)
        {
            bool result = false;

            if (ModelState.IsValid)
            {
                EmailService emailService = new EmailService();
                result = emailService.SendEmail(email.Subject, email.Body, email.Recipients);
            }

            //Populate model's fields
            email.Id = System.Guid.NewGuid();
            email.Created = DateTime.Now;
            if (result) email.Result = "OK";
            else email.Result = "Failed";

            //Add to the database and commit changes
            _context.Add(email);
            await _context.SaveChangesAsync();

            return Json(result);
        }
    }
}
