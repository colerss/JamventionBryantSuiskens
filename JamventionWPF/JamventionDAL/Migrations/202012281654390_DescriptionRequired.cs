namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class DescriptionRequired : DbMigration
    {
        public override void Up()
        {
            AlterColumn("JAM.OtherRooms", "RoomDescription", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("JAM.OtherRooms", "RoomDescription", c => c.String());
        }
    }
}
