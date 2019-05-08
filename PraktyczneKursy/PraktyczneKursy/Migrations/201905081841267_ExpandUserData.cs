namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class ExpandUserData : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Order", "Address", c => c.String(nullable: false, maxLength: 100));
            AddColumn("dbo.AspNetUsers", "UserData_PostalCode", c => c.String());
            DropColumn("dbo.Order", "Street");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "Street", c => c.String(nullable: false, maxLength: 100));
            DropColumn("dbo.AspNetUsers", "UserData_PostalCode");
            DropColumn("dbo.Order", "Address");
        }
    }
}
