#nullable disable
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
    internal class SyukeiViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public SyukeiViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region HomeCommand
        private DelegateCommand _HomeCommand;
        public DelegateCommand HomeCommand =>
            _HomeCommand ?? (_HomeCommand = new DelegateCommand(ExecuteHomeCommand));
        void ExecuteHomeCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion
    }
}