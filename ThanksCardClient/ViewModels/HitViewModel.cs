using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class HitViewModel
    {
        private readonly IRegionManager regionManager;

        public HitViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion

        #region  ThanksCardCreateCommand
        private DelegateCommand _ThanksCardCreateCommand;


        public DelegateCommand ThanksCardCreateCommand =>
            _ThanksCardCreateCommand ?? (_ThanksCardCreateCommand = new DelegateCommand(ExecuteThanksCardCreateCommand));

        void ExecuteThanksCardCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  ThankCardListCommand
        private DelegateCommand _ThankCardListCommand;


        public DelegateCommand ThankCardListCommand =>
            _ThankCardListCommand ?? (_ThankCardListCommand = new DelegateCommand(ExecuteThankCardListCommand));

        void ExecuteThankCardListCommand()
        {

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
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