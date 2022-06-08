#nullable disable
using Prism.Commands;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Linq;
using ThanksCardClient.Models;
using ThanksCardClient.Services;

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
            this.AuthorizedUser = SessionService.Instance.AuthorizedUser;
            this._SearchWord = this.AuthorizedUser.Name;
        }
        #region roginuser
        private User _AuthorizedUser;
        public User AuthorizedUser
        {
            get { return _AuthorizedUser; }
            set { SetProperty(ref _AuthorizedUser, value); }
        }
        #endregion
        #region SearchWordProperty
        private string _SearchWord;
        public string SearchWord
        {
            get { return _SearchWord; }
            set
            {
                SetProperty(ref _SearchWord, value);
                System.Diagnostics.Debug.WriteLine("SearchWord: " + this.SearchWord); //動作確認用。本来はこの行は必要ありません。
            }
        }
        #endregion
        #region LoginUserProperty
        private string _LoginUser;
        public string LoginUser
        {
            get { return _LoginUser; }
            set
            {
                SetProperty(ref _LoginUser, value);
                //    System.Diagnostics.Debug.WriteLine("SearchWord: " + this.SearchWord); //動作確認用。本来はこの行は必要ありません。
            }
        }
        #endregion

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

        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
        }
        #endregion

        #region SubmitCommand
        private DelegateCommand _SubmitCommand;
        public DelegateCommand SubmitCommand =>
            _SubmitCommand ?? (_SubmitCommand = new DelegateCommand(ExecuteSubmitCommand));

        async void ExecuteSubmitCommand()
        {
            Department updatedDepartment = await this.Department.PutDepartmentAsync(this.Department);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.DepartmentMst));
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

        #region  MenuAdminCommand
        private DelegateCommand _MenuAdminCommand;


        public DelegateCommand MenuAdminrCommand =>
            _MenuAdminCommand ?? (_MenuAdminCommand = new DelegateCommand(ExecuteMenuAdminCommand));

        void ExecuteMenuAdminCommand()
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
