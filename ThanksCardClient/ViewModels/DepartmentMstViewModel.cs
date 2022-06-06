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
    public class DepartmentMstViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region DepartmentsProperty
        private List<Department> _Departments;
        public List<Department> Departments
        {
            get { return _Departments; }
            set { SetProperty(ref _Departments, value); }
        }
        #endregion

        public DepartmentMstViewModel(IRegionManager regionManager)
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
            this.UpdateDepartments();
        }

        private async void UpdateDepartments()
        {
            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        #region DepartmentCreateCommand
        private DelegateCommand _DepartmentCreateCommand;
        public DelegateCommand DepartmentCreateCommand =>
            _DepartmentCreateCommand ?? (_DepartmentCreateCommand = new DelegateCommand(ExecuteDepartmentCreateCommand));

        void ExecuteDepartmentCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentCreate));
        }
        #endregion

        #region DepartmentEditCommand
        private DelegateCommand<Department> _DepartmentEditCommand;
        public DelegateCommand<Department> DepartmentEditCommand =>
            _DepartmentEditCommand ?? (_DepartmentEditCommand = new DelegateCommand<Department>(ExecuteDepartmentEditCommand));

        void ExecuteDepartmentEditCommand(Department SelectedDepartment)
        {
            // 対象のDepartmentをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedDepartment", SelectedDepartment);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentEdit), parameters);
        }
        #endregion

        #region DepartmentDeleteCommand
        private DelegateCommand<Department> _DepartmentDeleteCommand;
        public DelegateCommand<Department> DepartmentDeleteCommand =>
            _DepartmentDeleteCommand ?? (_DepartmentDeleteCommand = new DelegateCommand<Department>(ExecuteDepartmentDeleteCommand));

        async void ExecuteDepartmentDeleteCommand(Department SelectedDepartment)
        {
            Department deletedDepartment = await SelectedDepartment.DeleteDepartmentAsync(SelectedDepartment.Id);

            // 一覧 Departments を更新する。
            this.UpdateDepartments();
        }
        #endregion

        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuUser));
        }
        #endregion

        #region  ThanksCradCreateCommand
        private DelegateCommand _ThanksCradCreateCommand;


        public DelegateCommand ThanksCradCreateCommand =>
            _ThanksCradCreateCommand ?? (_ThanksCradCreateCommand = new DelegateCommand(ExecuteThanksCradCreateCommand));

        void ExecuteThanksCradCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
        }
        #endregion

        #region  ThanksCradListCommand
        private DelegateCommand _ThanksCradListCommand;


        public DelegateCommand ThanksCradListCommand =>
            _ThanksCradListCommand ?? (_ThanksCradListCommand = new DelegateCommand(ExecuteThanksCradListCommand));

        void ExecuteThanksCradListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region  HitAdminCommand
        private DelegateCommand _HitAdminCommand;


        public DelegateCommand HitAdminCommand =>
            _HitAdminCommand ?? (_HitAdminCommand = new DelegateCommand(ExecuteHitAdminCommand));

        void ExecuteHitAdminCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.HitAdmin));
        }
        #endregion

        //#region  MenuAdminCommand
        //private DelegateCommand _MenuAdminCommand;

        //public DelegateCommand MenuAdminrCommand =>
        //    _MenuAdminCommand ?? (_MenuAdminCommand = new DelegateCommand(ExecuteMenuAdminCommand));

        //void ExecuteMenuAdminCommand()
        //{
        //    this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        //}
        //#endregion
        #region
        private DelegateCommand _MenuAdminCommand;
        public DelegateCommand MenuAdminCommand =>
            _MenuAdminCommand ?? (_MenuAdminCommand = new DelegateCommand(ExecuteCommandName));

        void ExecuteCommandName()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.MenuAdmin));
        }
        #endregion

        #region  RankCommand
        private DelegateCommand _RankCommand;


        public DelegateCommand RankCommand =>
            _RankCommand ?? (_RankCommand = new DelegateCommand(ExecuteRankCommand));

        void ExecuteRankCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.Rank));
        }
        #endregion
    }
}
