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
    public class DepartmentEditViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

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

        #region ErrorMessageProperty
        private string _ErrorMessage;
        public string ErrorMessage
        {
            get { return _ErrorMessage; }
            set { SetProperty(ref _ErrorMessage, value); }
        }
        #endregion

        public DepartmentEditViewModel(IRegionManager regionManager)
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
            // 画面遷移元から送られる SelectedTag パラメーターを取得。
            this.Department = navigationContext.Parameters.GetValue<Department>("SelectedDepartment");

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
            Department updatedDepartment = await this.Department.PutDepartmentAsync(this.Department);

            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.DepartmentMst));
        }
        #endregion

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

        #region ShowDepartmentMstCommand
        private DelegateCommand _ShowDepartmentMstCommand;
        public DelegateCommand ShowDepartmentMstCommand =>
            _ShowDepartmentMstCommand ?? (_ShowDepartmentMstCommand = new DelegateCommand(ExecuteShowDepartmentMstCommand));

        void ExecuteShowDepartmentMstCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.DepartmentMst));
        }
        #endregion
    }
}
