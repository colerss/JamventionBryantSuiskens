namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NewMigration : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("JAM.Guests", "GuestID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropIndex("JAM.Guests", new[] { "GuestID" });
            DropPrimaryKey("JAM.Guests");
            CreateTable(
                "JAM.WorkshopTeacher",
                c => new
                    {
                        WorkshopParticipantID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        WorkshopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkshopParticipantID)
                .ForeignKey("JAM.Workshops", t => t.WorkshopID, cascadeDelete: true)
                .ForeignKey("JAM.Guests", t => t.TeacherID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.WorkshopID);
            
            AlterColumn("JAM.Guests", "GuestID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("JAM.Guests", "GuestID");
            AddForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests", "GuestID", cascadeDelete: true);
            DropColumn("JAM.Workshops", "TeacherID");
        }
        
        public override void Down()
        {
            AddColumn("JAM.Workshops", "TeacherID", c => c.Int(nullable: false));
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopTeacher", "WorkshopID", "JAM.Workshops");
            DropIndex("JAM.WorkshopTeacher", new[] { "WorkshopID" });
            DropIndex("JAM.WorkshopTeacher", new[] { "TeacherID" });
            DropPrimaryKey("JAM.Guests");
            AlterColumn("JAM.Guests", "GuestID", c => c.Int(nullable: false));
            DropTable("JAM.WorkshopTeacher");
            AddPrimaryKey("JAM.Guests", "GuestID");
            RenameColumn(table: "JAM.WorkshopTeacher", name: "TeacherID", newName: "GuestID");
            CreateIndex("JAM.Guests", "GuestID");
            AddForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests", "GuestID", cascadeDelete: true);
            AddForeignKey("JAM.Guests", "GuestID", "JAM.Workshops", "WorkshopID");
        }
    }
}
