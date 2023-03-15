
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models
{
    public interface IorderRepo
    {
        IQueryable<Order> orders { get; }
        void SaveOrder(Order order);
    }
}
