#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class ThanksCardReceive : BindableBase
    {
        private readonly IRegionManager regionManager;

        public ThanksCardReceive(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region ShowFooterCommand
        private DelegateCommand _ShowFooterCommand;
        public DelegateCommand ShowFooterCommand =>
            _ShowFooterCommand ?? (_ShowFooterCommand = new DelegateCommand(ExecuteShowFooterCommand));

        void ExecuteShowFooterCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));

        }
        #endregion

        #region ShowThanksCardSendCommand
        private DelegateCommand _ShowThanksCardSendCommand;
        public DelegateCommand ShowThanksCardSendCommand =>
            _ShowThanksCardSendCommand ?? (_ShowThanksCardSendCommand = new DelegateCommand(ExecuteShowThanksCardSendCommand));

        void ExecuteShowThanksCardSendCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.ThanksCardSend));

        }
        #endregion

        #region ShownumberofreceptionsCommand
        private DelegateCommand _ShownumberofreceptionsCommand;
        public DelegateCommand ShownumberofreceptionsCommand =>
            _ShownumberofreceptionsCommand ?? (_ShownumberofreceptionsCommand = new DelegateCommand(ExecutenumberofreceptionsCommand));

        void ExecutenumberofreceptionsCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.NumberOfrecePtions));

        }
        #endregion

        #region ShowThanksCardCreateCommand
        private DelegateCommand _ShowThanksCardCreateCommand;
        public DelegateCommand ShowThanksCardCreateCommand =>
            _ShowThanksCardCreateCommand ?? (_ShowThanksCardCreateCommand = new DelegateCommand(ExecuteShowThanksCardCreateCommand));

        void ExecuteShowThanksCardCreateCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));

        }
        #endregion
    }
}
