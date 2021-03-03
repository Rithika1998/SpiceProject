namespace SpicePro.DataLayer.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Addmigrationsformodelclasses : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Coupons",
                c => new
                    {
                        CouponId = c.Int(nullable: false, identity: true),
                        CouponName = c.String(nullable: false),
                        CouponType = c.String(nullable: false),
                        Discount = c.Double(nullable: false),
                        MinimumAmount = c.Double(nullable: false),
                        IsActive = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.CouponId);
            
            CreateTable(
                "dbo.MenuItems",
                c => new
                    {
                        MenuItemId = c.Int(nullable: false, identity: true),
                        MenuName = c.String(nullable: false),
                        Description = c.String(),
                        MImage = c.String(),
                        Spicyness = c.String(),
                        CategoryId = c.Int(nullable: false),
                        SubCategoryId = c.Int(nullable: false),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.MenuItemId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .ForeignKey("dbo.SubCategories", t => t.SubCategoryId)
                .Index(t => t.CategoryId)
                .Index(t => t.SubCategoryId);
            
            CreateTable(
                "dbo.SubCategories",
                c => new
                    {
                        SubCategoryId = c.Int(nullable: false, identity: true),
                        SubCategoryName = c.String(nullable: false),
                        CategoryId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.SubCategoryId)
                .ForeignKey("dbo.Categories", t => t.CategoryId)
                .Index(t => t.CategoryId);
            
            CreateTable(
                "dbo.OrderDetails",
                c => new
                    {
                        OrderDetailsId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        MenuItemId = c.Int(nullable: false),
                        Name = c.String(),
                        Price = c.Double(nullable: false),
                    })
                .PrimaryKey(t => t.OrderDetailsId)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId)
                .ForeignKey("dbo.OrderHeaders", t => t.OrderId)
                .Index(t => t.OrderId)
                .Index(t => t.MenuItemId);
            
            CreateTable(
                "dbo.OrderHeaders",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(nullable: false),
                        OrderDate = c.DateTime(nullable: false),
                        OrderTotalOriginal = c.Double(nullable: false),
                        OrderTotal = c.Double(nullable: false),
                        PickUpTime = c.DateTime(nullable: false),
                        PickUpDate = c.DateTime(nullable: false),
                        CouponCode = c.String(nullable: false),
                        CouponCodeDiscount = c.Double(nullable: false),
                        Status = c.String(),
                        PaymentStatus = c.String(),
                        Comments = c.String(),
                        PickUpName = c.String(),
                        PhoneNumber = c.String(),
                        TransactionId = c.String(),
                    })
                .PrimaryKey(t => t.OrderId);
            
            CreateTable(
                "dbo.ShoppingCarts",
                c => new
                    {
                        ShoppingId = c.Int(nullable: false, identity: true),
                        ApplicationUserId = c.String(),
                        MenuItemId = c.Int(nullable: false),
                        Count = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ShoppingId)
                .ForeignKey("dbo.MenuItems", t => t.MenuItemId)
                .Index(t => t.MenuItemId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.ShoppingCarts", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.OrderDetails", "OrderId", "dbo.OrderHeaders");
            DropForeignKey("dbo.OrderDetails", "MenuItemId", "dbo.MenuItems");
            DropForeignKey("dbo.MenuItems", "SubCategoryId", "dbo.SubCategories");
            DropForeignKey("dbo.SubCategories", "CategoryId", "dbo.Categories");
            DropForeignKey("dbo.MenuItems", "CategoryId", "dbo.Categories");
            DropIndex("dbo.ShoppingCarts", new[] { "MenuItemId" });
            DropIndex("dbo.OrderDetails", new[] { "MenuItemId" });
            DropIndex("dbo.OrderDetails", new[] { "OrderId" });
            DropIndex("dbo.SubCategories", new[] { "CategoryId" });
            DropIndex("dbo.MenuItems", new[] { "SubCategoryId" });
            DropIndex("dbo.MenuItems", new[] { "CategoryId" });
            DropTable("dbo.ShoppingCarts");
            DropTable("dbo.OrderHeaders");
            DropTable("dbo.OrderDetails");
            DropTable("dbo.SubCategories");
            DropTable("dbo.MenuItems");
            DropTable("dbo.Coupons");
            DropTable("dbo.Categories");
        }
    }
}
