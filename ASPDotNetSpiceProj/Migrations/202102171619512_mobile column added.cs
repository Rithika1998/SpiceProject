namespace ASPDotNetSpiceProj.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mobilecolumnadded : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.AspNetUsers", "MobileNo", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.AspNetUsers", "MobileNo");
        }
    }
}
