
using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using bookApp.Infrastructure;

namespace bookApp.Models {
    public class SessionCart : Cart {

        public static Cart GetCart(IServiceProvider svcs) {
            ISession session = svcs.GetRequiredService<IHttpContextAccessor>()?.HttpContext.Session;
            SessionCart cart = session?.GetJson<SessionCart>("cart") ?? new SessionCart();
            cart.session = session;
            return cart;
        }

        [JsonIgnore]
        public ISession session { get; set; }

        public override void AddItem(Books b, int qty) {
            base.AddItem(b, qty);
            session.SetJson("cart", this);
        }

        public override void RemoveItem(Books b) {
            base.RemoveItem(b);
            session.SetJson("cart", this);
        }

        public override void ClearCart() {
            base.ClearCart();
            session.Remove("cart");
        }
    }
}
