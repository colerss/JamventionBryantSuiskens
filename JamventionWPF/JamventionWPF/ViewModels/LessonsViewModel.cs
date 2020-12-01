using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using JamventionWPF.Views;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JamventionWPF.ViewModels
{
    public class LessonsViewModel : BasisViewModel
    {
        private ObservableCollection<Workshop> _workshops;
        private Workshop _selectedWorkshop;
        private bool _detailEnable = false;
        public LessonsViewModel()
        {
            LoadDatagrid();
        }

        public void LoadDatagrid()
        {
            IEnumerable<Workshop> workshops = unitOfWork.RepoWorkshop.Retrieve(
                x => x.Location, 
                x => x.TimeSlot,
                x => x.WorkshopParticipants, 
                x => x.WorkshopParticipants.Select(f => f.Guest), 
                x => x.WorkshopModels,
                x => x.WorkshopModels.Select(f => f.Model),
                x => x.WorkshopTeachers,
                x => x.WorkshopTeachers.Select(f => f.Teacher));
            Workshops = new ObservableCollection<Workshop>(workshops);
        }
        #region Properties
        public bool DetailEnable
        {
            get { return _detailEnable; }
            set
            {
                _detailEnable = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Workshop> Workshops
        {
            get { return _workshops; }
            set
            {
                _workshops = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("FridayWorkshops");
                NotifyPropertyChanged("SaturdayWorkshops");
                NotifyPropertyChanged("SundayWorkshops");
            }
        }
        public ObservableCollection<Workshop> FridayWorkshops => new ObservableCollection<Workshop>(Workshops.Where(x => x.TimeSlot.Day.DayOfWeek == DayOfWeek.Friday));
        public ObservableCollection<Workshop> SaturdayWorkshops => new ObservableCollection<Workshop>(Workshops.Where(x => x.TimeSlot.Day.DayOfWeek == DayOfWeek.Saturday));
        public ObservableCollection<Workshop> SundayWorkshops => new ObservableCollection<Workshop>(Workshops.Where(x => x.TimeSlot.Day.DayOfWeek == DayOfWeek.Sunday));
        public int SpotsLeft => SelectedWorkshop != null? SelectedWorkshop.Slots - SelectedWorkshop.WorkshopParticipants.Count : 0;
        public int SpotsLeftInverse => SelectedWorkshop != null ? SelectedWorkshop.Slots - SpotsLeft : 0;
        public Workshop SelectedWorkshop
        {
            get
            { 
                return _selectedWorkshop; 
            }
            set
            {
                _selectedWorkshop = value;
                DetailEnable = (_selectedWorkshop != null);
                NotifyPropertyChanged();
                NotifyPropertyChanged("SpotsLeft");
                NotifyPropertyChanged("SpotsLeftInverse");
            }
        }
        #endregion
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
                case "AddWorkshop":
                    AddWorkshop();
                    break;
                case "DeleteWorkshop":
                    DeleteWorkshop();
                    break;
                case "WorkshopDetails":
                    WorkshopDetails();
                    break;
            }
        }
        #endregion

        void WorkshopDetails()
        {
            WorkshopDetailViewModel viewModel = new WorkshopDetailViewModel(SelectedWorkshop);
            WorkshopDetailsView view = new WorkshopDetailsView();
            view.DataContext = viewModel;
            view.ShowDialog();
        }
        void DeleteWorkshop() 
        {
            try
            {
                unitOfWork.RepoWorkshop.Delete(SelectedWorkshop);
                unitOfWork.Save();
                Messenger.Default.Send("Workshop verwijderd");
                LoadDatagrid();
            }
            catch (Exception ex)
            {

                Messenger.Default.Send(ex.Message);
                ErrorLogging(ex);
            }
        }
        void AddWorkshop()
        {
            WorkshopCreateViewModel vm = new WorkshopCreateViewModel();
            WorkshopCreateView view = new WorkshopCreateView();
            view.DataContext = vm;
            view.ShowDialog();
            LoadDatagrid();
        }
    }
}
