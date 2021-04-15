using System;
using Microsoft.EntityFrameworkCore;

namespace emailWebAPI.Models
{
    public class EmailDbContext : DbContext
    {
        // In Entity Framework terminology, an entity set typically corresponds to a database table. An entity corresponds to a row in the table.
        public DbSet<Email> Email { get; set; }


        //This is how context configuration from AddDbContext(in Startup.cs file) is passed to the DbContext
        public EmailDbContext(DbContextOptions<EmailDbContext> options) : base(options)
        {
            //Database.Migrate();
        }

    }
}
