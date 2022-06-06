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
    public class keijibanViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public keijibanViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        #region ShowFooterCommand
        private DelegateCommand _ShowFooterCommand;
        public DelegateCommand ShowFooterCommand =>
            _ShowFooterCommand ?? (_ShowFooterCommand = new DelegateCommand(ExecuteShowFooterCommand));

        void ExecuteShowFooterCommand()
        {
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.Regions["ContentRegion"].RemoveAll();
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Footer));

        }
        #endregion

        #region ShowpastCasesCommand
        private DelegateCommand _ShowpastCasesCommand;
        public DelegateCommand ShowpastCasesCommand =>
            _ShowpastCasesCommand ?? (_ShowpastCasesCommand = new DelegateCommand(ExecuteShowpastCasesCommand));

        void ExecuteShowpastCasesCommand()
        {
            this.regionManager.Regions["HeaderRegion"].RemoveAll();
            this.regionManager.Regions["ContentRegion"].RemoveAll();
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.PastCases));

        }
        #endregion
    }
}
