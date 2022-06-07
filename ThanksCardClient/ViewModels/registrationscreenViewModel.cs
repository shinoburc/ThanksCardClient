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
    public class registrationscreenViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public registrationscreenViewModel(IRegionManager regionManager)
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
    }
}
