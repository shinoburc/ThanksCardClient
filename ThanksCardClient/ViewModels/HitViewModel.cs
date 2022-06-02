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
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion



    }
}
