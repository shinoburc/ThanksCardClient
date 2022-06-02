using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class MenuUserViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public MenuUserViewModel(IRegionManager regionManager)
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


        #region  MenuUserCommand
        private DelegateCommand _MenuUserCommand;


        public DelegateCommand MenuUserCommand =>
            _MenuUserCommand ?? (_MenuUserCommand = new DelegateCommand(ExecuteMenuUserCommand));

        void ExecuteMenuUserCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion

    }
}
