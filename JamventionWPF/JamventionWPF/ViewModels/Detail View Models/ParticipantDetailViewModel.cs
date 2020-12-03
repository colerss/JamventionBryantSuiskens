using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using JamventionWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JamventionWPF.ViewModels
{
    public class ParticipantDetailViewModel : BasisParticipantViewModel
    {
        private Guest _guestDetails;
        private Residence _residenceDetails;
        private ObservableCollection<Room> _rooms;
        private Invoice _invoice;
        private ObservableCollection<Payment> _payments;
        private ObservableCollection<WorkshopParticipant> _workshopEntries;
        private Guest importedGuest;
        public override void LoadComboboxes()
        {
            IEnumerable<Room> localRooms = unitOfWork.RepoLocalRooms.Retrieve(x => x.Beds > x.RoomOccupancy.Count , x => x.RoomType);
            IEnumerable<Room> otherRooms = unitOfWork.RepoOtherRooms.Retrieve(x => x.Beds > x.RoomOccupancy.Count);
            List<Room> roomJoin = new List<Room>(localRooms);
            roomJoin.AddRange(otherRooms);
            IEnumerable<Room> rooms = roomJoin;
            Rooms = new ObservableCollection<Room>(rooms);
            base.LoadComboboxes();
        }

        public Visibility IsParticipant
        {
            get
            {
                if (GuestDetails.RoleID == 1)
                {
                    return Visibility.Visible;
                }
                else
                {
                    return Visibility.Hidden;
                }
            }
        }
        public ParticipantDetailViewModel(Guest guest)
        {
            importedGuest = guest;
            GuestDetails = guest;
            SetGuestInfo();
        }
        public void LoadDatagrid()
        {
            Payments = new ObservableCollection<Payment>(Invoice.Payments);
        }
        public void SetGuestInfo()
        {
            ResidenceDetails = GuestDetails.Residence;

            if (GuestDetails.RoleID != 1)
            {
                GuestRoles = new ObservableCollection<GuestRole>(GuestRoles.Where(x => x.RoleID != 1));
                return;
            }
            else
            {
           Invoice = GuestDetails.Invoice;
            WorkshopEntries = new ObservableCollection<WorkshopParticipant>(GuestDetails.WorkshopParticipants);
            LoadDatagrid();
            }
        }

      public ObservableCollection<WorkshopParticipant> WorkshopEntries
        {
            get
            {
                return _workshopEntries;
            }
            set
            {
                _workshopEntries = value;
                NotifyPropertyChanged();
            }
        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        public ObservableCollection<Payment> Payments
        {
            get
            {
                return _payments;
            }
            set
            {
                _payments = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Room> Rooms
        {
            get
            {
                return _rooms;
            }
            set
            {
                _rooms = value;
                NotifyPropertyChanged();
            }
        }
        public Invoice Invoice
        {
            get
            {
                return _invoice;
            }
            set
            {
                _invoice = value;
                NotifyPropertyChanged();
            }
        }
        public Guest GuestDetails
        {
            get
            {
                return _guestDetails;
            }
            set
            {
                _guestDetails = value;
                NotifyPropertyChanged();
            }
        }
        public Residence ResidenceDetails
        {
            get
            {
                return _residenceDetails;
            }
            set
            {
                _residenceDetails = value;
                NotifyPropertyChanged();
            }
        }
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "SaveAll":
                    SaveAll();

                    break;
                case "AddPayment":
                    AddPayment();
                    break;

            }
        }
        public void SaveAll()
        {
            if (SaveChanges() > 0)
            {
                Messenger.Default.Send("Aanpassingen Opgeslagen");
            }
            else
            {
                Messenger.Default.Send("Geen aanpassingen doorgegeven");
            }
        }
        public void AddPayment()
        {
            PaymentViewModel vm = new PaymentViewModel(GuestDetails.Invoice);
            PaymentView view = new PaymentView();
            view.DataContext = vm;
            view.ShowDialog();
            GuestDetails = unitOfWork.RepoGuests.Retrieve( x => x.GuestID == importedGuest.GuestID, x => x.Residence, x => x.GuestRole, x => x.Room, x => x.Residence.Nationality, x => x.Invoice, x => x.Invoice.TicketType, x => x.Invoice.Payments, x => x.WorkshopParticipants,
                x => x.WorkshopParticipants.Select(c => c.Workshop),
                x => x.WorkshopParticipants.Select(c => c.Workshop.TimeSlot)).FirstOrDefault();
            SetGuestInfo();
        }
        public int SaveChanges()
        {
            unitOfWork.RepoGuests.AddOrEdit(GuestDetails);
            unitOfWork.RepoResidence.AddOrEdit(ResidenceDetails);
            return unitOfWork.Save();
        }
    }
}
