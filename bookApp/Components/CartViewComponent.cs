
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using bookApp.Models;
using bookApp.Infrastructure;

namespace bookApp.Components {
    public class CartViewComponent : ViewComponent {

        public Cart cart { get; set; }
        public CartViewComponent(Cart c) { cart = c; }

        public IViewComponentResult Invoke() {
            cart = HttpContext.Session.GetJson<Cart>("cart") ?? new Cart();
            ViewBag.itemCount = cart.items.Count();
            return View(cart);
        }
    }
}
