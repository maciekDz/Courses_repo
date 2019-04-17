namespace PraktyczneKursy.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Category",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(nullable: false, maxLength: 100),
                        CategoryDescription = c.String(nullable: false),
                        IconFileName = c.String(),
                    })
                .PrimaryKey(t => t.CategoryId);
            
            CreateTable(
                "dbo.Course",
                c => new
                    {
                        CourseId = c.Int(nullable: false, identity: true),
                        CategotyId = c.Int(nullable: false),
                        CourseTitle = c.String(nullable: false, maxLength: 100),
                        CourseAuthor = c.String(nullable: false, maxLength: 100),
                        InsertDate = c.DateTime(nullable: false),
                        FileOrPicturePhotoName = c.String(maxLength: 100),
                        CourseDescription = c.String(),
                        CoursePrice = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Bestseller = c.Boolean(nullable: false),
                        Hidden = c.Boolean(nullable: false),
                        Category_CategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.CourseId)
                .ForeignKey("dbo.Category", t => t.Category_CategoryId)
                .Index(t => t.Category_CategoryId);
            
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
                .PrimaryKey(t => t.OrderElementId)
                .ForeignKey("dbo.Course", t => t.CourseId, cascadeDelete: true)
                .ForeignKey("dbo.Order", t => t.OrderId, cascadeDelete: true)
                .Index(t => t.OrderId)
                .Index(t => t.CourseId);
            
            CreateTable(
                "dbo.Order",
                c => new
                    {
                        OrderId = c.Int(nullable: false, identity: true),
                        FirstName = c.String(nullable: false, maxLength: 50),
                        SecondName = c.String(nullable: false, maxLength: 50),
                        Street = c.String(nullable: false, maxLength: 100),
                        City = c.String(nullable: false, maxLength: 100),
                        PostalCode = c.String(nullable: false, maxLength: 6),
                        PhoneNumber = c.String(),
                        Email = c.String(),
                        Comment = c.String(),
                        OrderDate = c.DateTime(nullable: false),
                        OrderState = c.Int(nullable: false),
                        OrderValue = c.Decimal(nullable: false, precision: 18, scale: 2),
                    })
                .PrimaryKey(t => t.OrderId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.OrderElement", "OrderId", "dbo.Order");
            DropForeignKey("dbo.OrderElement", "CourseId", "dbo.Course");
            DropForeignKey("dbo.Course", "Category_CategoryId", "dbo.Category");
            DropIndex("dbo.OrderElement", new[] { "CourseId" });
            DropIndex("dbo.OrderElement", new[] { "OrderId" });
            DropIndex("dbo.Course", new[] { "Category_CategoryId" });
            DropTable("dbo.Order");
            DropTable("dbo.OrderElement");
            DropTable("dbo.Course");
            DropTable("dbo.Category");
        }
    }
}
