using JamventionDAL;
using JamventionDAL.Data.UnitOfWork;
using JamventionWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{


    public class RoomsViewModel : BasisViewModel
    {
        private Guest _guest;
        private Room _selectedRoom;
        private ObservableCollection<LocalRoom> _localRooms;
        private ObservableCollection<OtherRoom> _otherRooms;

     
        public RoomsViewModel()
        {
            LoadDatagrid();
        }
        public void LoadDatagrid()
        {
            IEnumerable<LocalRoom> localRooms = unitOfWork.RepoLocalRooms.Retrieve(x => x.RoomType, x => x.RoomOccupancy);
            IEnumerable<OtherRoom> otherRooms = unitOfWork.RepoOtherRooms.Retrieve(x => x.RoomOccupancy);
            OtherRooms = new ObservableCollection<OtherRoom>(otherRooms);
            LocalRooms = new ObservableCollection<LocalRoom>(localRooms);

        }
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        #region properties

        public int BeesteboelBedsLeft => BedsLeft(LocalRooms);
        public int OtherBedsLeft => BedsLeft(OtherRooms);
        public int BeesteboelBedsMax => MaxBeds(LocalRooms);
        public int OtherBedsMax => MaxBeds(OtherRooms);
        public Guest Guest
        {
            get 
            { 
                return _guest; 
            }
            set
            {
                _guest = value;
                NotifyPropertyChanged();
            }
        }

        public Room SelectedRoom
        {
            get 
            { 
                return _selectedRoom; 
            }
            set 
            { 
                _selectedRoom = value;
                NotifyPropertyChanged();
            }

        }
        public ObservableCollection<LocalRoom> LocalRooms
        {
            get
            {
                return _localRooms;
            }
            set
            {
                _localRooms = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<OtherRoom> OtherRooms
        {
            get
            {
                return _otherRooms;
            }
            set
            {
                _otherRooms = value;
                NotifyPropertyChanged();
            }
        }

        public int MaxBeds<T>(ObservableCollection<T> Rooms) where T : Room
        {
            return Rooms.Sum(d => d.Beds);
        }
        public int BedsLeft<T>(ObservableCollection<T> Rooms) where T : Room
        {
            return Rooms.Sum(d => d.Beds) - Rooms.Sum(d => (d.Beds - d.RoomOccupancy.Count));
        }

        #endregion
        #region ICommand
        public override bool CanExecute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "NewRoom":
                    return LoginViewModel.IsAuthorized;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "NewRoom":
                    AddRoom();
                    break;
            }
        }
        #endregion
        public void AddRoom()
        {
            RoomCreateViewModel vm = new RoomCreateViewModel();
            RoomAddView view = new RoomAddView();
            view.DataContext = vm;
            view.ShowDialog();
            LoadDatagrid();
        }
    }
}
