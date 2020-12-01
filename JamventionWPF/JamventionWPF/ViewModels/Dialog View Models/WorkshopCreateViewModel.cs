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
    public class WorkshopCreateViewModel : BasisWorkshopViewModel
    {
        private Workshop _workshopCreate;


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
