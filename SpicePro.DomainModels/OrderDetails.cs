using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicePro.DomainModels
{
    public class OrderDetails
    {
        public int OrderDetailsId { get; set; }
        [Required]
        public int OrderId { get; set; }
        [ForeignKey("OrderId")]
        public virtual OrderHeader OrderHeader { get; set; }       
        

        [Required]
        public int MenuItemId { get; set; }
        public virtual MenuItem MenuItem { get; set; }
        public string Name { get; set; }
        [Required]
        public double Price { get; set; }

    }
}
