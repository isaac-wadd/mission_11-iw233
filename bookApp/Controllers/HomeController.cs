
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using bookApp.Models;
using bookApp.Models.ViewModels;

namespace bookApp.Controllers
{
    public class HomeController : Controller
    {
        private IbookAppRepo repo;

        public HomeController(IbookAppRepo temp) { repo = temp; }

        public IActionResult Index(string bookCategory, int pageNum=1) {
            int pageSize = 5;
            var x = new BooksViewModel {
                books = repo.books
                    .Include(b => b.Category)
                    .Include(b => b.Classification)
                    .Where(b => b.Category.CategoryName == bookCategory || bookCategory == null)
                    .OrderBy(b => b.Title)
                    .Skip((pageNum - 1) * pageSize)
                    .Take(pageSize),

                pagesInfo = new PagesInfoModel {
                    totalBooks = bookCategory == null ? repo.books.Count() : repo.books.Where(b => b.Category.CategoryName == bookCategory).Count(),
                    booksPerPage = pageSize,
                    currentPage = pageNum
                }
            };
            return View(x);
        }
    }
}
