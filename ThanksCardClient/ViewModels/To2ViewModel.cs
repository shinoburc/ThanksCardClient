using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class To2ViewModel : BindableBase
    {
       
             private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public To2ViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }


        #region Home2Command
        private DelegateCommand _Home2Command;
        public DelegateCommand Home2Command =>
            _Home2Command ?? (_Home2Command = new DelegateCommand(ExecuteHome2Command));

        void ExecuteHome2Command()
        {
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Home2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();
        }
        #endregion


    }
}

