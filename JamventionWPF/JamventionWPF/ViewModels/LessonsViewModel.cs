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
        public ObservableCollection<Workshop> Workshops
        {
            get { return _workshops; }
            set
            {
                _workshops = value;
                NotifyPropertyChanged();
            }
        }
        public ObservableCollection<Workshop> FridayWorkshops => new ObservableCollection<Workshop>(Workshops.Where(x => x.TimeSlot.Day.DayOfWeek == DayOfWeek.Friday));
        public ObservableCollection<Workshop> SaturdayWorkshops => new ObservableCollection<Workshop>(Workshops.Where(x => x.TimeSlot.Day.DayOfWeek == DayOfWeek.Saturday));
        public ObservableCollection<Workshop> SundayWorkshops => new ObservableCollection<Workshop>(Workshops.Where(x => x.TimeSlot.Day.DayOfWeek == DayOfWeek.Sunday));
        public int SpotsLeft => SelectedWorkshop != null? SelectedWorkshop.Slots - SelectedWorkshop.WorkshopParticipants.Count : 0; 
        public Workshop SelectedWorkshop
        {
            get { return _selectedWorkshop; }
            set
            {
                _selectedWorkshop = value;
                NotifyPropertyChanged();
                NotifyPropertyChanged("SpotsLeft");
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
            }
        }
        #endregion

        void AddWorkshop()
        {
            WorkshopCreateViewModel vm = new WorkshopCreateViewModel();
            WorkshopCreateView view = new WorkshopCreateView();
            view.DataContext = vm;
            view.ShowDialog();
        }
    }
}
