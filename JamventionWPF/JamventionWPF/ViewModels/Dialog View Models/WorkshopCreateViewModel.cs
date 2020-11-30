using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    public class WorkshopCreateViewModel : BasisViewModel
    {
        private Workshop _workshopCreate;
        private ObservableCollection<Location> _locations;
        private ObservableCollection<TimeSlot> _timeslots;

        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public WorkshopCreateViewModel()
        {
            WorkshopCreate = new Workshop();
            LoadComboboxes();
        }

        public void LoadComboboxes()
        {
            IEnumerable<Location> locations = unitOfWork.RepoLocation.Retrieve();
            IEnumerable<TimeSlot> timeSlots = unitOfWork.RepoTimeslot.Retrieve();
            Locations = new ObservableCollection<Location>(locations);
            Timeslots = new ObservableCollection<TimeSlot>(timeSlots);
        }



        public Workshop WorkshopCreate
        {
            get
            {
                return _workshopCreate;
            }
            set
            {
                _workshopCreate = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Location> Locations
        {
            get
            {
                return _locations;
            }
            set
            {
                _locations = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<TimeSlot> Timeslots
        {
            get
            {
                return _timeslots;
            }
            set
            {
                _timeslots = value;
                NotifyPropertyChanged();
            }
        }
        #region ICommand
        public override bool CanExecute(object parameter)
        {
            return true;
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "AddWorkshop")
            {
                unitOfWork.RepoWorkshop.Add(WorkshopCreate);
                try
                {
                    if (unitOfWork.Save() != 0)
                    {
                        Messenger.Default.Send("Toevoegen successvol");
                    }
                    else
                    {
                        Messenger.Default.Send("Toevoeging misluks");
                    }
                }
                catch (Exception ex)
                {

                    Messenger.Default.Send(ex.Message);
                    ErrorLogging(ex);
                }
              
            }
        }
        #endregion
    }
}
