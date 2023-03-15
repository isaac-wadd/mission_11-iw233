
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models.ViewModels {
    public class BooksViewModel {
        public IQueryable<Books> books { get; set; }
        public PagesInfoModel pagesInfo { get; set; }
    }
}