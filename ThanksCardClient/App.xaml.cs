using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using Prism.Ioc;
using Prism.Modularity;
using ThanksCardClient.Views;


namespace ThanksCardClient
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App
    {
        protected override Window CreateShell()
        {
            return Container.Resolve<MainWindow>();
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<DepartmentCreate>();
            containerRegistry.RegisterForNavigation<DepartmentEdit>();
            containerRegistry.RegisterForNavigation<DepartmentMst>();
            containerRegistry.RegisterForNavigation<Footer>();
            containerRegistry.RegisterForNavigation<Logon>();
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<Manual>();
            containerRegistry.RegisterForNavigation<RegistrationScreen>();
            containerRegistry.RegisterForNavigation<RegistrationScreenEdit>();
            containerRegistry.RegisterForNavigation<TagCreate>();
            containerRegistry.RegisterForNavigation<TagEdit>();
            containerRegistry.RegisterForNavigation<TagMst>();
            containerRegistry.RegisterForNavigation<ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<ThanksCardList>();
            containerRegistry.RegisterForNavigation<UserMst>();
        }
    }
}
