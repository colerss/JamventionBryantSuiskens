using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    public class WorkshopDetailViewModel : BasisWorkshopViewModel
    {
        private Workshop _workshopDetails;
        private WorkshopModel _modelToAdd;
        private WorkshopParticipant _participantToAdd;
        private WorkshopTeacher _teacherToAdd;
        private ObservableCollection<Guest> _guests;
        public WorkshopDetailViewModel(Workshop workshopDetails)
        {
            WorkshopDetails = workshopDetails;
        }


        public ObservableCollection<Guest> Participants
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 1));
            }
        }
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

        public ObservableCollection<Guest> Guests
        {
            get
            {
                return _guests;
            }
            set
            {
                _guests = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("Teachers");
                NotifyPropertyChanged("Models");
                NotifyPropertyChanged("Participants");
            }
        }

        public Workshop WorkshopDetails
        {
            get
            {
                return _workshopDetails;
            }
            set
            {
                _workshopDetails = value;
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

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                default:
                    break;
            }
        }
    }
}
