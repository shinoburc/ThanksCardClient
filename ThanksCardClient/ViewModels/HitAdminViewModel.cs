using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class HitAdminViewModel
    {
        private readonly IRegionManager regionManager;

        public HitAdminViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #region  MenuAdminCommand
        private DelegateCommand _MenuAdminCommand;


        public DelegateCommand MenuAdminCommand =>
            _MenuAdminCommand ?? (_MenuAdminCommand = new DelegateCommand(ExecuteMenuAdminCommand));

        void ExecuteMenuAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        }
        #endregion

        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion



    }
}