﻿using System;
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
            Console.WriteLine("my get");
            //return "hi";//a list of all emails stored in the db
            return Json(await _context.Email.ToListAsync());
        }

        [HttpPost]
        [Route("PostEmail")]
        //POST /api/mails
        public bool PostEmail(Email email)
        {
            return false;
        }


        //// POST: Movies/Create
        //// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        //// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("ID,Title,ReleaseDate,Genre,Price,Rating")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(movie);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}

        //// POST: Movies/Create
        //// To protect from overposting attacks, enable the specific properties you want to bind to.
        //// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        //[HttpPost]
        //[ValidateAntiForgeryToken]
        //public async Task<IActionResult> Create([Bind("Id,Title,ReleaseDate,Genre,Price")] Movie movie)
        //{
        //    if (ModelState.IsValid)
        //    {
        //        _context.Add(movie);
        //        await _context.SaveChangesAsync();
        //        return RedirectToAction(nameof(Index));
        //    }
        //    return View(movie);
        //}
    }
}
