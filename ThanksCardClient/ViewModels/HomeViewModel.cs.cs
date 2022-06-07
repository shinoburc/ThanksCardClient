using Prism.Commands;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanksCardClient.ViewModels
{
    internal class HomeViewModel
    {
        private readonly IRegionManager regionManager;

        public HomeViewModel(IRegionManager regionManager)
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
