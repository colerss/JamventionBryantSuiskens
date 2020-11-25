namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class FixNameForConsistency : DbMigration
    {
        public override void Up()
        {
            AddColumn("JAM.TicketTypes", "TicketName", c => c.String(nullable: false));
            DropColumn("JAM.TicketTypes", "TicketNaam");
        }
        
        public override void Down()
        {
            AddColumn("JAM.TicketTypes", "TicketNaam", c => c.String(nullable: false));
            DropColumn("JAM.TicketTypes", "TicketName");
        }
    }
}
