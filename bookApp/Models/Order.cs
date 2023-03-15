
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace bookApp.Models {
    public class Order {

        [Key]
        [BindNever]
        public int OrderId { get; set; }

        [BindNever]
        public ICollection<CartLineItem> lines { get; set; }

        [Required(ErrorMessage="Please enter a name:")]
        public string name { get; set; }

        [Required(ErrorMessage="Please enter at least 1 address line:")]
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }

        [Required(ErrorMessage="Please enter a city:")]
        public string city { get; set; }

        [Required(ErrorMessage="Please enter a state:")]
        public string state { get; set; }

        [Required(ErrorMessage="Please enter a zip code:")]
        public string zip { get; set; }
        public string country { get; set; }
    }
}