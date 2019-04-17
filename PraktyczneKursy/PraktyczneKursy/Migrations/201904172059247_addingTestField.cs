namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class addingTestField : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Course", "Test", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Course", "Test");
        }
    }
}
