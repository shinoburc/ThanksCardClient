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
    public class UserMstViewModel : BindableBase, INavigationAware
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


        public UserMstViewModel(IRegionManager regionManager)
        {
            this.regionManager = regionManager;
        }

        public void OnNavigatedTo(NavigationContext navigationContext)
        {
            this.UpdateUsers();
        }

        private async void UpdateUsers()
        {
            if (SessionService.Instance.AuthorizedUser != null)
            {
                this.Users = await SessionService.Instance.AuthorizedUser.GetUsersAsync();
            }
        }

        public bool IsNavigationTarget(NavigationContext navigationContext)
        {
            return true;
        }

        public void OnNavigatedFrom(NavigationContext navigationContext)
        {
            //throw new NotImplementedException();
        }

        #region ShowUserCreateCommand
        private DelegateCommand _ShowUserCreateCommand;
        public DelegateCommand ShowUserCreateCommand =>
            _ShowUserCreateCommand ?? (_ShowUserCreateCommand = new DelegateCommand(ExecuteShowUserCreateCommand));

        void ExecuteShowUserCreateCommand()
        {
            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserCreate));
        }
        #endregion

        #region UserEditCommand

        private DelegateCommand<User> _UserEditCommand;
        public DelegateCommand<User> UserEditCommand =>
            _UserEditCommand ?? (_UserEditCommand = new DelegateCommand<User>(ExecuteUserEditCommand));

        void ExecuteUserEditCommand(User SelectedUser)
        {
            // 対象のUserをパラメーターとして画面遷移先に渡す。
            var parameters = new NavigationParameters();
            parameters.Add("SelectedUser", SelectedUser);

            this.regionManager.RequestNavigate("ContentRegion", nameof(Views.UserEdit), parameters);
        }
        #endregion

        #region UserDeleteCommand
        private DelegateCommand<User> _UserDeleteCommand;
        public DelegateCommand<User> UserDeleteCommand =>
            _UserDeleteCommand ?? (_UserDeleteCommand = new DelegateCommand<User>(ExecuteUserDeleteCommand));

        async void ExecuteUserDeleteCommand(User SelectedUser)
        {
            User deletedUser = await SelectedUser.DeleteUserAsync(SelectedUser.Id);

            // ユーザ一覧 Users を更新する。
            this.UpdateUsers();
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
        #endregion

    }
}
