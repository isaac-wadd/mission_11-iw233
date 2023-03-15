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
    public class Classifications
    {
        public Classifications()
        {
            Books = new HashSet<Books>();
        }

        [Key]
        [Required]
        public long ClassificationId { get; set; }
        public string ClassificationName { get; set; }

        public ICollection<Books> Books { get; set; }
    }
}
