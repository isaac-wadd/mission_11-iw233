
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace bookApp.Models
{
    public class EForderRepo : IorderRepo
    {
        private bookAppContext ctxt;
        public EForderRepo(bookAppContext temp) { ctxt = temp; }

        public IQueryable<Order> orders => ctxt.Orders.Include(x => x.lines).ThenInclude(x => x.book);

        public void SaveOrder(Order order) {
            ctxt.AttachRange(order.lines.Select(x => x.book));
            if (order.OrderId == 0) {
                ctxt.Orders.Add(order);
            }
            ctxt.SaveChanges();
        }
    }
}
