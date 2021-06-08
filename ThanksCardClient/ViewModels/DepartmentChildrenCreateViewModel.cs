using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class DepartmentChildrenCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region DepartmentChildrenProperty
        private DepartmentChildren _DepartmentChildren;
        public DepartmentChildren DepartmentChildren
        {
            get { return _DepartmentChildren; }
            set { SetProperty(ref _DepartmentChildren, value); }
        }
        #endregion

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        public DepartmentChildrenCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();

            this.DepartmentChildren = new DepartmentChildren();
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            DepartmentChildren createdDepartmentChildren = await DepartmentChildren.PostDepartmentChildrenAsync(this.DepartmentChildren);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentChildrenMst));
        }
        #endregion
    }
}
