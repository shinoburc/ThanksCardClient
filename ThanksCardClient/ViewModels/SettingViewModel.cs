using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Services;
namespace ThanksCardClient.ViewModels
{
    public class SettingViewModel : BindableBase
    {
        private readonly IRegionManager regionManager;
        public SettingViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }
        #region BackCommand
        private DelegateCommand _BackCommand;
        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));
        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Home));
        }
        #endregion

        #region UserCommand
        private DelegateCommand _UserCommand;
        public DelegateCommand UserCommand =>
            _UserCommand ?? (_UserCommand = new DelegateCommand(ExecuteUserCommand));
        void ExecuteUserCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region TagMstCommand
        private DelegateCommand _TagMstCommand;
        public DelegateCommand TagMstCommand =>
            _TagMstCommand ?? (_TagMstCommand = new DelegateCommand(ExecuteTagMstCommand));

        void ExecuteTagMstCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.TagMst));
        }
        #endregion

        #region DepartmentCreateCommand
        private DelegateCommand _DepartmentCreateCommand;
        public DelegateCommand DepartmentCreateCommand =>
            _DepartmentCreateCommand ?? (_DepartmentCreateCommand = new DelegateCommand(ExecuteDepartmentCreateCommand));

        void ExecuteDepartmentCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
        }
        #endregion

        #region DepartmentChildrenCreateCommand
        private DelegateCommand _DepartmentChildrenCreateCommand;
        public DelegateCommand DepartmentChildrenCreateCommand =>
            _DepartmentChildrenCreateCommand ?? (_DepartmentChildrenCreateCommand = new DelegateCommand(ExecuteDepartmentChildrenCreateCommand));

        void ExecuteDepartmentChildrenCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentChildrenMst));
        }
        #endregion
    }
}