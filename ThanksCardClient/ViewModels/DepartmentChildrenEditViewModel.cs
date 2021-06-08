using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class DepartmentChildrenEditViewModel : BindableBase, INavigationAware
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

        #region DepartmentChildrensProperty
        private List<DepartmentChildren> _DepartmentChildrens;
        public List<DepartmentChildren> DepartmentChildrens
        {
            get { return _DepartmentChildrens; }
            set { SetProperty(ref _DepartmentChildrens, value); }
        }
        #endregion

        #region DepartmentProperty
        private Department _Department;
        public Department Department
        {
            get { return _Department; }
            set { SetProperty(ref _Department, value); }
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

        public DepartmentChildrenEditViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.DepartmentChildren = navigationContext.Parameters.GetValue<DepartmentChildren>("SelectedDepartmentChildren");

            this.UpdateDepartments();
        }

        private async void UpdateDepartments()
        { 
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

          #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            DepartmentChildren updatedDepartmentChildren = await DepartmentChildren.PutDepartmentChildrenAsync(this.DepartmentChildren);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentChildrenMst));
        }
        #endregion
    }
}
