using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class HomeViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public HomeViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }

        #region ThanksCardCreateCommand
        private DelegateCommand _ThanksCardCreateCommand;
        public DelegateCommand ThanksCardCreateCommand =>
            _ThanksCardCreateCommand ?? (_ThanksCardCreateCommand = new DelegateCommand(ExecuteThanksCardCreateCommand));

        void ExecuteThanksCardCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region LogoffCommand
        private DelegateCommand _logoffCommand;
        public DelegateCommand LogoffCommand =>
            _logoffCommand ?? (_logoffCommand = new DelegateCommand(ExecuteLogoffCommand));

        void ExecuteLogoffCommand()
        {
            SessionService.Instance.AuthorizedUser = null;
            SessionService.Instance.IsAuthorized = false;

            // HeaderRegion, FooterRegion を破棄して、ContentRegion をログオン画面に遷移させる。
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region ThanksCardListCommand
        private DelegateCommand _ThanksCardListCommand;
        public DelegateCommand ThanksCardListCommand =>
            _ThanksCardListCommand ?? (_ThanksCardListCommand = new DelegateCommand(ExecuteThanksCardListCommand));

        void ExecuteThanksCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region ShowSettingCommand
        private DelegateCommand _ShowSettingCommand;
        public DelegateCommand ShowSettingCommand =>
            _ShowSettingCommand ?? (_ShowSettingCommand = new DelegateCommand(ExecuteShowSettingCommand));

        void ExecuteShowSettingCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Setting));
        }
        #endregion

    }
}