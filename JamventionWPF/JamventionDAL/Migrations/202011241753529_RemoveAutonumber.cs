namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class RemoveAutonumber : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences");
            DropPrimaryKey("JAM.Residences");
            AlterColumn("JAM.Residences", "ResidenceID", c => c.Int(nullable: false));
            AddPrimaryKey("JAM.Residences", "ResidenceID");
            AddForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences", "ResidenceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences");
            DropPrimaryKey("JAM.Residences");
            AlterColumn("JAM.Residences", "ResidenceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("JAM.Residences", "ResidenceID");
            AddForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences", "ResidenceID", cascadeDelete: true);
        }
    }
}
