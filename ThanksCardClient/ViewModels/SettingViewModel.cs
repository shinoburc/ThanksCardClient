using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class SettingViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public SettingViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region BackCommand
        private DelegateCommand _BackCommand;
        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Home));
        }
        #endregion


    }
}

