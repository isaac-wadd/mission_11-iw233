
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

namespace bookApp.Controllers {
    public class OrderController : Controller {

        private IorderRepo repo { get; set; }
        private Cart cart { get; set; }

        public OrderController(IorderRepo temp, Cart c) {
            repo = temp;
            cart = c;
        }

        [HttpGet]
        public IActionResult Checkout() { return View(new Order()); }

        [HttpPost]
        public IActionResult Checkout(Order order) {
            if (cart.items.Count() == 0) { ModelState.AddModelError("", "Your cart is empty!"); }
            if (ModelState.IsValid) {
                order.lines = cart.items.ToArray();
                repo.SaveOrder(order);
                cart.ClearCart();

                return RedirectToPage("/OrderConfirmation");
            }
            else { return View(); }
        }
    }
}
