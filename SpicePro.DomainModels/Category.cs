using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicePro.DomainModels
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }

        [Display(Name ="Category Name")]
        public string CName { get; set; }

    }
}
