using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL
{
    class JamventionEntities : DbContext
    {
        public JamventionEntities(): base("name=JamventionDB")
        {

        }

        public DbSet<Guest> Guests { get; set; }
        public DbSet<GuestRole> GuestRoles { get; set; }
        public DbSet<Room> Rooms { get; set; }
        public DbSet<Invoice> Invoices { get; set; }
        public DbSet<LocalRoom> LocalRooms { get; set; }
        public DbSet<Location> Locations { get; set; }
        public DbSet<Nationality> Nationalities { get; set; }
        public DbSet<OtherRoom> OtherRooms { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<Residence> Residences { get; set; }
        public DbSet<RoomType> RoomTypes { get; set; }
        public DbSet<TimeSlot> TimeSlots { get; set; }
        public DbSet<TicketType> TicketTypes { get; set; }
        public DbSet<Workshop> Workshops { get; set; }
        public DbSet<WorkshopModel> WorkshopModels { get; set; }
        public DbSet<WorkshopParticipant> WorkshopParticipants { get; set; }


       
    }
}
