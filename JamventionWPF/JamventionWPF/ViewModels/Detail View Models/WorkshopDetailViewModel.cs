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
    public class WorkshopDetailViewModel : BasisWorkshopViewModel
    {
        private Workshop _workshopDetails;
        private WorkshopModel _modelToAdd;
        private WorkshopParticipant _participantToAdd;
        private WorkshopTeacher _teacherToAdd;
        private ObservableCollection<Guest> _guests;

        #region Startup Routine
        public WorkshopDetailViewModel(Workshop workshopDetails)
        {
            WorkshopDetails = workshopDetails;
            SetProperties();
            LoadComboboxes();
        }
        public void SetProperties ()
        {
            TeacherToAdd = new WorkshopTeacher
            {
                WorkshopID = WorkshopDetails.WorkshopID
            };
            ModelToAdd = new WorkshopModel
            {
                WorkshopID = WorkshopDetails.WorkshopID
            };
            ParticipantToAdd = new WorkshopParticipant
            {
                WorkshopID = WorkshopDetails.WorkshopID
            };
        }

        public override void LoadComboboxes()
        {
            IEnumerable<Guest> guests = unitOfWork.RepoGuests.Retrieve();
            Guests = new ObservableCollection<Guest>(guests);

            base.LoadComboboxes();
        }
        #endregion
        #region Properties


        public bool ParticipantsFull => WorkshopDetails.Slots >WorkshopDetails.WorkshopParticipants.Count();
        public bool ModelsFull => 10 > WorkshopDetails.WorkshopModels.Count();
        //Principieel heeft elke workshop maar één docent, maar een hulpdocent of tweede docent mag aangegeven worden. Deze staat niet in de oppervlakkige data maar komt wel in de tijdschemas van de hulpdocenten 
        public bool TeachersFull => 3 > WorkshopDetails.WorkshopTeachers.Count();
        public bool ParticipantsEmpty => 0 < WorkshopDetails.WorkshopParticipants.Count();
        public bool ModelsEmpty => 0 < WorkshopDetails.WorkshopModels.Count();
        public bool TeachersEmpty =>  0 < WorkshopDetails.WorkshopTeachers.Count();

        public WorkshopModel ModelToAdd
        {
            get
            {
                return _modelToAdd;
            }
            set
            {
                _modelToAdd = value;
                NotifyPropertyChanged();
            }
        }
        public WorkshopParticipant ParticipantToAdd
        {
            get
            {
                return _participantToAdd;
            }
            set
            {
                _participantToAdd = value;
                NotifyPropertyChanged();
            }
        }
        public WorkshopTeacher TeacherToAdd
        {
            get
            {
                return _teacherToAdd;
            }
            set
            {
                _teacherToAdd = value;
                NotifyPropertyChanged();
            }
        }

        public ObservableCollection<Guest> AllParticipants
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 1).SkipWhile(x => WorkshopDetails.WorkshopParticipants.Any(f => f.GuestID == x.GuestID)));
            }
        }
        public ObservableCollection<Guest> AllModels
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 2).SkipWhile(x => WorkshopDetails.WorkshopModels.Any(f => f.ModelID == x.GuestID)));
            }
        }
        public ObservableCollection<Guest> AllTeachers
        {
            get
            {
                return new ObservableCollection<Guest>(Guests.Where(s => s.RoleID == 3).SkipWhile(x => WorkshopDetails.WorkshopTeachers.Any(f => f.TeacherID == x.GuestID)));
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
                PropertyStack();
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
                PropertyStack();
            }
        }

        public void PropertyStack()
        {
            NotifyPropertyChanged("AllTeachers");
            NotifyPropertyChanged("AllModels");
            NotifyPropertyChanged("AllParticipants");
            NotifyPropertyChanged("ParticipantsFull");
            NotifyPropertyChanged("TeachersFull");
            NotifyPropertyChanged("ModelsFull");
            NotifyPropertyChanged("ParticipantsEmpty");
            NotifyPropertyChanged("TeachersEmpty");
            NotifyPropertyChanged("ModelsEmpty");
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
            switch (parameter.ToString())
            {
                case "SaveAll":
                    return LoginViewModel.IsAuthorized;
                case "SaveParticipant":
                    return LoginViewModel.IsAuthorized;
                case "SaveModel":
                    return LoginViewModel.IsAuthorized;
                case "SaveTeacher":
                    return LoginViewModel.IsAuthorized;
                case "WipeParticipants":
                    return LoginViewModel.IsAuthorized;
                case "WipeModels":
                    return LoginViewModel.IsAuthorized;
                case "WipeTeachers":
                    return LoginViewModel.IsAuthorized;
            }
            return true;
        }

        public override void Execute(object parameter)
        {
            switch (parameter.ToString())
            {
                case "SaveAll":
                    SaveAll();
                        break;
                case "SaveParticipant":
                    SaveParticipant();
                    break;
                case "SaveModel":
                    SaveModel();
                    break;
                case "SaveTeacher":
                    SaveTeacher();
                    break;
                case "WipeParticipants":
                   WipeParticipants();
                    break;
                case "WipeModels":
                    WipeModels();
                    break;
                case "WipeTeachers":
                    WipeTeachers();
                    break;
            }
            //Roept alle afgeleide notifychanges aan omdat de meeste knoppen dit niet standaard doen
            PropertyStack();
            SetProperties();
        }
        #endregion
        public void SaveAll()
        {
            unitOfWork.RepoWorkshop.AddOrEdit(WorkshopDetails);
            unitOfWork.Save();
        }

        #region WipeFunctions
        public void WipeParticipants()
        {
            IEnumerable<WorkshopParticipant> workshopParticipants = unitOfWork.RepoWorkshopParticipant.Retrieve(x => x.WorkshopID == WorkshopDetails.WorkshopID);
            if (workshopParticipants.Count() > 0)
            {
                unitOfWork.RepoWorkshopParticipant.DeleteRange(workshopParticipants);
                unitOfWork.Save();
                WorkshopDetails.WorkshopParticipants.Clear();
            }
           
        }
        public void WipeTeachers()
        {
            IEnumerable<WorkshopTeacher> workshopTeachers = unitOfWork.RepoWorkshopTeacher.Retrieve(x => x.WorkshopID == WorkshopDetails.WorkshopID);
            if (workshopTeachers.Count() > 0)
            {
                unitOfWork.RepoWorkshopTeacher.DeleteRange(workshopTeachers);
                unitOfWork.Save();
                WorkshopDetails.WorkshopTeachers.Clear();
            }
        }
        public void WipeModels()
        {
            IEnumerable<WorkshopModel> workshopModels = unitOfWork.RepoWorkshopModel.Retrieve(x => x.WorkshopID == WorkshopDetails.WorkshopID);
            if (workshopModels.Count() > 0)
            {
                unitOfWork.RepoWorkshopModel.DeleteRange(workshopModels);
                unitOfWork.Save();
                WorkshopDetails.WorkshopModels.Clear();
            }
        }
        #endregion
        #region SaveFunctions
        public void SaveParticipant()
        {
            try
            {
                unitOfWork.RepoWorkshopParticipant.Add(ParticipantToAdd);
                unitOfWork.Save();
                WorkshopDetails.WorkshopParticipants.Add(ParticipantToAdd);
              
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(ex.Message);
                ErrorLogging(ex);
            }
        }
        public void SaveTeacher()
        {
            try
            {
                unitOfWork.RepoWorkshopTeacher.Add(TeacherToAdd);
            
                unitOfWork.Save();
                WorkshopDetails.WorkshopTeachers.Add(TeacherToAdd);
               
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(ex.Message);
                ErrorLogging(ex);
            }
        }
        public void SaveModel()
        {
            try
            {
                unitOfWork.RepoWorkshopModel.Add(ModelToAdd);
                unitOfWork.Save();
                WorkshopDetails.WorkshopModels.Add(ModelToAdd);
             
            }
            catch (Exception ex)
            {
                Messenger.Default.Send(ex.Message);
                ErrorLogging(ex);
            }
        }
        #endregion
    }
}
