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
    public class MenuAdminViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public MenuAdminViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region  ThanksCradCreateCommand
        private DelegateCommand _ThanksCradCreateCommand;


        public DelegateCommand ThanksCradCreateCommand =>
            _ThanksCradCreateCommand ?? (_ThanksCradCreateCommand = new DelegateCommand(ExecuteThanksCradCreateCommand));

        void ExecuteThanksCradCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  ThanksCradListCommand
        private DelegateCommand _ThanksCradListCommand;


        public DelegateCommand ThanksCradListCommand =>
            _ThanksCradListCommand ?? (_ThanksCradListCommand = new DelegateCommand(ExecuteThanksCradListCommand));

        void ExecuteThanksCradListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region  ThanksCardCommand
        private DelegateCommand _ThanksCardCommand;


        public DelegateCommand ThanksCardCommand =>
            _ThanksCardCommand ?? (_ThanksCardCommand = new DelegateCommand(ExecuteThanksCardCommand));

        void ExecuteThanksCardCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  HitCommand
        private DelegateCommand _HitCommand;


        public DelegateCommand HitCommand =>
            _HitCommand ?? (_HitCommand = new DelegateCommand(ExecuteHitCommand));

        void ExecuteHitCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Hit));
        }
        #endregion
               
        #region  RankCommand
        private DelegateCommand _RankCommand;

        public DelegateCommand RankCommand =>
            _RankCommand ?? (_RankCommand = new DelegateCommand(ExecuteRankCommand));

        void ExecuteRankCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Rank));
        }
        #endregion


        #region  MenuUserCommand
        private DelegateCommand _MenuUserCommand;


        public DelegateCommand MenuUserCommand =>
            _MenuUserCommand ?? (_MenuUserCommand = new DelegateCommand(ExecuteMenuUserCommand));

        void ExecuteMenuUserCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion

        #region  UserMstCommand
        private DelegateCommand _UserMstCommand;


        public DelegateCommand UserMstCommand =>
            _UserMstCommand ?? (_UserMstCommand = new DelegateCommand(ExecuteUserMstCommand));

        void ExecuteUserMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region  DepartmentMstCommand
        private DelegateCommand _DepartmentMstCommand;


        public DelegateCommand DepartmentMstCommand =>
            _DepartmentMstCommand ?? (_DepartmentMstCommand = new DelegateCommand(ExecuteDepartmentMstCommand));

        void ExecuteDepartmentMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
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
 
        #region UserListCommand

        private DelegateCommand _UserListCommand;
        public DelegateCommand UserListCommand =>
            _UserListCommand ?? (_UserListCommand = new DelegateCommand(ExecuteUserListCommand));

        void ExecuteUserListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region UserListCommand

        private DelegateCommand _DepartmentListCommand;
        public DelegateCommand DepartmentListCommand =>
            _DepartmentListCommand ?? (_DepartmentListCommand = new DelegateCommand(ExecuteDepartmentListCommand));

        void ExecuteDepartmentListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
        }
        #endregion

        #region HitAdminCommand

        private DelegateCommand _HitAdminCommand;
        public DelegateCommand HitAdminCommand =>
            _HitAdminCommand ?? (_HitAdminCommand = new DelegateCommand(ExecuteHitAdminCommand));

        void ExecuteHitAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HitAdmin));
        }
        #endregion
    }
}
