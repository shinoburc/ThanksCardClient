﻿#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
namespace ThanksCardClient.ViewModels
{
    public class pastCasesViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public pastCasesViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #region ShowkeijibanCommand
        private DelegateCommand _ShowkeijibanCommand;
        public DelegateCommand ShowkeijibanCommand =>
            _ShowkeijibanCommand ?? (_ShowkeijibanCommand = new DelegateCommand(ExecuteShowkeijibanCommand));

        void ExecuteShowkeijibanCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Keijiban));
        }
        #endregion
    }
}
