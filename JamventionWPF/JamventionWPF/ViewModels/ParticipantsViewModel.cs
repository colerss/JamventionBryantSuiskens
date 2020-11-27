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
        private bool _detailEnable;
        private Residence _residenceCreate;
        private Guest _guestCreate;
        private Guest _selectedGuest;
        
        private ObservableCollection<Guest> _guests;
        
        #region Properties

        public bool DetailEnable
        {
            get { return _detailEnable; }
            set { _detailEnable = true;
                NotifyPropertyChanged();
            }
        }
        public Guest GuestCreate { get {
                return _guestCreate;
            } set {

                _guestCreate = value;
                NotifyPropertyChanged();
            } }
        public Guest SelectedGuest
        {
            get
            {
                return _selectedGuest;
            }
            set
            {
                _selectedGuest = value;
                DetailEnable = (_selectedGuest != null);
                NotifyPropertyChanged();
            }
        }
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
                NotifyPropertyChanged("Other");
                NotifyPropertyChanged("Teachers");
                NotifyPropertyChanged("Models");
                NotifyPropertyChanged("Participants");
            }
        }
        
        #endregion

        public ParticipantsViewModel()
        {
            ResetFields();

        }
        public void LoadDatagrid()
        {
            IEnumerable<Guest> guests = unitOfWork.RepoGuests.Retrieve(x => x.Residence, x => x.GuestRole, x => x.Room, x => x.Residence.Nationality, x => x.Invoice, x => x.Invoice.TicketType, x => x.Invoice.Payments) ;
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
                case "Details":
                    OpenDetails();
                    break;
                case "CreateGuest":
                    CreateGuest();
                    break;
                case "Delete":
                    DeleteGuest();
                    break;
            }
        }
        #endregion

        public void DeleteGuest()
        {
            try
            {
                unitOfWork.RepoGuests.Delete(SelectedGuest);
                unitOfWork.Save();
                Messenger.Default.Send("Gast verwijderd");
                ResetFields();
            }
            catch (Exception ex)
            {

                Messenger.Default.Send(ex.Message);
                ErrorLogging(ex);
            }

        }

        public void CreateGuest()
        {
            GuestCreate.ResidenceID = ResidenceCreate.ResidenceID;
            if (GuestCreate.RoleID != 1)
            {
                if (AddNonParticipant() > 0)
                {
                    ResetFields();
                } 
            }
            else
            {
                ParticipantCreateInvoice invoiceCreate = new ParticipantCreateInvoice();
                ParticipantInvoiceViewModel viewModel = new ParticipantInvoiceViewModel(GuestCreate, ResidenceCreate);
                invoiceCreate.DataContext = viewModel;
                invoiceCreate.ShowDialog();
                ResetFields();
            }
            
        }
        public void ResetFields()
        {
            LoadDatagrid();
            GuestCreate = new Guest
            {
                GuestID = (unitOfWork.RepoGuests.GetMaxPK(x => x.GuestID) + 1)
            };
            ResidenceCreate = new Residence
            {
                ResidenceID = (unitOfWork.RepoResidence.GetMaxPK(x => x.ResidenceID) + 1)
            };

        }
        public int AddNonParticipant()
        {
            
            try
            {
               if ( GuestCreate.InvoiceID == null)
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
        
        public void OpenRooms()
        {
            RoomsViewModel vm = new RoomsViewModel();
            RoomsView view = new RoomsView();
            view.DataContext = vm;
            view.ShowDialog();
        }
        public void OpenDetails()
        {
            ParticipantDetailViewModel vm = new ParticipantDetailViewModel(SelectedGuest);
            ParticipantDetailView view = new ParticipantDetailView();
            view.DataContext = vm;
            view.ShowDialog();
            ResetFields();
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
