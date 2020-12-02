using JamventionDAL.Data.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionDAL.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private IRepository<LocalRoom> _repoLocalRooms;
        private IRepository<OtherRoom> _repoOtherRooms;
        private IRepository<Room> _repoAllRooms;
        private IRepository<Guest> _repoGuests;
        private IRepository<Nationality> _repoNationality;
        private IRepository<GuestRole> _repoGuestRoles;
        private IRepository<Residence> _repoResidences;
        private IRepository<Invoice> _repoInvoice;
        private IRepository<TicketType> _repoTicketType;
        private IRepository<Payment> _repoPayment;
        private IRepository<Workshop> _repoWorkshop;
        private IRepository<WorkshopParticipant> _repoWorkshopParticipant;
        private IRepository<WorkshopModel> _repoWorkshopModel;
        private IRepository<WorkshopTeacher> _repoWorkshopTeacher;
        private IRepository<Location> _repoLocation;
        private IRepository<TimeSlot> _repoTimeslot;
        public UnitOfWork(JamventionEntities jamventionEntities)
        {
            this.JamventionEntities = jamventionEntities;

        }
        private JamventionEntities JamventionEntities { get; }
        public IRepository<Guest> RepoGuests { 
                 get
                 {
                 if (_repoGuests == null)
                  {
                    _repoGuests = new Repository<Guest>(this.JamventionEntities);
                  }
                  return _repoGuests;
                 }
        }

        public IRepository<Nationality> RepoNationality
        {
            get
            {
                if (_repoNationality == null)
                {
                    _repoNationality = new Repository<Nationality>(this.JamventionEntities);
                }
                return _repoNationality;
            }
        }

        public IRepository<GuestRole> RepoGuestRoles
        {
            get
            {
                if (_repoGuestRoles == null)
                {
                    _repoGuestRoles = new Repository<GuestRole>(this.JamventionEntities);
                }
                return _repoGuestRoles;
            }
        }

        public IRepository<Residence> RepoResidence
        {
            get
            {
                if (_repoResidences == null)
                {
                    _repoResidences = new Repository<Residence>(this.JamventionEntities);
                }
                return _repoResidences;
            }
        }
        public IRepository<TicketType> RepoTicketType
        {
            get
            {
                if (_repoTicketType == null)
                {
                    _repoTicketType = new Repository<TicketType>(this.JamventionEntities);
                }
                return _repoTicketType;
            }
        }
        public IRepository<Payment> RepoPayment
        {
            get
            {
                if (_repoPayment == null)
                {
                    _repoPayment = new Repository<Payment>(this.JamventionEntities);
                }
                return _repoPayment;
            }
        }
        public IRepository<LocalRoom> RepoLocalRooms
        {
            get
            {
                if (_repoLocalRooms == null)
                {
                    _repoLocalRooms = new Repository<LocalRoom>(this.JamventionEntities);
                }
                return _repoLocalRooms;
            }
        }
        public IRepository<Room> RepoAllRooms
        {
            get
            {
                if (_repoAllRooms == null)
                {
                    _repoAllRooms = new Repository<Room>(this.JamventionEntities);
                }
                return _repoAllRooms;
            }
        }
        public IRepository<OtherRoom> RepoOtherRooms
        {
            get
            {
                if (_repoOtherRooms == null)
                {
                    _repoOtherRooms = new Repository<OtherRoom>(this.JamventionEntities);
                }
                return _repoOtherRooms;
            }
        }

       public IRepository<Invoice> RepoInvoice
        {
            get
            {
                if (_repoInvoice == null)
                {
                    _repoInvoice = new Repository<Invoice>(this.JamventionEntities);
                }
                return _repoInvoice;
            }
        }

        public IRepository<Workshop> RepoWorkshop
        {
            get
            {
                if(_repoWorkshop == null)
                {
                    _repoWorkshop = new Repository<Workshop>(this.JamventionEntities);
                }
                return _repoWorkshop;
            }
        }

        public IRepository<Location> RepoLocation
        {
            get
            {
                if(_repoLocation == null)
                {
                    _repoLocation = new Repository<Location>(this.JamventionEntities);
                }
                return _repoLocation;
            }
        }
        public IRepository<TimeSlot> RepoTimeslot
        {
            get
            {
                if (_repoTimeslot == null)
                {
                    _repoTimeslot = new Repository<TimeSlot>(this.JamventionEntities);
                }
                return _repoTimeslot;
            }
        }
        public IRepository<WorkshopTeacher> RepoWorkshopTeacher
        {
            get
            {
                if (_repoWorkshopTeacher == null)
                {
                    _repoWorkshopTeacher = new Repository<WorkshopTeacher>(this.JamventionEntities);
                }
                return _repoWorkshopTeacher;
            }
        }
        public IRepository<WorkshopParticipant> RepoWorkshopParticipant
        {
            get
            {
                if (_repoWorkshopParticipant == null)
                {
                    _repoWorkshopParticipant = new Repository<WorkshopParticipant>(this.JamventionEntities);
                }
                return _repoWorkshopParticipant;
            }
        }
        public IRepository<WorkshopModel> RepoWorkshopModel
        {
            get
            {
                if (_repoWorkshopModel == null)
                {
                    _repoWorkshopModel = new Repository<WorkshopModel>(this.JamventionEntities);
                }
                return _repoWorkshopModel;
            }
        }


        public void Dispose()
        {
            JamventionEntities.Dispose();
        }

        public int Save()
        {
            return JamventionEntities.SaveChanges();
        }
    }
}
