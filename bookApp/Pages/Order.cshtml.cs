
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookApp.Models;
using bookApp.Infrastructure;

namespace bookApp.Pages {
    public class OrderModel : PageModel {

        private IbookAppRepo repo { get; set; }
        public OrderModel(IbookAppRepo temp, Cart tCart) { repo = temp; cart = tCart; }
        public Cart cart { get; set; }
        public string ReturnUrl { get; set; }

        public void OnGet(string returnUrl) {
            ReturnUrl = returnUrl ?? "/";
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
        }

        public IActionResult OnPost(int bookID, string returnUrl) {

            Books book = repo.books.FirstOrDefault(b => b.BookId == bookID);
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            cart.AddItem(book, 1);

            HttpContext.Session.SetJson("cart", cart);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }

        public IActionResult OnPostRemove(int bookID, string returnUrl) {
            cart.RemoveItem(cart.items.First(x => x.book.BookId == bookID).book);
            return RedirectToPage(new { ReturnUrl = returnUrl });
        }
    }
}
