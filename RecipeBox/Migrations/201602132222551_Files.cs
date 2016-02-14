namespace RecipeBox.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Files : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.FilePaths", "RecipeID", "dbo.Recipes");
            DropIndex("dbo.FilePaths", new[] { "RecipeID" });
            CreateTable(
                "dbo.Files",
                c => new
                    {
                        FileId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        ContentType = c.String(maxLength: 100),
                        Content = c.Binary(),
                        FileType = c.Int(nullable: false),
                        RecipeId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FileId)
                .ForeignKey("dbo.Recipes", t => t.RecipeId, cascadeDelete: true)
                .Index(t => t.RecipeId);
            
            DropTable("dbo.FilePaths");
        }
        
        public override void Down()
        {
            CreateTable(
                "dbo.FilePaths",
                c => new
                    {
                        FilePathId = c.Int(nullable: false, identity: true),
                        FileName = c.String(maxLength: 255),
                        RecipeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.FilePathId);
            
            DropForeignKey("dbo.Files", "RecipeId", "dbo.Recipes");
            DropIndex("dbo.Files", new[] { "RecipeId" });
            DropTable("dbo.Files");
            CreateIndex("dbo.FilePaths", "RecipeID");
            AddForeignKey("dbo.FilePaths", "RecipeID", "dbo.Recipes", "Id", cascadeDelete: true);
        }
    }
}
