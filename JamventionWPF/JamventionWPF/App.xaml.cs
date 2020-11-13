using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using JamventionWPF.ViewModels;
using System.Windows;

namespace JamventionWPF
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private void Application_Startup(object sender, StartupEventArgs e)
        {
            ParticipantsViewModel viewModel = new ParticipantsViewModel();
            Views.ParticipantsView view = new Views.ParticipantsView();
            view.DataContext = viewModel;
            view.Show();
        }
    }
}
