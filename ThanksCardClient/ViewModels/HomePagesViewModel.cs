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
    public class HomePagesViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public HomePagesViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region  HomeCommand
        private DelegateCommand _HomeCommand;


        public DelegateCommand HomeCommand =>
            _HomeCommand ?? (_HomeCommand = new DelegateCommand(ExecuteHomeCommand));

        void ExecuteHomeCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon));
        }
        #endregion



    }
}
