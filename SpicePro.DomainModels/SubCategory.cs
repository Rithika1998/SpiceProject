using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicePro.DomainModels
{
     public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }

        [Required]
        [Display(Name ="SubCategory Name")]
        public string SubCategoryName { get; set; }

        [Required]
       
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }

    }
}
