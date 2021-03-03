using SpicePro.DomainModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI.WebControls;

namespace ASPDotNetSpiceProj.ViewModels
{
    public class MenuViewModel
    {
        public IEnumerable<SpicePro.DomainModels.MenuItem> MenuItem { get; set; }
        public IEnumerable<Category> Category { get; set; }
        public IEnumerable<Coupon> Coupon { get; set; }

        public IEnumerable<ShoppingCart> ShoppingCarts { get; set; }
    }
}