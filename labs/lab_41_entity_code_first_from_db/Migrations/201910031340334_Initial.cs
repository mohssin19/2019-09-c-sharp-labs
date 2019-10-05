namespace lab_41_entity_code_first_from_db.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Initial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Batch",
                c => new
                    {
                        BatchId = c.Int(nullable: false, identity: true),
                        OrangeId = c.Int(),
                        Quantity = c.Int(),
                        DespatchDate = c.DateTime(storeType: "date"),
                    })
                .PrimaryKey(t => t.BatchId)
                .ForeignKey("dbo.Oranges", t => t.OrangeId)
                .Index(t => t.OrangeId);
            
            CreateTable(
                "dbo.Oranges",
                c => new
                    {
                        OrangeId = c.Int(nullable: false, identity: true),
                        OrangeName = c.String(maxLength: 50),
                        DateHarvested = c.DateTime(storeType: "date"),
                        IsLuxuryGrade = c.Boolean(),
                        OrangeCategoryId = c.Int(),
                    })
                .PrimaryKey(t => t.OrangeId)
                .ForeignKey("dbo.Categories", t => t.OrangeCategoryId)
                .Index(t => t.OrangeCategoryId);
            
            CreateTable(
                "dbo.Categories",
                c => new
                    {
                        CategoryId = c.Int(nullable: false, identity: true),
                        CategoryName = c.String(maxLength: 50),
                    })
                .PrimaryKey(t => t.CategoryId);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Oranges", "OrangeCategoryId", "dbo.Categories");
            DropForeignKey("dbo.Batch", "OrangeId", "dbo.Oranges");
            DropIndex("dbo.Oranges", new[] { "OrangeCategoryId" });
            DropIndex("dbo.Batch", new[] { "OrangeId" });
            DropTable("dbo.Categories");
            DropTable("dbo.Oranges");
            DropTable("dbo.Batch");
        }
    }
}
