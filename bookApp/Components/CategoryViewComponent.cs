
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using bookApp.Models;

namespace bookApp.Components {
    public class CategoryViewComponent : ViewComponent {
        private IbookAppRepo repo { get; set; }
        public CategoryViewComponent(IbookAppRepo temp) { repo = temp; }

        public IViewComponentResult Invoke() {

            ViewBag.selectedCategory = RouteData?.Values["bookCategory"];

            var types = repo.books
                .Select(b => b.Category.CategoryName)
                .Distinct()
                .OrderBy(b => b);

            return View(types);
        }
    }
}
