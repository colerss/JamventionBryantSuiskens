using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    
    public class RoomCreateViewModel : BasisViewModel
    {
        private OtherRoom _roomCreate;

        public RoomCreateViewModel()
        {
            RoomCreate = new OtherRoom();
        }
        public override string this[string columnName] {
            get
            {
                return "";
            }        
        }

        public OtherRoom RoomCreate
        {
            get
            {
                return _roomCreate;
            }
            set
            {
                _roomCreate = value;
                NotifyPropertyChanged();
            }
        }

        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "AddRoom")
            {
                AddRoom();
            }
        }

        public void AddRoom()
        {
            unitOfWork.RepoOtherRooms.Add(RoomCreate);
            if (unitOfWork.Save() > 0)
            {
                Messenger.Default.Send("Nieuwe kamer successvol toegevoegd");
                RoomCreate = new OtherRoom();
            }
            else
            {
                Messenger.Default.Send("Toevoeging gefaald ");
            }

        }
    }
}
