using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicePro.DomainModels
{
    public class ShoppingCart
    {
        [Key]
        public int ShoppingId { get; set; }
        public string ApplicationUserId { get; set; }
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public int Count { get; set; }

    }
}
