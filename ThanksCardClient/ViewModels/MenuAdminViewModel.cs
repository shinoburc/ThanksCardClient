using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

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
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon));
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

        #region  HitAdminCommand
        private DelegateCommand _HitAdminCommand;


        public DelegateCommand HitAdminCommand =>
            _HitAdminCommand ?? (_HitAdminCommand = new DelegateCommand(ExecuteHitAdminCommand));

        void ExecuteHitAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HitAdmin));
        }
        #endregion

        #region  MenuAdminCommand
        private DelegateCommand _MenuAdminCommand;


        public DelegateCommand MenuAdminrCommand =>
            _MenuAdminCommand ?? (_MenuAdminCommand = new DelegateCommand(ExecuteMenuAdminCommand));

        void ExecuteMenuAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        }
        #endregion

    }
}
