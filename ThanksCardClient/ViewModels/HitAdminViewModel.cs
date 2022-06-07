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
        #region  MenuAdmin1Command
        private DelegateCommand _MenuAdmin1Command;


        public DelegateCommand MenuAdmin1Command =>
            _MenuAdmin1Command ?? (_MenuAdmin1Command = new DelegateCommand(ExecuteMenuAdmin1Command));

        void ExecuteMenuAdmin1Command()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        }
        #endregion

        #region  BackAdminCommand
        private DelegateCommand _BackAdminCommand;


        public DelegateCommand BackAdminCommand =>
            _BackAdminCommand ?? (_BackAdminCommand = new DelegateCommand(ExecuteBackAdminCommand));

        void ExecuteBackAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        }
        #endregion



    }
}