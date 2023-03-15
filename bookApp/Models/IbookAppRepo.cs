using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace bookApp.Models
{
    public interface IbookAppRepo { IQueryable<Books> books { get; } }
}