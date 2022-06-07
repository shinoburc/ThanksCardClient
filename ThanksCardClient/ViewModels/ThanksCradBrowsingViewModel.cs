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
    public class ThanksCradBrowsingViewModel : BindableBase, INavigationAware
    {
        private readonly IRegionManager regionManager;

        #region UsersProperty
        private List<User> _Users;
        public List<User> Users
        {
            get { return _Users; }
            set { SetProperty(ref _Users, value); }
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

        #region ThanksCardProperty
        private ThanksCard _ThanksCard;
        public ThanksCard ThanksCard
        {
            get { return _ThanksCard; }
            set { SetProperty(ref _ThanksCard, value); }
        }
        #endregion

        public ThanksCradBrowsingViewModel(RegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        public async void OnNavigatedTo(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
            this.ThanksCard = navigationContext.Parameters.GetValue<ThanksCard>("SelectedThanksCard");

            User user = new User();
            this.Users = await user.GetUsersAsync();

            Department dept = new Department();
            this.Departments = await dept.GetDepartmentsAsync();
        }

        #region  ListBackCommand
        private DelegateCommand _ListBackCommand;


        public DelegateCommand ListBackCommand =>
            _ListBackCommand ?? (_ListBackCommand = new DelegateCommand(ExecuteListBackCommand));

        void ExecuteListBackCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.ThanksCardList));
        }
        #endregion
    }
}
