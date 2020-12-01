namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typofix2 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations");
            DropIndex("JAM.Workshops", new[] { "Location_LocationID" });
            RenameColumn(table: "JAM.Workshops", name: "Location_LocationID", newName: "LocationID");
            AlterColumn("JAM.Workshops", "LocationID", c => c.Int(nullable: false));
            CreateIndex("JAM.Workshops", "LocationID");
            AddForeignKey("JAM.Workshops", "LocationID", "JAM.Locations", "LocationID", cascadeDelete: true);
            DropColumn("JAM.Workshops", "LocatieID");
        }
        
        public override void Down()
        {
            AddColumn("JAM.Workshops", "LocatieID", c => c.Int(nullable: false));
            DropForeignKey("JAM.Workshops", "LocationID", "JAM.Locations");
            DropIndex("JAM.Workshops", new[] { "LocationID" });
            AlterColumn("JAM.Workshops", "LocationID", c => c.Int());
            RenameColumn(table: "JAM.Workshops", name: "LocationID", newName: "Location_LocationID");
            CreateIndex("JAM.Workshops", "Location_LocationID");
            AddForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations", "LocationID");
        }
    }
}
