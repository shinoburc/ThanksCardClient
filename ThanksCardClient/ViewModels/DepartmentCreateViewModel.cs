using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;

namespace ThanksCardClient.ViewModels
{
    public class DepartmentCreateViewModel : BindableBase, INavigationAware
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

        public DepartmentCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateDepartments();
        }

        private async void UpdateDepartments()
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();

            this.Department = new Department();
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
            Department createdDepartment = await Department.PostDepartmentAsync(this.Department);

            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Home2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();
        }
        #endregion

        #region Home2Command
        private DelegateCommand _Home2Command;
        public DelegateCommand Home2Command =>
            _Home2Command ?? (_Home2Command = new DelegateCommand(ExecuteHome2Command));

        void ExecuteHome2Command()
        {
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.Home2));
            this.regionManager.Regions["ContentRegion"].RemoveAll();

        }
        private string thanksCard;

        public string ThanksCard { get => thanksCard; set => SetProperty(ref thanksCard, value); }
        #endregion


    }
}
