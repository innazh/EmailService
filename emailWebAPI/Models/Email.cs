using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emailWebAPI.Models

{
    [Table("Email", Schema = "dbo")]
    public class Email
    {
        [Key]
        public Guid EmailId { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Body { get; set; }

        [Required]
        public string[] Recipients { get; set; }

        public ICollection<Email> Emails { get; set; } = new List<Email>();

        public Email()
        {
        }
    }
}