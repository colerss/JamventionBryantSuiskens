using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace JamventionWPF.ViewModels
{
   public class ParticipantDetailViewModel:BasisViewModel
    {
        private Guest _guestDetails;
        private Residence _residenceDetails;
        private ObservableCollection<Room> _rooms;
        public override void LoadComboboxes()
        {
            IEnumerable<Room> localRooms = unitOfWork.RepoLocalRooms.Retrieve(x => x.Beds > x.RoomOccupancy.Count, x => x.RoomType);
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
            GuestDetails = guest;
            ResidenceDetails = GuestDetails.Residence;
            if (GuestDetails.RoleID != 1)
            {
                GuestRoles = new ObservableCollection<GuestRole>(GuestRoles.Where(x => x.RoleID != 1));
            }
        }
        public override string this[string columnName]
        {
            get
            {
                return "";
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
                    if (SaveChanges() > 0)
                    {

                    }
                    else
                    {
                        Messenger.Default.Send("Geen aanpassingen doorgegeven");
                    }
                   
                    break;
            }
        }
        public int SaveChanges()
        {
            unitOfWork.RepoGuests.AddOrEdit(GuestDetails);
            unitOfWork.RepoResidence.AddOrEdit(ResidenceDetails);
            return unitOfWork.Save();
        }
    }
}
