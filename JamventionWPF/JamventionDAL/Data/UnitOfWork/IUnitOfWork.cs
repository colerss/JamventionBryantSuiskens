using JamventionDAL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Guest> RepoGuests { get; }
        IRepository<Nationality> RepoNationality { get; }
        IRepository<GuestRole> RepoGuestRoles { get; }
        IRepository<Residence> RepoResidence { get; }
        IRepository<Room> RepoAllRooms { get; }
        IRepository<LocalRoom> RepoLocalRooms { get; }
        IRepository<OtherRoom> RepoOtherRooms { get;  }
        IRepository<Invoice> RepoInvoice { get; }
        IRepository<TicketType> RepoTicketType { get; }
        IRepository<Payment> RepoPayment { get; }
        IRepository<Workshop> RepoWorkshop { get; }
        IRepository<Location> RepoLocation { get; }
        IRepository<TimeSlot> RepoTimeslot { get; }
        int Save();
    }
}
