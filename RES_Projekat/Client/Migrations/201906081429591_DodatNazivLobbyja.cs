namespace Client.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DodatNazivLobbyja : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Clientts", "Naziv_trenutnog_lobbyja", c => c.String());
        }
        
        public override void Down()
        {
            DropColumn("dbo.Clientts", "Naziv_trenutnog_lobbyja");
        }
    }
}
