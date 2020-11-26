namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "JAM.GuestRoles",
                c => new
                    {
                        RoleID = c.Int(nullable: false, identity: true),
                        RoleName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.RoleID);
            
            CreateTable(
                "JAM.Guests",
                c => new
                    {
                        GuestID = c.Int(nullable: false),
                        FirstName = c.String(nullable: false, maxLength: 30),
                        LastName = c.String(nullable: false, maxLength: 30),
                        ResidenceID = c.Int(nullable: false),
                        EmailAddress = c.String(nullable: false, maxLength: 50),
                        TelephoneNr = c.String(maxLength: 15),
                        IsVegetarian = c.Boolean(nullable: false),
                        RoleID = c.Int(nullable: false),
                        InvoiceID = c.Int(),
                        RoomID = c.Int(),
                    })
                .PrimaryKey(t => t.GuestID)
                .ForeignKey("JAM.GuestRoles", t => t.RoleID, cascadeDelete: true)
                .ForeignKey("JAM.Invoices", t => t.InvoiceID)
                .ForeignKey("JAM.Residences", t => t.ResidenceID, cascadeDelete: true)
                .ForeignKey("JAM.Rooms", t => t.RoomID)
                .Index(t => t.ResidenceID)
                .Index(t => t.RoleID)
                .Index(t => t.InvoiceID)
                .Index(t => t.RoomID);
            
            CreateTable(
                "JAM.Invoices",
                c => new
                    {
                        InvoiceID = c.Int(nullable: false),
                        DebitorNr = c.Int(nullable: false),
                        TicketTypeID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.InvoiceID)
                .ForeignKey("JAM.TicketTypes", t => t.TicketTypeID, cascadeDelete: true)
                .Index(t => t.TicketTypeID);
            
            CreateTable(
                "JAM.Payments",
                c => new
                    {
                        PaymentID = c.Int(nullable: false, identity: true),
                        PaymentDate = c.DateTime(nullable: false),
                        Amount = c.Decimal(nullable: false, storeType: "money"),
                        InvoiceID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.PaymentID)
                .ForeignKey("JAM.Invoices", t => t.InvoiceID, cascadeDelete: true)
                .Index(t => t.InvoiceID);
            
            CreateTable(
                "JAM.TicketTypes",
                c => new
                    {
                        TicketTypeID = c.Int(nullable: false, identity: true),
                        TicketName = c.String(nullable: false),
                        TicketPrice = c.Decimal(nullable: false, storeType: "money"),
                        OnFriday = c.Boolean(nullable: false),
                        OnSaturday = c.Boolean(nullable: false),
                        OnSunday = c.Boolean(nullable: false),
                    })
                .PrimaryKey(t => t.TicketTypeID);
            
            CreateTable(
                "JAM.Residences",
                c => new
                    {
                        ResidenceID = c.Int(nullable: false),
                        PostalCode = c.String(maxLength: 10),
                        City = c.String(nullable: false),
                        Address = c.String(nullable: false),
                        NationalityID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.ResidenceID)
                .ForeignKey("JAM.Nationalities", t => t.NationalityID, cascadeDelete: true)
                .Index(t => t.NationalityID);
            
            CreateTable(
                "JAM.Nationalities",
                c => new
                    {
                        NationalityID = c.Int(nullable: false, identity: true),
                        CountryName = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.NationalityID);
            
            CreateTable(
                "JAM.Rooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false, identity: true),
                        Beds = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.RoomID);
            
            CreateTable(
                "JAM.RoomTypes",
                c => new
                    {
                        RoomTypeID = c.Int(nullable: false, identity: true),
                        TypeName = c.String(nullable: false, maxLength: 30),
                    })
                .PrimaryKey(t => t.RoomTypeID);
            
            CreateTable(
                "JAM.WorkshopModels",
                c => new
                    {
                        WorkshopModelID = c.Int(nullable: false, identity: true),
                        ModelID = c.Int(nullable: false),
                        WorkshopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkshopModelID)
                .ForeignKey("JAM.Guests", t => t.ModelID, cascadeDelete: true)
                .ForeignKey("JAM.Workshops", t => t.WorkshopID, cascadeDelete: true)
                .Index(t => t.ModelID)
                .Index(t => t.WorkshopID);
            
            CreateTable(
                "JAM.Workshops",
                c => new
                    {
                        WorkshopID = c.Int(nullable: false, identity: true),
                        Name = c.String(nullable: false),
                        TimeslotID = c.Int(nullable: false),
                        LocatieID = c.Int(nullable: false),
                        Slots = c.Int(nullable: false),
                        Location_LocationID = c.Int(),
                    })
                .PrimaryKey(t => t.WorkshopID)
                .ForeignKey("JAM.Locations", t => t.Location_LocationID)
                .ForeignKey("JAM.TimeSlots", t => t.TimeslotID, cascadeDelete: true)
                .Index(t => t.TimeslotID)
                .Index(t => t.Location_LocationID);
            
            CreateTable(
                "JAM.Locations",
                c => new
                    {
                        LocationID = c.Int(nullable: false, identity: true),
                        LocationName = c.String(),
                    })
                .PrimaryKey(t => t.LocationID);
            
            CreateTable(
                "JAM.WorkshopParticipants",
                c => new
                    {
                        WorkshopParticipantID = c.Int(nullable: false, identity: true),
                        GuestID = c.Int(nullable: false),
                        WorkshopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkshopParticipantID)
                .ForeignKey("JAM.Guests", t => t.GuestID, cascadeDelete: true)
                .ForeignKey("JAM.Workshops", t => t.WorkshopID, cascadeDelete: true)
                .Index(t => t.GuestID)
                .Index(t => t.WorkshopID);
            
            CreateTable(
                "JAM.WorkshopTeacher",
                c => new
                    {
                        WorkshopParticipantID = c.Int(nullable: false, identity: true),
                        TeacherID = c.Int(nullable: false),
                        WorkshopID = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.WorkshopParticipantID)
                .ForeignKey("JAM.Guests", t => t.TeacherID, cascadeDelete: true)
                .ForeignKey("JAM.Workshops", t => t.WorkshopID, cascadeDelete: true)
                .Index(t => t.TeacherID)
                .Index(t => t.WorkshopID);
            
            CreateTable(
                "JAM.TimeSlots",
                c => new
                    {
                        TimeSlotID = c.Int(nullable: false, identity: true),
                        Day = c.DateTime(nullable: false),
                        StartTime = c.DateTime(nullable: false),
                        EndTime = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.TimeSlotID);
            
            CreateTable(
                "JAM.LocalRooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false),
                        RoomTypeID = c.Int(nullable: false),
                        RoomCode = c.String(nullable: false, maxLength: 5),
                        RoomColor = c.String(nullable: false, maxLength: 20),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("JAM.Rooms", t => t.RoomID)
                .ForeignKey("JAM.RoomTypes", t => t.RoomTypeID, cascadeDelete: true)
                .Index(t => t.RoomID)
                .Index(t => t.RoomTypeID);
            
            CreateTable(
                "JAM.OtherRooms",
                c => new
                    {
                        RoomID = c.Int(nullable: false),
                        RoomDescription = c.String(),
                    })
                .PrimaryKey(t => t.RoomID)
                .ForeignKey("JAM.Rooms", t => t.RoomID)
                .Index(t => t.RoomID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("JAM.OtherRooms", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.LocalRooms", "RoomTypeID", "JAM.RoomTypes");
            DropForeignKey("JAM.LocalRooms", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.Workshops", "TimeslotID", "JAM.TimeSlots");
            DropForeignKey("JAM.WorkshopTeacher", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopTeacher", "TeacherID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopParticipants", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopParticipants", "GuestID", "JAM.Guests");
            DropForeignKey("JAM.WorkshopModels", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations");
            DropForeignKey("JAM.WorkshopModels", "ModelID", "JAM.Guests");
            DropForeignKey("JAM.Guests", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.Residences", "NationalityID", "JAM.Nationalities");
            DropForeignKey("JAM.Guests", "ResidenceID", "JAM.Residences");
            DropForeignKey("JAM.Invoices", "TicketTypeID", "JAM.TicketTypes");
            DropForeignKey("JAM.Payments", "InvoiceID", "JAM.Invoices");
            DropForeignKey("JAM.Guests", "InvoiceID", "JAM.Invoices");
            DropForeignKey("JAM.Guests", "RoleID", "JAM.GuestRoles");
            DropIndex("JAM.OtherRooms", new[] { "RoomID" });
            DropIndex("JAM.LocalRooms", new[] { "RoomTypeID" });
            DropIndex("JAM.LocalRooms", new[] { "RoomID" });
            DropIndex("JAM.WorkshopTeacher", new[] { "WorkshopID" });
            DropIndex("JAM.WorkshopTeacher", new[] { "TeacherID" });
            DropIndex("JAM.WorkshopParticipants", new[] { "WorkshopID" });
            DropIndex("JAM.WorkshopParticipants", new[] { "GuestID" });
            DropIndex("JAM.Workshops", new[] { "Location_LocationID" });
            DropIndex("JAM.Workshops", new[] { "TimeslotID" });
            DropIndex("JAM.WorkshopModels", new[] { "WorkshopID" });
            DropIndex("JAM.WorkshopModels", new[] { "ModelID" });
            DropIndex("JAM.Residences", new[] { "NationalityID" });
            DropIndex("JAM.Payments", new[] { "InvoiceID" });
            DropIndex("JAM.Invoices", new[] { "TicketTypeID" });
            DropIndex("JAM.Guests", new[] { "RoomID" });
            DropIndex("JAM.Guests", new[] { "InvoiceID" });
            DropIndex("JAM.Guests", new[] { "RoleID" });
            DropIndex("JAM.Guests", new[] { "ResidenceID" });
            DropTable("JAM.OtherRooms");
            DropTable("JAM.LocalRooms");
            DropTable("JAM.TimeSlots");
            DropTable("JAM.WorkshopTeacher");
            DropTable("JAM.WorkshopParticipants");
            DropTable("JAM.Locations");
            DropTable("JAM.Workshops");
            DropTable("JAM.WorkshopModels");
            DropTable("JAM.RoomTypes");
            DropTable("JAM.Rooms");
            DropTable("JAM.Nationalities");
            DropTable("JAM.Residences");
            DropTable("JAM.TicketTypes");
            DropTable("JAM.Payments");
            DropTable("JAM.Invoices");
            DropTable("JAM.Guests");
            DropTable("JAM.GuestRoles");
        }
    }
}
