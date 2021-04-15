using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace emailWebAPI.Models

{
    //[Table("Email", Schema = "dbo")]
    public class Email
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        public string Subject { get; set; }

        [Required]
        [MaxLength(10000)]
        public string Body { get; set; }

        [Required]
        [MaxLength(1000)]
        public string Recipients { get; set; }

        [DataType(DataType.Date)]
        [Column(TypeName = "Date")]
        public DateTime Created { get; set; }

        public string Result { get; set; } //might change it to bool or enum later
    }
}