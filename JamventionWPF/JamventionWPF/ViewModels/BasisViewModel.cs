using GalaSoft.MvvmLight.Command;
using GalaSoft.MvvmLight.Views;
using JamventionDAL;
using JamventionDAL.Data.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace JamventionWPF.ViewModels
{
    public abstract class BasisViewModel : INotifyPropertyChanged, ICommand, IDataErrorInfo
    {
  
        protected IUnitOfWork unitOfWork = new UnitOfWork(new JamventionDAL.JamventionEntities());
       
        #region Startup routine
        public BasisViewModel()
        {
            this.CloseWindowCommand = new RelayCommand<Window>(this.CloseWindow);
        }

        public RelayCommand<Window> CloseWindowCommand { get; private set; }


        private void CloseWindow(Window window)
        {
            if (window != null)
            {
                window.Close();
            }
        }
        #endregion
        public static void ErrorLogging(Exception ex)
        {
            string strPath = @"Log.txt";
            if (!File.Exists(strPath))
            {
                File.Create(strPath).Dispose();
            }
            using (StreamWriter sw = File.AppendText(strPath))
            {
                sw.WriteLine("=============Error Logging ===========");
                sw.WriteLine("===========Start============= " + DateTime.Now);
                sw.WriteLine("Error Message: " + ex.Message);
                sw.WriteLine("Error: " + ex.GetType().Name);
                sw.WriteLine("InnerException: " + ex.InnerException);
                sw.WriteLine("Stack Trace: " + ex.StackTrace);
                sw.WriteLine("===========End============= " + DateTime.Now);

            }
        }

        
        public event PropertyChangedEventHandler PropertyChanged;
        protected void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
        public abstract string this[string columnName] { get; }
       

      

        public bool isGeldig()
        {
            return string.IsNullOrEmpty(Error);
        }
        public string Error
        {
            get
            {
                string foutmeldingen = "";
                foreach (var item in this.GetType().GetProperties())
                {
                    string fout = this[item.Name];
                    if (!string.IsNullOrWhiteSpace(fout))
                    {
                        foutmeldingen += fout + Environment.NewLine;
                    }
                }
                return foutmeldingen;
            }
        }


        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public abstract bool CanExecute(object parameter);

        public abstract void Execute(object parameter);
    }

    public abstract class BasisParticipantViewModel : BasisViewModel
    {
        //Breedgebruikte comboboxes
        private ObservableCollection<Nationality> _nationalities;
        private ObservableCollection<GuestRole> _guestRoles;

        public BasisParticipantViewModel()
        {
            LoadComboboxes();

        }
        public virtual void LoadComboboxes()
        {
            IEnumerable<Nationality> nationalities = unitOfWork.RepoNationality.Retrieve();
            IEnumerable<GuestRole> guestRoles = unitOfWork.RepoGuestRoles.Retrieve();
            Nationalities = new ObservableCollection<Nationality>(nationalities);
            GuestRoles = new ObservableCollection<GuestRole>(guestRoles);
        }

        public ObservableCollection<Nationality> Nationalities
        {
            get
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
    }

    public abstract class BasisWorkshopViewModel : BasisViewModel
    {
        private ObservableCollection<Location> _locations;
        private ObservableCollection<TimeSlot> _timeslots;
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
        public BasisWorkshopViewModel()
        {
            LoadComboboxes();

        }
        public virtual void LoadComboboxes()
        {
            IEnumerable<Location> locations = unitOfWork.RepoLocation.Retrieve();
            IEnumerable<TimeSlot> timeSlots = unitOfWork.RepoTimeslot.Retrieve();
            Locations = new ObservableCollection<Location>(locations);
            Timeslots = new ObservableCollection<TimeSlot>(timeSlots);
        }
    }
}

