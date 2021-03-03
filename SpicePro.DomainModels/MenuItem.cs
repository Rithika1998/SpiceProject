using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicePro.DomainModels
{
    public class MenuItem
    {
        [Key]
        public int MenuItemId { get; set; }
        [Required]
        public string MenuName { get; set; }
        public string Description { get; set; }
        public string MImage { get; set; }

        //public Spicy Spicyness { get; set; }

        public string Spicyness { get; set; }
        public enum Spicy
        {
            NA,
            NOT_SPICY,
            SPICY,
            VERY_SPICY
        }
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        public int SubCategoryId { get; set; }
        [ForeignKey("SubCategoryId")]

        public virtual SubCategory SubCategory { get; set; }

        [Range(1,int.MaxValue,ErrorMessage ="Price should be greater than zero")]
        public double Price { get; set; }


    }
}
