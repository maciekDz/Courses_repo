namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NameChanges : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.OrderElement", "CourseId", "dbo.Course");
            DropForeignKey("dbo.OrderElement", "OrderId", "dbo.Order");
            DropIndex("dbo.OrderElement", new[] { "OrderId" });
            DropIndex("dbo.OrderElement", new[] { "CourseId" });
            CreateTable(
                "dbo.OrderItem",
                c => new
                    {
                        OrderItemId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Quatity = c.Int(nullable: false),
                        PurchaseValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderItemId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CourseId);
            
            DropTable("dbo.OrderElement");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.OrderElement",
                c => new
                    {
                        OrderElementId = c.Int(nullable: false, identity: true),
                        OrderId = c.Int(nullable: false),
                        CourseId = c.Int(nullable: false),
                        Quatity = c.Int(nullable: false),
                        PurchaseValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderElementId);
            
            DropForeignKey("dbo.OrderItem", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderItem", "CourseId", "dbo.Course");
            DropIndex("dbo.OrderItem", new[] { "CourseId" });
            DropIndex("dbo.OrderItem", new[] { "OrderId" });
            DropTable("dbo.OrderItem");
            CreateIndex("dbo.OrderElement", "CourseId");
            CreateIndex("dbo.OrderElement", "OrderId");
            AddForeignKey("dbo.OrderElement", "OrderId", "dbo.Order", "OrderId", cascadeDelete: true);
            AddForeignKey("dbo.OrderElement", "CourseId", "dbo.Course", "CourseId", cascadeDelete: true);
        }
    }
}
