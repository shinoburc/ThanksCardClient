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
    public class RegistrationScreenViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        public RegistrationScreenViewModel(IRegionManager regionManager)
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

        #region DepartmentCreateCommand
        private DelegateCommand _DepartmentCreateCommand;
        public DelegateCommand DepartmentCreateCommand =>
            _DepartmentCreateCommand ?? (_DepartmentCreateCommand = new DelegateCommand(ExecuteDepartmentCreateCommand));

        void ExecuteDepartmentCreateCommand()
        {
            this.regionManager.Regions["FooterRegion"].RemoveAll();
            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.DepartmentCreate));
        }
        #endregion

        #region UserProperty
        private User _User;
        public User User
        {
            get { return _User; }
            set { SetProperty(ref _User, value); }
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

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();

            this.User = new User();
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
            User createdUser = await User.PostUserAsync(this.User);

            this.regionManager.RequestNavigate("FooterRegion", nameof(Views.UserMst));
        }
        #endregion

    }
}
