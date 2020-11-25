namespace JamventionDAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class fixIdentity3 : DbMigration
    {
        public override void Up()
        {
            DropForeignKey("JAM.Payments", "InvoiceID", "JAM.Invoices");
            DropForeignKey("JAM.Guests", "InvoiceId", "JAM.Invoices");
            DropForeignKey("JAM.Invoices", "TicketTypeID", "JAM.TicketTypes");
            DropForeignKey("JAM.Residences", "NationalityID", "JAM.Nationalities");
            DropForeignKey("JAM.Guests", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.LocalRooms", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.OtherRooms", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.LocalRooms", "RoomTypeID", "JAM.RoomTypes");
            DropForeignKey("JAM.WorkshopModels", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopParticipants", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopTeacher", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations");
            DropForeignKey("JAM.Workshops", "TimeslotID", "JAM.TimeSlots");
            DropPrimaryKey("JAM.Invoices");
            DropPrimaryKey("JAM.Payments");
            DropPrimaryKey("JAM.TicketTypes");
            DropPrimaryKey("JAM.Nationalities");
            DropPrimaryKey("JAM.Rooms");
            DropPrimaryKey("JAM.RoomTypes");
            DropPrimaryKey("JAM.WorkshopModels");
            DropPrimaryKey("JAM.Workshops");
            DropPrimaryKey("JAM.Locations");
            DropPrimaryKey("JAM.WorkshopParticipants");
            DropPrimaryKey("JAM.WorkshopTeacher");
            DropPrimaryKey("JAM.TimeSlots");
            AlterColumn("JAM.Invoices", "InvoiceID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.Payments", "PaymentID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.TicketTypes", "TicketTypeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.Nationalities", "NationalityID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.Rooms", "RoomID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.RoomTypes", "RoomTypeID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.WorkshopModels", "WorkshopModelID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.Workshops", "WorkshopID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.Locations", "LocationID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.WorkshopParticipants", "WorkshopParticipantID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.WorkshopTeacher", "WorkshopParticipantID", c => c.Int(nullable: false, identity: true));
            AlterColumn("JAM.TimeSlots", "TimeSlotID", c => c.Int(nullable: false, identity: true));
            AddPrimaryKey("JAM.Invoices", "InvoiceID");
            AddPrimaryKey("JAM.Payments", "PaymentID");
            AddPrimaryKey("JAM.TicketTypes", "TicketTypeID");
            AddPrimaryKey("JAM.Nationalities", "NationalityID");
            AddPrimaryKey("JAM.Rooms", "RoomID");
            AddPrimaryKey("JAM.RoomTypes", "RoomTypeID");
            AddPrimaryKey("JAM.WorkshopModels", "WorkshopModelID");
            AddPrimaryKey("JAM.Workshops", "WorkshopID");
            AddPrimaryKey("JAM.Locations", "LocationID");
            AddPrimaryKey("JAM.WorkshopParticipants", "WorkshopParticipantID");
            AddPrimaryKey("JAM.WorkshopTeacher", "WorkshopParticipantID");
            AddPrimaryKey("JAM.TimeSlots", "TimeSlotID");
            AddForeignKey("JAM.Payments", "InvoiceID", "JAM.Invoices", "InvoiceID", cascadeDelete: true);
            AddForeignKey("JAM.Guests", "InvoiceId", "JAM.Invoices", "InvoiceID");
            AddForeignKey("JAM.Invoices", "TicketTypeID", "JAM.TicketTypes", "TicketTypeID", cascadeDelete: true);
            AddForeignKey("JAM.Residences", "NationalityID", "JAM.Nationalities", "NationalityID", cascadeDelete: true);
            AddForeignKey("JAM.Guests", "RoomID", "JAM.Rooms", "RoomID");
            AddForeignKey("JAM.LocalRooms", "RoomID", "JAM.Rooms", "RoomID");
            AddForeignKey("JAM.OtherRooms", "RoomID", "JAM.Rooms", "RoomID");
            AddForeignKey("JAM.LocalRooms", "RoomTypeID", "JAM.RoomTypes", "RoomTypeID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopModels", "WorkshopID", "JAM.Workshops", "WorkshopID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "WorkshopID", "JAM.Workshops", "WorkshopID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopTeacher", "WorkshopID", "JAM.Workshops", "WorkshopID", cascadeDelete: true);
            AddForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations", "LocationID");
            AddForeignKey("JAM.Workshops", "TimeslotID", "JAM.TimeSlots", "TimeSlotID", cascadeDelete: true);
        }
        
        public override void Down()
        {
            DropForeignKey("JAM.Workshops", "TimeslotID", "JAM.TimeSlots");
            DropForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations");
            DropForeignKey("JAM.WorkshopTeacher", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopParticipants", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.WorkshopModels", "WorkshopID", "JAM.Workshops");
            DropForeignKey("JAM.LocalRooms", "RoomTypeID", "JAM.RoomTypes");
            DropForeignKey("JAM.OtherRooms", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.LocalRooms", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.Guests", "RoomID", "JAM.Rooms");
            DropForeignKey("JAM.Residences", "NationalityID", "JAM.Nationalities");
            DropForeignKey("JAM.Invoices", "TicketTypeID", "JAM.TicketTypes");
            DropForeignKey("JAM.Guests", "InvoiceId", "JAM.Invoices");
            DropForeignKey("JAM.Payments", "InvoiceID", "JAM.Invoices");
            DropPrimaryKey("JAM.TimeSlots");
            DropPrimaryKey("JAM.WorkshopTeacher");
            DropPrimaryKey("JAM.WorkshopParticipants");
            DropPrimaryKey("JAM.Locations");
            DropPrimaryKey("JAM.Workshops");
            DropPrimaryKey("JAM.WorkshopModels");
            DropPrimaryKey("JAM.RoomTypes");
            DropPrimaryKey("JAM.Rooms");
            DropPrimaryKey("JAM.Nationalities");
            DropPrimaryKey("JAM.TicketTypes");
            DropPrimaryKey("JAM.Payments");
            DropPrimaryKey("JAM.Invoices");
            AlterColumn("JAM.TimeSlots", "TimeSlotID", c => c.Int(nullable: false));
            AlterColumn("JAM.WorkshopTeacher", "WorkshopParticipantID", c => c.Int(nullable: false));
            AlterColumn("JAM.WorkshopParticipants", "WorkshopParticipantID", c => c.Int(nullable: false));
            AlterColumn("JAM.Locations", "LocationID", c => c.Int(nullable: false));
            AlterColumn("JAM.Workshops", "WorkshopID", c => c.Int(nullable: false));
            AlterColumn("JAM.WorkshopModels", "WorkshopModelID", c => c.Int(nullable: false));
            AlterColumn("JAM.RoomTypes", "RoomTypeID", c => c.Int(nullable: false));
            AlterColumn("JAM.Rooms", "RoomID", c => c.Int(nullable: false));
            AlterColumn("JAM.Nationalities", "NationalityID", c => c.Int(nullable: false));
            AlterColumn("JAM.TicketTypes", "TicketTypeID", c => c.Int(nullable: false));
            AlterColumn("JAM.Payments", "PaymentID", c => c.Int(nullable: false));
            AlterColumn("JAM.Invoices", "InvoiceID", c => c.Int(nullable: false));
            AddPrimaryKey("JAM.TimeSlots", "TimeSlotID");
            AddPrimaryKey("JAM.WorkshopTeacher", "WorkshopParticipantID");
            AddPrimaryKey("JAM.WorkshopParticipants", "WorkshopParticipantID");
            AddPrimaryKey("JAM.Locations", "LocationID");
            AddPrimaryKey("JAM.Workshops", "WorkshopID");
            AddPrimaryKey("JAM.WorkshopModels", "WorkshopModelID");
            AddPrimaryKey("JAM.RoomTypes", "RoomTypeID");
            AddPrimaryKey("JAM.Rooms", "RoomID");
            AddPrimaryKey("JAM.Nationalities", "NationalityID");
            AddPrimaryKey("JAM.TicketTypes", "TicketTypeID");
            AddPrimaryKey("JAM.Payments", "PaymentID");
            AddPrimaryKey("JAM.Invoices", "InvoiceID");
            AddForeignKey("JAM.Workshops", "TimeslotID", "JAM.TimeSlots", "TimeSlotID", cascadeDelete: true);
            AddForeignKey("JAM.Workshops", "Location_LocationID", "JAM.Locations", "LocationID");
            AddForeignKey("JAM.WorkshopTeacher", "WorkshopID", "JAM.Workshops", "WorkshopID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopParticipants", "WorkshopID", "JAM.Workshops", "WorkshopID", cascadeDelete: true);
            AddForeignKey("JAM.WorkshopModels", "WorkshopID", "JAM.Workshops", "WorkshopID", cascadeDelete: true);
            AddForeignKey("JAM.LocalRooms", "RoomTypeID", "JAM.RoomTypes", "RoomTypeID", cascadeDelete: true);
            AddForeignKey("JAM.OtherRooms", "RoomID", "JAM.Rooms", "RoomID");
            AddForeignKey("JAM.LocalRooms", "RoomID", "JAM.Rooms", "RoomID");
            AddForeignKey("JAM.Guests", "RoomID", "JAM.Rooms", "RoomID");
            AddForeignKey("JAM.Residences", "NationalityID", "JAM.Nationalities", "NationalityID", cascadeDelete: true);
            AddForeignKey("JAM.Invoices", "TicketTypeID", "JAM.TicketTypes", "TicketTypeID", cascadeDelete: true);
            AddForeignKey("JAM.Guests", "InvoiceId", "JAM.Invoices", "InvoiceID");
            AddForeignKey("JAM.Payments", "InvoiceID", "JAM.Invoices", "InvoiceID", cascadeDelete: true);
        }
    }
}
