namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class typofix : DbMigration
    {
        public override void Up()
        {
            DropIndex("JAM.Workshops", new[] { "TimeslotID" });
            CreateIndex("JAM.Workshops", "TimeSlotID");
        }
        
        public override void Down()
        {
            DropIndex("JAM.Workshops", new[] { "TimeSlotID" });
            CreateIndex("JAM.Workshops", "TimeslotID");
        }
    }
}
