using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JamventionWPF.ViewModels;
using System.Windows;
using GalaSoft.MvvmLight.Messaging;

namespace JamventionWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            Messenger.Default.Register<string>(this, ShowMessage);
            LoginViewModel viewModel = new LoginViewModel();
            Views.LoginView view = new Views.LoginView();
            view.DataContext = viewModel;
            view.Show();
        }
        private void ShowMessage(string message) => MessageBox.Show(message);
    }
}
