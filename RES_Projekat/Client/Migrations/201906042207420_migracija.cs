namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class migracija : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientts", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Items", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Positions", "ModelId", "dbo.Models");
            DropIndex("dbo.Clientts", new[] { "ModelId" });
            DropIndex("dbo.Items", new[] { "ModelId" });
            DropIndex("dbo.Positions", new[] { "ModelId" });
            AlterColumn("dbo.Clientts", "ModelId", c => c.Int(nullable: true));
            AlterColumn("dbo.Items", "ModelId", c => c.Int(nullable: true));
            AlterColumn("dbo.Positions", "ModelId", c => c.Int(nullable: true));
            CreateIndex("dbo.Clientts", "ModelId");
            CreateIndex("dbo.Items", "ModelId");
            CreateIndex("dbo.Positions", "ModelId");
            AddForeignKey("dbo.Clientts", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Items", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
            AddForeignKey("dbo.Positions", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Items", "ModelId", "dbo.Models");
            DropForeignKey("dbo.Clientts", "ModelId", "dbo.Models");
            DropIndex("dbo.Positions", new[] { "ModelId" });
            DropIndex("dbo.Items", new[] { "ModelId" });
            DropIndex("dbo.Clientts", new[] { "ModelId" });
            AlterColumn("dbo.Positions", "ModelId", c => c.Int());
            AlterColumn("dbo.Items", "ModelId", c => c.Int());
            AlterColumn("dbo.Clientts", "ModelId", c => c.Int());
            CreateIndex("dbo.Positions", "ModelId");
            CreateIndex("dbo.Items", "ModelId");
            CreateIndex("dbo.Clientts", "ModelId");
            AddForeignKey("dbo.Positions", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.Items", "ModelId", "dbo.Models", "Id");
            AddForeignKey("dbo.Clientts", "ModelId", "dbo.Models", "Id");

        }
    }
}
