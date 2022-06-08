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
    public class numberofreceptionsViewModels : BindableBase
    {
        private readonly IRegionManager regionManager;

        public numberofreceptionsViewModels(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #region ShowThanksCardReceiveCommand
        private DelegateCommand _ShowThanksCardReceiveCommand;
        public DelegateCommand ShowThanksCardReceiveCommand =>
            _ShowThanksCardReceiveCommand ?? (_ShowThanksCardReceiveCommand = new DelegateCommand(ExecuteShowThanksCardReceiveCommand));

        void ExecuteShowThanksCardReceiveCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.ThanksCardReceive));

        }
        #endregion
    }
}
