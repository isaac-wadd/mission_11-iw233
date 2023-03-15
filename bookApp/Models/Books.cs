using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bookApp.Models
{
    public class Books
    {
        [Key]
        [Required]
        public long BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }
        public string Publisher { get; set; }
        public string Isbn { get; set; }
        public long ClassificationId { get; set; }
        public long CategoryId { get; set; }
        public long PageCount { get; set; }
        public double Price { get; set; }

        public Categories Category { get; set; }
        public Classifications Classification { get; set; }
    }
}
