
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace bookApp.Models
{
    public class bookAppContext : DbContext
    {
        public bookAppContext()
        {
        }

        public bookAppContext(DbContextOptions<bookAppContext> options)
            : base(options)
        {
        }

        public DbSet<Books> Books { get; set; }
        public DbSet<Categories> Categories { get; set; }
        public DbSet<Classifications> Classifications { get; set; }
        public DbSet<Order> Orders { get; set; }
    }
}
