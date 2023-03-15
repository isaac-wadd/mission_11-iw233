
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models {
    public class Cart {
        public List<CartLineItem> items { get; set; } = new List<CartLineItem>();

        public virtual void AddItem(Books item, int qty) {
            CartLineItem line = items
                .Where(x => x.book.BookId == item.BookId)
                .FirstOrDefault();
            if (line == null) {
                items.Add(new CartLineItem {
                    book = item,
                    quantity = qty
                });
            }
            else { line.quantity += qty; }
        }

        public virtual void RemoveItem(Books book) { items.RemoveAll(x => x.book.BookId == book.BookId); }

        public virtual void ClearCart() { items.Clear(); }

        public double getTotal() {
            double total = items.Sum(b => b.quantity * b.book.Price);
            return total;
        }
    }

    public class CartLineItem {

        [Key]
        public int lineID { get; set; }
        public Books book { get; set; }
        public int quantity { get; set; }
    }
}
