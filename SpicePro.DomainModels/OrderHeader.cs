using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpicePro.DomainModels
{
    public class OrderHeader
    {
        [Key]
        public int OrderId { get; set; }
        [Required]
        public string ApplicationUserId { get; set; }   
       
        [Required]
        public DateTime OrderDate { get; set; }
        [Required]
        public double OrderTotalOriginal { get; set; }
        public double OrderTotal { get; set; }
        [Required]
        public DateTime PickUpTime { get; set; }
        [Required]
        public DateTime PickUpDate { get; set; }
        [Required]
        public string CouponCode { get; set; }
        public double CouponCodeDiscount { get; set; }
        public string Status { get; set; }
        public string PaymentStatus { get; set; }
        public string Comments { get; set; }
        public string PickUpName { get; set; }
        public string PhoneNumber { get; set; }
        public string TransactionId { get; set; }


    }
}
