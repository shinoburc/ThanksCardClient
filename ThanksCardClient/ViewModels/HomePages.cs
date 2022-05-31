using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThanksCardClient.ViewModels
{
    internal class HomePages
    {
        HomeCommand

        #region  HomeCommand
        private DelegateCommand HomeCommand;
        public DelegateCommand HomeCommand =>
            _HomeCommand ?? (_HomeCommand = new DelegateCommand(ExecuteHomeCommand));

        void ExecuteHomeCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Logon));
        }
        #endregion

    }
}
