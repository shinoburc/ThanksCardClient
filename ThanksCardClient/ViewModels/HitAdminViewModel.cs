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

#pragma warning disable CS8618 // Non-nullable field must contain a non-null value when exiting constructor. Consider declaring as nullable.
        public HitAdminViewModel(IRegionManager regionManager)

        {
            this.regionManager = regionManager;
        }

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