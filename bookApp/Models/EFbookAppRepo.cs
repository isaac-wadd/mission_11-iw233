using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models
{
    public class EFbookAppRepo : IbookAppRepo
    {
        private bookAppContext ctxt { get; set; }
        public EFbookAppRepo(bookAppContext temp) { ctxt = temp; }
        public IQueryable<Books> books => ctxt.Books;
    }
}