namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NotMappedClients : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("dbo.Clientts", "
                ", "dbo.Models");
            DropIndex("dbo.Clientts", new[] { "ModelId" });
            AlterColumn("dbo.Clientts", "ModelId", c => c.Int());
            CreateIndex("dbo.Clientts", "ModelId");
            AddForeignKey("dbo.Clientts", "ModelId", "dbo.Models", "Id");
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Clientts", "ModelId", "dbo.Models");
            DropIndex("dbo.Clientts", new[] { "ModelId" });
            AlterColumn("dbo.Clientts", "ModelId", c => c.Int(nullable: false));
            CreateIndex("dbo.Clientts", "ModelId");
            AddForeignKey("dbo.Clientts", "ModelId", "dbo.Models", "Id", cascadeDelete: true);
        }
    }
}
