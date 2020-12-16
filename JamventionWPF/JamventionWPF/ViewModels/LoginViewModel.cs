using GalaSoft.MvvmLight.Messaging;
using JamventionDAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace JamventionWPF.ViewModels
{
   public class LoginViewModel : BasisViewModel
    {
        public static bool IsAuthorized = false;
      
        public override string this[string columnName]
        {
            get
            {
                return "";
            }
        }

        public override bool CanExecute(object parameter)
        {
            if (parameter.ToString() == "Continue")
            {
                return true;
            }
            else
            {
                return !IsAuthorized;
            }
        }

        public override void Execute(object parameter)
        {
            if (parameter.ToString() == "Continue")
            {
                ParticipantsViewModel viewModel = new ParticipantsViewModel();
                Views.ParticipantsView view = new Views.ParticipantsView();
                view.DataContext = viewModel;
                view.Show();
            }
            else
            {
              ValidateAdminKey(parameter as PasswordBox);
            }
        }

        public async void ValidateAdminKey(PasswordBox passwordBox)
        {
            var password = passwordBox.Password;

            IEnumerable<AdminKeys> adminKeys = await unitOfWork.RepoAdminKeys.RetrieveAsync();
            if (adminKeys.Any(x => x.HashedPassword == password.GetHashCode().ToString()))
            {
                IsAuthorized = true;
                Messenger.Default.Send("Administratormode geactiveerd");
            }
            else
            {
                Messenger.Default.Send("Ongeldige Administrator sleutel");
            }
        }
    }
}
