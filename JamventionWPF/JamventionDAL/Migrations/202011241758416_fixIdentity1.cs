namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixIdentity1 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests");
            DropForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences");
            DropPrimaryKey("JAM.Guests");
            DropPrimaryKey("JAM.Residences");
            AlterColumn("JAM.Guests", "GuestID", c => c.Int(nullable: false));
            AlterColumn("JAM.Residences", "ResidenceID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("JAM.Guests", "GuestID");
            AddPrimaryKey("JAM.Residences", "ResidenceID");
            AddForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences", "ResidenceID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences");
            DropForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropPrimaryKey("JAM.Residences");
            DropPrimaryKey("JAM.Guests");
            AlterColumn("JAM.Residences", "ResidenceID", c => c.Int(nullable: false));
            AlterColumn("JAM.Guests", "GuestID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("JAM.Residences", "ResidenceID");
            AddPrimaryKey("JAM.Guests", "GuestID");
            AddForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences", "ResidenceID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests", "GuestID", cascadeDelete: true);
        }
    }
}
