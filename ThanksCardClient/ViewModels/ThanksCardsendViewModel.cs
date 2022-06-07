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
    public class ThanksCardsendViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public ThanksCardsendViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region ShowFooterCommand
        private DelegateCommand _ShowFooterCommand;
        public DelegateCommand ShowFooterCommand =>
            _ShowFooterCommand ?? (_ShowFooterCommand = new DelegateCommand(ExecuteShowFooterCommand));

        void ExecuteShowFooterCommand()
        {
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.Regions["ContentRegion"].RemoveAll();
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Footer));

        }
        #endregion

        #region ShowThanksCardReceiveCommand
        private DelegateCommand _ShowThanksCardReceiveCommand;
        public DelegateCommand ShowThanksCardReceiveCommand =>
            _ShowThanksCardReceiveCommand ?? (_ShowThanksCardReceiveCommand = new DelegateCommand(ExecuteShowThanksCardReceiveCommand));

        void ExecuteShowThanksCardReceiveCommand()
        {
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.Regions["ContentRegion"].RemoveAll();
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardReceive));

        }
        #endregion

        #region ShowThanksCardCreateCommand
        private DelegateCommand _ShowThanksCardCreateCommand;
        public DelegateCommand ShowThanksCardCreateCommand =>
            _ShowThanksCardCreateCommand ?? (_ShowThanksCardCreateCommand = new DelegateCommand(ExecuteShowThanksCardCreateCommand));

        void ExecuteShowThanksCardCreateCommand()
        {
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.Regions["ContentRegion"].RemoveAll();
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardReceive));

        }
        #endregion

    }
}
