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
            containerRegistry.RegisterForNavigation<MainWindow>();
            containerRegistry.RegisterForNavigation<Logon>();
            containerRegistry.RegisterForNavigation<Footer>();
            containerRegistry.RegisterForNavigation<ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<UserMst>();
            containerRegistry.RegisterForNavigation<DepartmentMst>();
            containerRegistry.RegisterForNavigation<DepartmentCreate>();
            containerRegistry.RegisterForNavigation<DepartmentEdit>();
            containerRegistry.RegisterForNavigation<TagMst>();
            containerRegistry.RegisterForNavigation<TagCreate>();
            containerRegistry.RegisterForNavigation<TagEdit>();
            containerRegistry.RegisterForNavigation<Manual>();
            containerRegistry.RegisterForNavigation<ThanksCardSend>();
            containerRegistry.RegisterForNavigation<RegistrationScreen>();
            containerRegistry.RegisterForNavigation<ThanksCardReceive>();
            containerRegistry.RegisterForNavigation<ThanksCardList>();
        }
    }
}
