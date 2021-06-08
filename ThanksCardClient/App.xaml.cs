using ThanksCardClient.Views;
using Prism.Ioc;
using Prism.Modularity;
using System.Windows;

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
            containerRegistry.RegisterForNavigation<Header>();
            containerRegistry.RegisterForNavigation<Logon>();
            containerRegistry.RegisterForNavigation<Footer>();
            containerRegistry.RegisterForNavigation<ThanksCardCreate>();
            containerRegistry.RegisterForNavigation<ThanksCardList>();
            containerRegistry.RegisterForNavigation<UserMst>();
            containerRegistry.RegisterForNavigation<UserCreate>();
            containerRegistry.RegisterForNavigation<UserEdit>();
            containerRegistry.RegisterForNavigation<DepartmentMst>();
            containerRegistry.RegisterForNavigation<DepartmentCreate>();
            containerRegistry.RegisterForNavigation<DepartmentEdit>();
            containerRegistry.RegisterForNavigation<TagMst>();
            containerRegistry.RegisterForNavigation<TagCreate>();
            containerRegistry.RegisterForNavigation<TagEdit>();

            containerRegistry.RegisterForNavigation<Board2>();
            containerRegistry.RegisterForNavigation<BoardS2>();
            containerRegistry.RegisterForNavigation<CardCreate>();
            containerRegistry.RegisterForNavigation<Category2>();
            containerRegistry.RegisterForNavigation<Document2>();
            containerRegistry.RegisterForNavigation<From2>();
            containerRegistry.RegisterForNavigation<FromS2>();
            containerRegistry.RegisterForNavigation<Graph2>();
            containerRegistry.RegisterForNavigation<Home2>();
            containerRegistry.RegisterForNavigation<Memory2>();
            containerRegistry.RegisterForNavigation<MemoryS2>();
            containerRegistry.RegisterForNavigation<Password2>();
            containerRegistry.RegisterForNavigation<To2>();
            containerRegistry.RegisterForNavigation<ToS2>();
            containerRegistry.RegisterForNavigation<UpDate2>();
            

        }
    }
}
