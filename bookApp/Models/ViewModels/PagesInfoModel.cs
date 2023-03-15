
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models.ViewModels {
    public class PagesInfoModel {
        public int totalBooks { get; set; }
        public int booksPerPage { get; set; }
        public int currentPage { get; set; }
        public int totalPages => (int)Math.Ceiling((double)totalBooks / booksPerPage);
    }
}
