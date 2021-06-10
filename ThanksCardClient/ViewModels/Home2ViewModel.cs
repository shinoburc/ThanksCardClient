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
    public class Home2ViewModel : BindableBase
    {
       
             private readonly IRegionManager regionManager;

        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }

        public Home2ViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
        }


        

        #region Password2Command
        private DelegateCommand _Password2Command;
        public DelegateCommand Password2Command =>
            _Password2Command ?? (_Password2Command = new DelegateCommand(ExecutePassword2Command));

        void ExecutePassword2Command()
        {
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Password2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();
        }
        #endregion

        #region Cardcreate2Command
        private DelegateCommand _Cardcreate2Command;
        public DelegateCommand Cardcreate2Command =>
            _Cardcreate2Command ?? (_Cardcreate2Command = new DelegateCommand(ExecuteCardcreate2Command));

        void ExecuteCardcreate2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region Board2Command
        private DelegateCommand _Board2Command;
        public DelegateCommand Board2Command =>
            _Board2Command ?? (_Board2Command = new DelegateCommand(ExecuteBoard2Command));

        void ExecuteBoard2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region To2Command
        private DelegateCommand _To2Command;
        public DelegateCommand To2Command =>
            _To2Command ?? (_To2Command = new DelegateCommand(ExecuteTo2Command));

        void ExecuteTo2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.To));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region From2Command
        private DelegateCommand _From2Command;
        public DelegateCommand From2Command =>
            _From2Command ?? (_From2Command = new DelegateCommand(ExecuteFrom2Command));

        void ExecuteFrom2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.From));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region Memory2Command
        private DelegateCommand _Memory2Command;
        public DelegateCommand Memory2Command =>
            _Memory2Command ?? (_Memory2Command = new DelegateCommand(ExecuteMemory2Command));

        void ExecuteMemory2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Memory));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region Graph2Command
        private DelegateCommand _Graph2Command;
        public DelegateCommand Graph2Command =>
            _Graph2Command ?? (_Graph2Command = new DelegateCommand(ExecuteGraph2Command));

        void ExecuteGraph2Command()
        {
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Graph2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();
        }
        #endregion
        
        #region Document2Command
        private DelegateCommand _Document2Command;
        public DelegateCommand Document2Command =>
            _Document2Command ?? (_Document2Command = new DelegateCommand(ExecuteDocument2Command));

        void ExecuteDocument2Command()
        {
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Document2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();
        }
        #endregion

        #region DepartmentCreateCommand
        private DelegateCommand _DepartmentCreateCommand;
        public DelegateCommand DepartmentCreateCommand =>
            _DepartmentCreateCommand ?? (_DepartmentCreateCommand = new DelegateCommand(ExecuteDepartmentCreateCommand));

        void ExecuteDepartmentCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
        }
        #endregion

        #region UpDate2Command
        private DelegateCommand _UpDate2Command;
        public DelegateCommand UpDate2Command =>
            _UpDate2Command ?? (_UpDate2Command = new DelegateCommand(ExecuteUpDate2Command));

        void ExecuteUpDate2Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
            this.regionManager.Regions["FooterRegion"].RemoveAll();
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
    }
}

