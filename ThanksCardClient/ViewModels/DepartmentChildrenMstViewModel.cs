using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

namespace ThanksCardClient.ViewModels
{
    public class DepartmentChildrenMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region DepartmentChildrensProperty
        private List<DepartmentChildren> _DepartmentChildrens;
        public List<DepartmentChildren> DepartmentChildrens
        {
            get { return _DepartmentChildrens; }
            set { SetProperty(ref _DepartmentChildrens, value); }
        }
        #endregion

        public DepartmentChildrenMstViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateDepartmentChildrens();
        }

        private async void UpdateDepartmentChildrens()
        {
            DepartmentChildren DC = new DepartmentChildren();
            this.DepartmentChildrens = await DC.GetDepartmentChildrensAsync();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region DepartmentChildrenCreateCommand
        private DelegateCommand _DepartmentChildrenCreateCommand;
        public DelegateCommand DepartmentChildrenCreateCommand =>
            _DepartmentChildrenCreateCommand ?? (_DepartmentChildrenCreateCommand = new DelegateCommand(ExecuteDepartmentChildrenCreateCommand));

        void ExecuteDepartmentChildrenCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentChildrenCreate));
        }
        #endregion

        #region DepartmentChildrenEditCommand

        private DelegateCommand<DepartmentChildren> _DepartmentChildrenEditCommand;
        public DelegateCommand<DepartmentChildren> DepartmentChildrenEditCommand =>
            _DepartmentChildrenEditCommand ?? (_DepartmentChildrenEditCommand = new DelegateCommand<DepartmentChildren>(ExecuteDepartmentChildrenEditCommand));

        void ExecuteDepartmentChildrenEditCommand(DepartmentChildren SelectedDepartmentChildren)
        {
            // 対象のDepartmentChildrenをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedDepartmentChildren", SelectedDepartmentChildren);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentChildrenEdit), parameters);
        }
        #endregion

        #region DepartmentChildrenDeleteCommand
        private DelegateCommand<DepartmentChildren> _DepartmentChildrenDeleteCommand;
        public DelegateCommand<DepartmentChildren> DepartmentChildrenDeleteCommand =>
            _DepartmentChildrenDeleteCommand ?? (_DepartmentChildrenDeleteCommand = new DelegateCommand<DepartmentChildren>(ExecuteDepartmentChildrenDeleteCommand));

        async void ExecuteDepartmentChildrenDeleteCommand(DepartmentChildren SelectedDepartmentChildren)
        {
            DepartmentChildren deletedDepartmentChildren = await SelectedDepartmentChildren.DeleteDepartmentChildrenAsync(SelectedDepartmentChildren.Id);

            // ユーザ一覧 DepartmentChildrens を更新する。
            this.UpdateDepartmentChildrens();
        }
        #endregion
    }
}
