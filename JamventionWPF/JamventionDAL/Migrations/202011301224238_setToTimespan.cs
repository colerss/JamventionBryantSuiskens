namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class setToTimespan : DbMigration
    {
        public override void Up()
        {
            AlterColumn("JAM.TimeSlots", "StartTime", c => c.Time(nullable: false, precision: 7));
            AlterColumn("JAM.TimeSlots", "EndTime", c => c.Time(nullable: false, precision: 7));
        }
        
        public override void Down()
        {
            AlterColumn("JAM.TimeSlots", "EndTime", c => c.DateTime(nullable: false));
            AlterColumn("JAM.TimeSlots", "StartTime", c => c.DateTime(nullable: false));
        }
    }
}
