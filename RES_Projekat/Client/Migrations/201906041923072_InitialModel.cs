namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialModel : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Clientts",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        ModelId = c.Int(),
                        Naziv_klijenta = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.ModelId)
                .Index(t => t.ModelId);
            
            CreateTable(
                "dbo.Models",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Items",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Naziv = c.String(),
                        Kolicina = c.Int(nullable: false),
                        Aktiviran = c.Boolean(nullable: false),
                        Razorna_moc = c.Int(nullable: false),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .Index(t => t.Model_Id);
            
            CreateTable(
                "dbo.Positions",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        X = c.Double(nullable: false),
                        Y = c.Double(nullable: false),
                        Z = c.Double(nullable: false),
                        Model_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Models", t => t.Model_Id)
                .Index(t => t.Model_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Positions", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Items", "Model_Id", "dbo.Models");
            DropForeignKey("dbo.Clientts", "ModelId", "dbo.Models");
            DropIndex("dbo.Positions", new[] { "Model_Id" });
            DropIndex("dbo.Items", new[] { "Model_Id" });
            DropIndex("dbo.Clientts", new[] { "ModelId" });
            DropTable("dbo.Positions");
            DropTable("dbo.Items");
            DropTable("dbo.Models");
            DropTable("dbo.Clientts");
        }
    }
}
