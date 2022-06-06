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
    public class UserCreateViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

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

        public UserCreateViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

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

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region  BackCommand
        private DelegateCommand _BackCommand;


        public DelegateCommand BackCommand =>
            _BackCommand ?? (_BackCommand = new DelegateCommand(ExecuteBackCommand));

        void ExecuteBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserMst));
        }
        #endregion

        #region  ThanksCardCommand
        private DelegateCommand _ThanksCardCommand;


        public DelegateCommand ThanksCardCommand =>
            _ThanksCardCommand ?? (_ThanksCardCommand = new DelegateCommand(ExecuteThanksCardCommand));

        void ExecuteThanksCardCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardCreate));
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

        #region  ThankCardListCommand
        private DelegateCommand _ThankCardListCommand;


        public DelegateCommand ThankCardListCommand =>
            _ThankCardListCommand ?? (_ThankCardListCommand = new DelegateCommand(ExecuteThankCardListCommand));

        void ExecuteThankCardListCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion

        #region  MenuAdminCommand
        private DelegateCommand _MenuAdminCommand;


        public DelegateCommand MenuAdminCommand =>
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
