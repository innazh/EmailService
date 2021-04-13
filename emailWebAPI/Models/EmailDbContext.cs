using System;
using Microsoft.EntityFrameworkCore;

namespace emailWebAPI.Models
{
    public class EmailDbContext : DbContext
    {
        public DbSet<Email> Emails { get; set; }

        //This is how context configuration from AddDbContext(in Startup.cs file) is passed to the DbContext
        public EmailDbContext(DbContextOptions<EmailDbContext> options) : base(options)
        {
            //Database.Migrate();
        }

    }
}
