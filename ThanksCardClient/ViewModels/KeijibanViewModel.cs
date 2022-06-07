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
    public class KeijibanViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;

        public KeijibanViewModel(IRegionManager regionManager)
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

        #region ShowpastCasesCommand
        private DelegateCommand _ShowpastCasesCommand;
        public DelegateCommand ShowpastCasesCommand =>
            _ShowpastCasesCommand ?? (_ShowpastCasesCommand = new DelegateCommand(ExecuteShowpastCasesCommand));

        void ExecuteShowpastCasesCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.PastCases));

        }
        #endregion

        #region ShowTypicalExamplesCommand
        private DelegateCommand _ShowTypicalExamplesCommand;
        public DelegateCommand ShowTypicalExamplesCommand =>
            _ShowTypicalExamplesCommand ?? (_ShowpastCasesCommand = new DelegateCommand(ExecuteShowTypicalExamplesCommand));

        void ExecuteShowTypicalExamplesCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegionRegion", nameof(Views.TypicalExamples));

        }
        #endregion
    }
}
