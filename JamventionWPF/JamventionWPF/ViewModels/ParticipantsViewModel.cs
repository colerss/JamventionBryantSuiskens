using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using GalaSoft.MvvmLight.Command;
using JamventionWPF.Views;
using JamventionDAL;
using GalaSoft.MvvmLight.Messaging;
using JamventionDAL.Data.UnitOfWork;

namespace JamventionWPF.ViewModels
{
    public class ParticipantsViewModel : BasisViewModel
    {
        IUnitOfWork unitOfWork = new UnitOfWork(new JamventionDAL.JamventionEntities());
        private Residence _residenceCreate;
        private Guest _guestCreate;
        private ObservableCollection<Nationality> _nationalities;
        private ObservableCollection<GuestRole> _guestRoles;
        private ObservableCollection<Guest> _guests;

        #region Properties

        public Guest GuestCreate { get {
                return _guestCreate;
            } set {
                _guestCreate = value;
                NotifyPropertyChanged();
            } }
        public Residence ResidenceCreate
        {
            get
            {
                return _residenceCreate;
            }
            set
            {
                _residenceCreate = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Nationality> Nationalities { get
            {
                return _nationalities;
            }
            set
            {
                _nationalities = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Guest> Participants { get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 1));
            } }
        public ObservableCollection<Guest> Models
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 2));
            }
        }
        public ObservableCollection<Guest> Teachers
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 3));
            }
        }
        public ObservableCollection<Guest> Other
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID > 3));
            }
        }
        public ObservableCollection<Guest> Guests { get
            {
                return _guests;
            }
            set {
                _guests = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<GuestRole> GuestRoles
        {
            get
            {
                return _guestRoles;
            }
            set
            {
                _guestRoles = value;
                NotifyPropertyChanged();
            }
        }
        #endregion

        public ParticipantsViewModel()
        {
            LoadComboboxes();
            LoadDatagrid();
            GuestCreate = new Guest {
            GuestID = (unitOfWork.RepoGuests.GetMaxPK(x => x.ResidenceID) + 1)
            };
            ResidenceCreate = new Residence
            {
                ResidenceID = (unitOfWork.RepoResidence.GetMaxPK(x => x.ResidenceID) + 1)
            };
        }
        public void LoadDatagrid()
        {
            IEnumerable<Guest> guests = unitOfWork.RepoGuests.Retrieve(x => x.Residence) ;
            Guests = new ObservableCollection<Guest>(guests);
        }

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }
        #region ICommand
        public override bool CanExecute(object parameter)
        {
            return true;
        }
       


        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "Rooms":
                    OpenRooms();
                    break;
                case "Lessons":
                    OpenLessons();
                    break;
                case "CreateGuest":
                    CreateGuest();
                    break;
            }
        }
        #endregion

        

        public void CreateGuest()
        {
           
            if (GuestCreate.RoleID != 1)
            {
                if (AddNonParticipant() > 0)
                {
                    GuestCreate = new Guest
                    {
                        GuestID = (unitOfWork.RepoGuests.GetMaxPK(x => x.ResidenceID) + 1)
                    };
                    ResidenceCreate = new Residence
                    {
                        ResidenceID = (unitOfWork.RepoResidence.GetMaxPK(x => x.ResidenceID) + 1)
                    };
                } 
            }
            else
            {
                ParticipantCreateInvoice invoiceCreate = new ParticipantCreateInvoice();
                ParticipantInvoiceViewModel viewModel = new ParticipantInvoiceViewModel(GuestCreate, ResidenceCreate);
                invoiceCreate.DataContext = viewModel;
                invoiceCreate.ShowDialog();
            }
            
        }

        public int AddNonParticipant()
        {
            GuestCreate.ResidenceID = ResidenceCreate.ResidenceID;
            try
            {
               if ( GuestCreate.InvoiceId == null)
                 {
                   unitOfWork.RepoResidence.AddOrEdit(ResidenceCreate);
                   unitOfWork.RepoGuests.AddOrEdit(GuestCreate);

                   return unitOfWork.Save();
                 }
                 else
                 {
                   throw new Exception("Geen geldige niet-deelnemer");
                 }
                
            }
            catch (Exception ex)
            {

                Messenger.Default.Send(ex.Message);
                ErrorLogging(ex);
                return 0;
            }
            
        }
        public void LoadComboboxes()
        {
            IEnumerable<Nationality> nationalities = unitOfWork.RepoNationality.Retrieve();
            IEnumerable<GuestRole> guestRoles = unitOfWork.RepoGuestRoles.Retrieve();
            Nationalities = new ObservableCollection<Nationality>(nationalities);
            GuestRoles = new ObservableCollection<GuestRole>(guestRoles);

        }
        public void OpenRooms()
        {
            RoomsViewModel vm = new RoomsViewModel();
            RoomsView view = new RoomsView();
            view.DataContext = vm;
            view.Show();
        }
        public void OpenLessons()
        {
            LessonsViewModel vm = new LessonsViewModel();
            PlanningView view = new PlanningView();
            view.DataContext = vm;
            view.Show();
        }
    }
}
