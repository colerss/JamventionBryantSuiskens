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

namespace JamventionWPF.ViewModels
{
    public class ParticipantsViewModel : BasisViewModel
    {
        private ObservableCollection<Nationality> _nationalities;
        private ObservableCollection<GuestRole> _guestRoles;

        #region Properties
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
            }
        }
        #endregion

        public void LoadComboboxes()
        {
            List<Nationality> nationalities = DatabaseOperations.FullListOfType<Nationality>();
            List<GuestRole> guestRoles = DatabaseOperations.FullListOfType<GuestRole>();
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
