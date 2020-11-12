namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class AddedForeignKeysToItemsandPositions : DbMigration
    {
        public override void Up()
        {
            RenameColumn(table: "dbo.Items", name: "Model_Id", newName: "ModelId");
            RenameColumn(table: "dbo.Positions", name: "Model_Id", newName: "ModelId");
            RenameIndex(table: "dbo.Items", name: "IX_Model_Id", newName: "IX_ModelId");
            RenameIndex(table: "dbo.Positions", name: "IX_Model_Id", newName: "IX_ModelId");
        }
        
        public override void Down()
        {
            RenameIndex(table: "dbo.Positions", name: "IX_ModelId", newName: "IX_Model_Id");
            RenameIndex(table: "dbo.Items", name: "IX_ModelId", newName: "IX_Model_Id");
            RenameColumn(table: "dbo.Positions", name: "ModelId", newName: "Model_Id");
            RenameColumn(table: "dbo.Items", name: "ModelId", newName: "Model_Id");
        }
    }
}
