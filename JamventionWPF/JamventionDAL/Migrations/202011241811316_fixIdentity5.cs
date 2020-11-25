namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixIdentity5 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests");
            DropPrimaryKey("JAM.Guests");
            AlterColumn("JAM.Guests", "GuestID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("JAM.Guests", "GuestID");
            AddForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests", "GuestID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropPrimaryKey("JAM.Guests");
            AlterColumn("JAM.Guests", "GuestID", c => c.Int(nullable: false));
            AddPrimaryKey("JAM.Guests", "GuestID");
            AddForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests", "GuestID", cascadeDelete: true);
        }
    }
}
