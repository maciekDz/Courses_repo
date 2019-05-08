namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddUserIdToOrderModel : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Order", name: "ApplicationUser_Id", newName: "UserId");
            RenameIndex(table: "dbo.Order", name: "IX_ApplicationUser_Id", newName: "IX_UserId");
            AddColumn("dbo.Order", "LastName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "PhoneNumber", c => c.String(nullable: false, maxLength: 20));
            AlterColumn("dbo.Order", "Email", c => c.String(nullable: false));
            DropColumn("dbo.Order", "SecondName");
        }
        
        public override void Down()
        {
            AddColumn("dbo.Order", "SecondName", c => c.String(nullable: false, maxLength: 50));
            AlterColumn("dbo.Order", "Email", c => c.String());
            AlterColumn("dbo.Order", "PhoneNumber", c => c.String());
            DropColumn("dbo.Order", "LastName");
            RenameIndex(table: "dbo.Order", name: "IX_UserId", newName: "IX_ApplicationUser_Id");
            RenameColumn(table: "dbo.Order", name: "UserId", newName: "ApplicationUser_Id");
        }
    }
}
